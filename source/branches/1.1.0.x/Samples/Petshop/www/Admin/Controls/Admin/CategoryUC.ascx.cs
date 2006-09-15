#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using netTiers.PetShop;
using netTiers.PetShop.DataAccessLayer;
#endregion

public partial class CategoryUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//Apply scripting element to show/hide the appropriate elements when the listbox index changes
    	this.ddlFilterColumn.Attributes.Add("OnChange", String.Format("ShowFilter('{0}');", this.ClientID));
		
		//Register a startup script to show the appropriate filter elements after a postback
		this.Page.ClientScript.RegisterStartupScript(typeof(Page), this.ClientID + "_OnLoad", String.Format("ShowFilter('{0}');", this.ClientID), true);
    }


	#region Private Properties
	
	/// <summary>
	///Hashtable to hold fields that should be set to null 
	/// </summary>
	private Hashtable _nullFields = new Hashtable();
	
	///<summary>
	///Private property to hold the last filter criteria
	///</summary>
	private string Filter
    {
        get
        {
            if (ViewState["Filter"] == null)
            {
                return String.Empty;
            }
            else
                return ViewState["Filter"].ToString();
        }
        set 
        {
            ViewState["Filter"] = value;
        }
    }
	#endregion
	
    #region Private Methods
	
	///<summary>
	///Cause the GridView to refresh it's data
	///</summary>
    private void RefreshGrid()
    {
        gvList.DataBind();
    }
    
	///<summary>
	///Displays the Editor control and hides the grid control
	///</summary>
    private void ShowEditor()
    {
        tblFilter.Visible = false;
        fvEditor.Visible = true;
    }

	///<summary>
	///Displays the grid control and hides the editor control
	///</summary>
    private void ShowGrid()
    {
        tblFilter.Visible = true;
        fvEditor.Visible = false;
    }

	///<summary>
	///Copies the values from the editor controls up to hidden fields for databinding.
	///</summary>
	/// <remarks>Remove this function once VS2005 bug is fixed.  Microsoft BugID: FDBK39573.</remarks>
	///<param name="container">Control object that contains the hidden fields</param>
	///<param name="fieldName">Then name of the control to extract the value from</param>
	///<param name="prefix1">The prefix of the Hidden field</param>
	///<param name="prefix2">The prefix of the editor control</param>
    private void SaveValues(Control container, string prefix1, string prefix2, string fieldName)
    {
        string saveValue = "";
        HiddenField hfSave = (HiddenField)container.FindControl(prefix1 + fieldName);
        if (hfSave != null)
        {
            Control ctrl = container.FindControl(prefix2 + fieldName);

            if (ctrl != null)
            {
                if (ctrl is TextBox)
                {
                    saveValue = ((TextBox)ctrl).Text;
                }
                else if (ctrl is CheckBox)
                {
                    saveValue = ((CheckBox)ctrl).Checked.ToString();
                }
                else if (ctrl is ListControl)
                {
                    saveValue = ((ListControl)ctrl).SelectedValue.ToString();
                }
                else if (ctrl is System.Web.UI.WebControls.Label)
                {
                    saveValue = ((System.Web.UI.WebControls.Label)ctrl).Text;
                }
                else if (ctrl is System.Web.UI.WebControls.HiddenField)
                {
                    saveValue = ((System.Web.UI.WebControls.HiddenField)ctrl).Value;
                }
                
                hfSave.Value = saveValue;
            }
           
        }
    }
	
	/// <summary>
	/// Binds the client-side code to display the calendar control
	/// </summary>
	/// <param name="prefix">Prefix of the editor control</param>
	private void BindDatePicker(string prefix)
    {
		//Bind each date-time field
    }
	
	/// <summary>
	/// Force an editor control's value to a something that represents a null
	/// </summary>
	/// <param name="ctrl">The control object to change.</param>
	private void SetControlNullDisplay(Control ctrl)
	{
		if (ctrl != null)
		{
			if (ctrl is TextBox)
			{
				((TextBox)ctrl).Text = String.Empty;
			}
			else if (ctrl is CheckBox)
			{
				((CheckBox)ctrl).Checked = false;
			}
			else if (ctrl is ListControl)
			{
				((ListControl)ctrl).SelectedIndex = 0;
			}
		}
	}
	
	/// <summary>
	/// Checks for null values and populates the _nullFields hashtable.  The values
	/// are also formatted so that databinding will work correctly.
	/// </summary>
	/// <remarks>This is called from the fvEditor_ItemUpdating and fvEditor_ItemInserting events.</remarks>
	/// <param name="values">OrderedDictionary of the values that will be sent to the database.</param>
	private void CheckForNulls(System.Collections.Specialized.OrderedDictionary values)
	{
		if ( values != null )
		{
			bool nullFound = false;

			//Clear out the old null values
			_nullFields.Clear();
			
			foreach (string key in values.Keys)
			{
				nullFound = false;
				switch (key)
				{ 
					case "Id":
						
						break;
					case "Name":
						
						break;
					case "AdvicePhoto":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Timestamp":
						
						break;
				}
				//If the field should be set to null, add it's key to the hashtable
				if (nullFound)
				{
					_nullFields.Add(key, null);
				}
			}
		}
	}

	/// <summary>
	/// Calls the appropriate methods on the entity object to set the fields to null.
	/// </summary>
	/// <remarks>This is called from the objDsEdit_Updating and objDsEdit_Inserting events.</remarks>
	/// <param name="entity"><see cref="Category">Category</see> object that is being databound</param>
	private void SetNullValues(Category entity)
	{
		if (entity != null)
		{ 
			//For any fields that accepts nulls, check for default values and act accordingly
			if (_nullFields.ContainsKey("AdvicePhoto"))entity.AdvicePhoto = null;
		}
	}
	
	/// <summary>
	/// Get a string representation of the dataItem's value
	/// </summary>
	/// <remarks>Used in the gvList for formatting the value displayed in the grid.</remarks>
	/// <param name="dataItem"><see cref="Category">Category</see> object to format</param>
	/// <param name="propertyName">Name of the property to format</param>
	/// <returns><see cref="string">String</see></returns>
	public string FormatField(object dataItem, string propertyName)
	{
		string rtn = string.Empty;
		if (dataItem is Category)
		{
			Category entity = (Category)dataItem;
			
			//Check for a Source property (in the format [PropertyNameSource].[PropertyName]
			if (propertyName.IndexOf(".") < 0)
			{
				switch (propertyName)
				{
					case "Id":
						{
							if ( entity.Id != null )
							{
								rtn = entity.Id.Length > 50? entity.Id.Substring(0,50) + "...": entity.Id;
							}
						}
						break;
					case "Name":
						{
							if ( entity.Name != null )
							{
								rtn = entity.Name.Length > 50? entity.Name.Substring(0,50) + "...": entity.Name;
							}
						}
						break;
					case "AdvicePhoto":
					
						if (entity.AdvicePhoto == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.AdvicePhoto != null )
							{
								rtn = entity.AdvicePhoto.Length > 50? entity.AdvicePhoto.Substring(0,50) + "...": entity.AdvicePhoto;
							}
						}
						break;
					case "Timestamp":
						{
							if ( entity.Timestamp != null )
							{
								rtn = entity.Timestamp.ToString();
							}
						}
						break;
					default:
						rtn = string.Format("Invalid Property: {0}",propertyName);
						break;
				}
			}
			else
			{ 
				//Source Property
				string sourceName = propertyName.Split(new char[] { '.' })[0];
				string sourceProperty= propertyName.Split(new char[] { '.' })[1];

				switch (sourceName)
				{ 
					//Use reflection to get the source property - not sure if this is the best way...
					//No formatting will be available at this time.
					default:
						rtn = string.Format("Invalid Source property: {0}",propertyName);
						break;
				}
			}
			
		}

		return rtn;
	}
	
	/// <summary>
	/// Get a string representation of an entity's property using reflection
	/// </summary>
	/// <param name="entity">Entity to extract the value from</param>
	/// <param name="propertyName">Name of the property to extract</param>
	/// <returns><see cref="string">String</see></returns>
	private string GetReflectedPropertyValue(object entity, string propertyName)
	{
		string rtn = String.Empty;

		if (entity != null)
		{
			System.Reflection.PropertyInfo pi = entity.GetType().GetProperty(propertyName);
			rtn = pi.GetValue(entity, null).ToString();
		}

		return rtn;
	}

