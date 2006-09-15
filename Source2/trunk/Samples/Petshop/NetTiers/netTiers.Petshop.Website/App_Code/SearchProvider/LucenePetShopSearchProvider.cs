using System;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#region Lucene using directives

using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search.Highlight;
using Lucene.Net.Store;

#endregion

/// <summary>
/// Summary description for PetShopSearchProvider
/// </summary>
public class LucenePetShopSearchProvider : PetShopSearchProvider
{
    RAMDirectory ramDir = new RAMDirectory();

    /// <summary>
    /// Initializes a new instance of the <see cref="T:LucenePetShopSearchProvider"/> class.
    /// </summary>
    public LucenePetShopSearchProvider()
    {
        BuildIndex();
    }
   
    private void BuildIndex()
    {
        IndexWriter indexWriter = new IndexWriter(ramDir, new StandardAnalyzer(), true);

        foreach (ExtendedItem exItem in DataRepository.ExtendedItemProvider.GetAll())
        {
            // add new one
            Document doc = new Document();

            doc.Add(Field.Keyword("ItemId", exItem.ItemId));
            doc.Add(Field.Text("ItemName", exItem.ItemName));
            doc.Add(Field.Text("ItemDescription", exItem.ItemDescription));
            doc.Add(Field.Text("ItemPhoto", exItem.ItemPhoto));

            doc.Add(Field.Keyword("CategoryId", exItem.CategoryId));
            doc.Add(Field.Text("CategoryName", exItem.CategoryName));

            doc.Add(Field.Keyword("ProductId", exItem.ProductId));
            doc.Add(Field.Text("ProductName", exItem.ProductName));
            doc.Add(Field.Text("ProductDescription", exItem.ProductDescription));

            doc.Add(Field.Text("Content", string.Format("{0} {1} {2} {3} {4}", exItem.ItemName, exItem.ItemDescription, exItem.CategoryName, exItem.ProductName, exItem.ProductDescription)));

            indexWriter.AddDocument(doc);
        }

        // close writer
        indexWriter.Optimize();
        indexWriter.Close();
    }

	public override List<ExtendedItem> Search(string queryString)
    {
		List<ExtendedItem> results = new List<ExtendedItem>();

        
        if (queryString == null || queryString.Length == 0)
            return results;

        // Build an IndexSearcher using the in-memory index
        Searcher searcher = new IndexSearcher(ramDir);

        // Build a Query object
        Query query = QueryParser.Parse(queryString, "Content", new StandardAnalyzer());

        // Search for the query
        Hits hits = searcher.Search(query);

        // Examine the Hits object to see if there were any matches
        int hitCount = hits.Length();
        if (hitCount == 0)
        {
            //HttpContext.Current.Response.Write("No matches were found for \"" + queryString + "\"");
        }
        else
        {
            // Iterate over the Documents in the Hits object
            for (int i = 0; i < hitCount; i++)
            {
                Document doc = hits.Doc(i);

                ExtendedItem item = new ExtendedItem();
                item.ItemId = doc.Get("ItemId");
                item.ItemName = doc.Get("ItemName");
                item.ItemPhoto = doc.Get("ItemPhoto");
                item.ItemDescription = doc.Get("ItemDescription");
                item.ProductId = doc.Get("ProductId");
                
                results.Add(item);
            }
        }
        return results;
    }
}
