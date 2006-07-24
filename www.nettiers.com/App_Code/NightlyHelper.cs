using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;


/// <summary>
/// Summary description for NightlyHelper
/// </summary>
[System.ComponentModel.DataObject]
public class NightlyHelper
{
	public static string rootPath = "nightly";
	public static string fx1Mask = "nettiers-fx1.1-*.zip";
	public static string fx2Mask = "nettiers-fx2.0-*.zip";
	public static string fx2bMask = "nettiers-fx2.0b-*.zip";

	public NightlyHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public class NigtlyBuild
	{
		public NigtlyBuild(string p, string f)
		{
			Name = p;
			FileName = f;
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _fileName;

		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

	}

	[System.ComponentModel.DataObjectMethod( System.ComponentModel.DataObjectMethodType.Select)]
	public List<NigtlyBuild> GetFiles(string mask)
	{
	    int startPos = (mask == fx2bMask ? 16 : 15);
		List<NigtlyBuild> files = new List<NigtlyBuild>();
		DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(rootPath));
	    foreach (FileInfo file in dir.GetFiles(mask))
	    {
		    files.Add(new NigtlyBuild(string.Format("{0}/{1}/{2}", file.Name.Substring(startPos, 4), file.Name.Substring(startPos + 4, 2), file.Name.Substring(startPos + 6, 2)), file.Name));
	    }

		files.Sort(delegate(NigtlyBuild n1, NigtlyBuild n2 ){return n1.Name.CompareTo(n2.Name);});
		files.Reverse();
		return files;
	}	
}