#endregion

#region Public Methods

    public object BindWithNull(object value, object nullValue)
    {
        if (value == null)
            return nullValue;
        else
            return value;
    }

    #endregion

	 #region objDsList Events
	
    protected void objDsList_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = DataRepository.CategoryProvider;
    }
	
    protected void objDsList_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (e.ExecutingSelectCount)
        {
				//You will get here the second time through when it's trying to get the number of records
        }
        else if (e.Arguments.MaximumRows > 0)
        {
            //Adjust the StartRowIndex method.  The GetPaged function expects
            //a page index rather than a row index.
            e.Arguments.StartRowIndex = e.Arguments.StartRowIndex / e.Arguments.MaximumRows;
				
				//Check the filter
            String filter = this.Filter;

            if (filter != String.Empty)
            {
                e.InputParameters["whereClause"] = filter;
            }
        }
    }
	
	protected void objDsList_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
		if (e.Exception != null)
		{
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
    }
	
	protected void objDsList_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
	}
    #endregion
	
	#region objDsEdit Events
	
	protected void objDsEdit_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = DataRepository.CategoryProvider;
    }
	
	protected void objDsEdit_Updating(object sender, ObjectDataSourceMethodEventArgs e)
	{
		Category entity = (Category)e.InputParameters[0];

		SetNullValues(entity);

	}

	protected void objDsEdit_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
	{
		Category entity = (Category)e.InputParameters[0];

		SetNullValues(entity);
	}
	
	
	protected void objDsEdit_Updated(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{ 
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
		
		//Data has been updated, clear the hashtable
		_nullFields.Clear();
	}

	protected void objDsEdit_Selected(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
	}

	protected void objDsEdit_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
	}
	protected void objDsEdit_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{
			//Handle your exception here...
			//e.ExceptionHandled = true;
		}
	}
	
	#endregion

    #region Grid Methods
    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName.ToUpper())
        { 
            case "NEW":
                fvEditor.ChangeMode(FormViewMode.Insert);
                break;
            case "SELECT":
                fvEditor.ChangeMode(FormViewMode.Edit);   
                break;
            default:
                return;
        }

        ShowEditor();
    }

    #endregion

    #region FormView Methods
    protected void fvEditor_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        switch (e.CommandName.ToUpper())
        {
            case "UPDATE":
                //Save the values to the hidden fields
                //This is required due to a bug with VS 2005 (MS BugID: FDBK39573)
                #region VS2005 Bug Fix
                SaveValues(fvEditor, "update", "data", "Id");
                SaveValues(fvEditor, "update", "data", "Name");
                SaveValues(fvEditor, "update", "data", "AdvicePhoto");
                #endregion
                break;
            case "INSERT":
                //Save the values to the hidden fields
                //This is required due to a bug with VS 2005 (MS BugID: FDBK39573)
                #region VS2005 Bug Fix
                SaveValues(fvEditor, "insert", "dataInsert", "Id");
                SaveValues(fvEditor, "insert", "dataInsert", "Name");
                SaveValues(fvEditor, "insert", "dataInsert", "AdvicePhoto");
                #endregion
                break;
            case "CANCEL":
                ShowGrid();
                break;
        }

        ShowGrid();
    }

    protected void fvEditor_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
        RefreshGrid();
        ShowGrid();
    }
    protected void fvEditor_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        RefreshGrid();
        ShowGrid();
    }
    protected void fvEditor_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        RefreshGrid();
        ShowGrid();
    }
	
	 protected void fvEditor_DataBound(object sender, EventArgs e)
    {
        switch (fvEditor.CurrentMode)
        { 
            case FormViewMode.Insert:
					BindDatePicker("Insert");
					break;
            case FormViewMode.Edit:
					BindDatePicker("");
					
					//Special formatting required for fields accepting nulls.
					if ( sender is FormView)
					{
						FormView fv = (FormView)sender;

						if (fv.DataItem is Category)
						{
							Category entity = (Category)fv.DataItem;
							//Check for null values and format the editor control appropriately
							if ( entity.AdvicePhoto == null ) SetControlNullDisplay(fv.FindControl("dataAdvicePhoto"));
						}
				}
                break;
        }
    }
	
	protected void fvEditor_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		//Custom Validation
		System.Collections.Specialized.OrderedDictionary values = (System.Collections.Specialized.OrderedDictionary)e.NewValues;
		CheckForNulls(values);
	}

	protected void fvEditor_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		//Custom Validation
		System.Collections.Specialized.OrderedDictionary values = (System.Collections.Specialized.OrderedDictionary)e.Values;
		
		
		CheckForNulls(values);
	}	
	
    #endregion
	
    #region Filter Methods
    protected string GetFilter()
	{
		string filter = String.Empty;
		
		switch (ddlFilterColumn.SelectedValue)
		{
			default:
				if (txtFilterCriteria.Text != String.Empty)
				{
					string wildCard = String.Empty;
					if (ddlFilterOperator.SelectedIndex == 0)
					{
						wildCard = "%";
					}
					filter = String.Format("[{0}] {1} '{2}{3}'", ddlFilterColumn.SelectedValue, ddlFilterOperator.SelectedValue, txtFilterCriteria.Text, wildCard);
				}
				break;
		}

		return filter;
	}
    protected void SetFilter(string filter)
    {
        if (filter == String.Empty)
        {
            txtFilterCriteria.Text = String.Empty;
        }
        this.Filter = filter;
        gvList.DataBind();
    }


    protected void btnFilter_Click(object sender, EventArgs e)
    {
        SetFilter(GetFilter());
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        SetFilter("");
    }

    #endregion
	
	#region Other ObjectDataSource Methods
	
	
	#endregion
}

