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

public partial class AccountUC : System.Web.UI.UserControl
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
					case "FirstName":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "LastName":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "StreetAddress":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "PostalCode":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "City":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "StateOrProvince":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Country":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "TelephoneNumber":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Email":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Login":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Password":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "IWantMyList":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = false;
							nullFound = true;
						}
						
						break;
					case "IWantPetTips":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = false;
							nullFound = true;
						}
						
						break;
					case "FavoriteLanguage":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "CreditCardId":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == Convert.ToString(string.Empty))
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "FavoriteCategoryId":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == Convert.ToString(string.Empty))
						
						{
							values[key] = string.Empty;
							nullFound = true;
						}
						
						break;
					case "Timestamp":
						//This field allows nulls, convert to default value
						if (values[key].ToString() == String.Empty)
						
						{
							values[key] = new byte[] {};
							nullFound = true;
						}
						
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
	/// <param name="entity"><see cref="Account">Account</see> object that is being databound</param>
	private void SetNullValues(Account entity)
	{
		if (entity != null)
		{ 
			//For any fields that accepts nulls, check for default values and act accordingly
			if (_nullFields.ContainsKey("FirstName"))entity.FirstName = null;
			if (_nullFields.ContainsKey("LastName"))entity.LastName = null;
			if (_nullFields.ContainsKey("StreetAddress"))entity.StreetAddress = null;
			if (_nullFields.ContainsKey("PostalCode"))entity.PostalCode = null;
			if (_nullFields.ContainsKey("City"))entity.City = null;
			if (_nullFields.ContainsKey("StateOrProvince"))entity.StateOrProvince = null;
			if (_nullFields.ContainsKey("Country"))entity.Country = null;
			if (_nullFields.ContainsKey("TelephoneNumber"))entity.TelephoneNumber = null;
			if (_nullFields.ContainsKey("Email"))entity.Email = null;
			if (_nullFields.ContainsKey("Login"))entity.Login = null;
			if (_nullFields.ContainsKey("Password"))entity.Password = null;
			if (_nullFields.ContainsKey("IWantMyList"))entity.IWantMyList = null;
			if (_nullFields.ContainsKey("IWantPetTips"))entity.IWantPetTips = null;
			if (_nullFields.ContainsKey("FavoriteLanguage"))entity.FavoriteLanguage = null;
			if (_nullFields.ContainsKey("CreditCardId"))entity.CreditCardId = null;
			if (_nullFields.ContainsKey("FavoriteCategoryId"))entity.FavoriteCategoryId = null;
			if (_nullFields.ContainsKey("Timestamp"))entity.Timestamp = null;
		}
	}
	
	/// <summary>
	/// Get a string representation of the dataItem's value
	/// </summary>
	/// <remarks>Used in the gvList for formatting the value displayed in the grid.</remarks>
	/// <param name="dataItem"><see cref="Account">Account</see> object to format</param>
	/// <param name="propertyName">Name of the property to format</param>
	/// <returns><see cref="string">String</see></returns>
	public string FormatField(object dataItem, string propertyName)
	{
		string rtn = string.Empty;
		if (dataItem is Account)
		{
			Account entity = (Account)dataItem;
			
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
					case "FirstName":
					
						if (entity.FirstName == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.FirstName != null )
							{
								rtn = entity.FirstName.Length > 50? entity.FirstName.Substring(0,50) + "...": entity.FirstName;
							}
						}
						break;
					case "LastName":
					
						if (entity.LastName == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.LastName != null )
							{
								rtn = entity.LastName.Length > 50? entity.LastName.Substring(0,50) + "...": entity.LastName;
							}
						}
						break;
					case "StreetAddress":
					
						if (entity.StreetAddress == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.StreetAddress != null )
							{
								rtn = entity.StreetAddress.Length > 50? entity.StreetAddress.Substring(0,50) + "...": entity.StreetAddress;
							}
						}
						break;
					case "PostalCode":
					
						if (entity.PostalCode == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.PostalCode != null )
							{
								rtn = entity.PostalCode.Length > 50? entity.PostalCode.Substring(0,50) + "...": entity.PostalCode;
							}
						}
						break;
					case "City":
					
						if (entity.City == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.City != null )
							{
								rtn = entity.City.Length > 50? entity.City.Substring(0,50) + "...": entity.City;
							}
						}
						break;
					case "StateOrProvince":
					
						if (entity.StateOrProvince == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.StateOrProvince != null )
							{
								rtn = entity.StateOrProvince.Length > 50? entity.StateOrProvince.Substring(0,50) + "...": entity.StateOrProvince;
							}
						}
						break;
					case "Country":
					
						if (entity.Country == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.Country != null )
							{
								rtn = entity.Country.Length > 50? entity.Country.Substring(0,50) + "...": entity.Country;
							}
						}
						break;
					case "TelephoneNumber":
					
						if (entity.TelephoneNumber == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.TelephoneNumber != null )
							{
								rtn = entity.TelephoneNumber.Length > 50? entity.TelephoneNumber.Substring(0,50) + "...": entity.TelephoneNumber;
							}
						}
						break;
					case "Email":
					
						if (entity.Email == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.Email != null )
							{
								rtn = entity.Email.Length > 50? entity.Email.Substring(0,50) + "...": entity.Email;
							}
						}
						break;
					case "Login":
					
						if (entity.Login == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.Login != null )
							{
								rtn = entity.Login.Length > 50? entity.Login.Substring(0,50) + "...": entity.Login;
							}
						}
						break;
					case "Password":
					
						if (entity.Password == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.Password != null )
							{
								rtn = entity.Password.Length > 50? entity.Password.Substring(0,50) + "...": entity.Password;
							}
						}
						break;
					case "IWantMyList":
					
						if (entity.IWantMyList == null)
						{
							rtn = string.Empty;
						}
						else
						{
							{
								rtn = entity.IWantMyList == true ?"Yes":"No";
							}
						}
						break;
					case "IWantPetTips":
					
						if (entity.IWantPetTips == null)
						{
							rtn = string.Empty;
						}
						else
						{
							{
								rtn = entity.IWantPetTips == true ?"Yes":"No";
							}
						}
						break;
					case "FavoriteLanguage":
					
						if (entity.FavoriteLanguage == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.FavoriteLanguage != null )
							{
								rtn = entity.FavoriteLanguage.Length > 50? entity.FavoriteLanguage.Substring(0,50) + "...": entity.FavoriteLanguage;
							}
						}
						break;
					case "CreditCardId":
					
						if (entity.CreditCardId == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.CreditCardId != null )
							{
								rtn = entity.CreditCardId.Length > 50? entity.CreditCardId.Substring(0,50) + "...": entity.CreditCardId;
							}
						}
						break;
					case "FavoriteCategoryId":
					
						if (entity.FavoriteCategoryId == null)
						{
							rtn = string.Empty;
						}
						else
						{
							if ( entity.FavoriteCategoryId != null )
							{
								rtn = entity.FavoriteCategoryId.Length > 50? entity.FavoriteCategoryId.Substring(0,50) + "...": entity.FavoriteCategoryId;
							}
						}
						break;
					case "Timestamp":
					
						if (entity.Timestamp == null)
						{
							rtn = string.Empty;
						}
						else
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
					case "FavoriteCategoryIdSource":
						rtn = GetReflectedPropertyValue(entity.FavoriteCategoryIdSource, sourceProperty);
						break;
					case "CreditCardIdSource":
						rtn = GetReflectedPropertyValue(entity.CreditCardIdSource, sourceProperty);
						break;
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
        e.ObjectInstance = DataRepository.AccountProvider;
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
		else
		{
			//Populate all XXXSource properties
        object o = e.ReturnValue;

        if (o is TList<Account>)
        {
            TList<Account> coll = (TList<Account>)o;
            
            foreach(Account entity in coll)
            {
                if (entity.FavoriteCategoryIdSource == null)
                {
                    Category source = DataRepository.CategoryProvider.GetById(entity.FavoriteCategoryId);
                    entity.FavoriteCategoryIdSource = source;
                }
                if (entity.CreditCardIdSource == null)
                {
                    CreditCard source = DataRepository.CreditCardProvider.GetById(entity.CreditCardId);
                    entity.CreditCardIdSource = source;
                }
            }

        }
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
        e.ObjectInstance = DataRepository.AccountProvider;
    }
	
	protected void objDsEdit_Updating(object sender, ObjectDataSourceMethodEventArgs e)
	{
		Account entity = (Account)e.InputParameters[0];

		SetNullValues(entity);

	}

	protected void objDsEdit_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
	{
		Account entity = (Account)e.InputParameters[0];

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
                SaveValues(fvEditor, "update", "data", "FirstName");
                SaveValues(fvEditor, "update", "data", "LastName");
                SaveValues(fvEditor, "update", "data", "StreetAddress");
                SaveValues(fvEditor, "update", "data", "PostalCode");
                SaveValues(fvEditor, "update", "data", "City");
                SaveValues(fvEditor, "update", "data", "StateOrProvince");
                SaveValues(fvEditor, "update", "data", "Country");
                SaveValues(fvEditor, "update", "data", "TelephoneNumber");
                SaveValues(fvEditor, "update", "data", "Email");
                SaveValues(fvEditor, "update", "data", "Login");
                SaveValues(fvEditor, "update", "data", "Password");
                SaveValues(fvEditor, "update", "data", "IWantMyList");
                SaveValues(fvEditor, "update", "data", "IWantPetTips");
                SaveValues(fvEditor, "update", "data", "FavoriteLanguage");
                SaveValues(fvEditor, "update", "data", "CreditCardId");
                SaveValues(fvEditor, "update", "data", "FavoriteCategoryId");
                #endregion
                break;
            case "INSERT":
                //Save the values to the hidden fields
                //This is required due to a bug with VS 2005 (MS BugID: FDBK39573)
                #region VS2005 Bug Fix
                SaveValues(fvEditor, "insert", "dataInsert", "Id");
                SaveValues(fvEditor, "insert", "dataInsert", "FirstName");
                SaveValues(fvEditor, "insert", "dataInsert", "LastName");
                SaveValues(fvEditor, "insert", "dataInsert", "StreetAddress");
                SaveValues(fvEditor, "insert", "dataInsert", "PostalCode");
                SaveValues(fvEditor, "insert", "dataInsert", "City");
                SaveValues(fvEditor, "insert", "dataInsert", "StateOrProvince");
                SaveValues(fvEditor, "insert", "dataInsert", "Country");
                SaveValues(fvEditor, "insert", "dataInsert", "TelephoneNumber");
                SaveValues(fvEditor, "insert", "dataInsert", "Email");
                SaveValues(fvEditor, "insert", "dataInsert", "Login");
                SaveValues(fvEditor, "insert", "dataInsert", "Password");
                SaveValues(fvEditor, "insert", "dataInsert", "IWantMyList");
                SaveValues(fvEditor, "insert", "dataInsert", "IWantPetTips");
                SaveValues(fvEditor, "insert", "dataInsert", "FavoriteLanguage");
                SaveValues(fvEditor, "insert", "dataInsert", "CreditCardId");
                SaveValues(fvEditor, "insert", "dataInsert", "FavoriteCategoryId");
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

						if (fv.DataItem is Account)
						{
							Account entity = (Account)fv.DataItem;
							//Check for null values and format the editor control appropriately
							if ( entity.FirstName == null ) SetControlNullDisplay(fv.FindControl("dataFirstName"));
							if ( entity.LastName == null ) SetControlNullDisplay(fv.FindControl("dataLastName"));
							if ( entity.StreetAddress == null ) SetControlNullDisplay(fv.FindControl("dataStreetAddress"));
							if ( entity.PostalCode == null ) SetControlNullDisplay(fv.FindControl("dataPostalCode"));
							if ( entity.City == null ) SetControlNullDisplay(fv.FindControl("dataCity"));
							if ( entity.StateOrProvince == null ) SetControlNullDisplay(fv.FindControl("dataStateOrProvince"));
							if ( entity.Country == null ) SetControlNullDisplay(fv.FindControl("dataCountry"));
							if ( entity.TelephoneNumber == null ) SetControlNullDisplay(fv.FindControl("dataTelephoneNumber"));
							if ( entity.Email == null ) SetControlNullDisplay(fv.FindControl("dataEmail"));
							if ( entity.Login == null ) SetControlNullDisplay(fv.FindControl("dataLogin"));
							if ( entity.Password == null ) SetControlNullDisplay(fv.FindControl("dataPassword"));
							if ( entity.IWantMyList == null ) SetControlNullDisplay(fv.FindControl("dataIWantMyList"));
							if ( entity.IWantPetTips == null ) SetControlNullDisplay(fv.FindControl("dataIWantPetTips"));
							if ( entity.FavoriteLanguage == null ) SetControlNullDisplay(fv.FindControl("dataFavoriteLanguage"));
							if ( entity.CreditCardId == null ) SetControlNullDisplay(fv.FindControl("dataCreditCardId"));
							if ( entity.FavoriteCategoryId == null ) SetControlNullDisplay(fv.FindControl("dataFavoriteCategoryId"));
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
			case "FavoriteCategoryId":
				//This column accepts nulls
				if (ddlFilterFavoriteCategoryId.SelectedIndex == 0)
				{
					filter = String.Format("[{0}] IS NULL", ddlFilterColumn.SelectedValue);
				}
				else
				filter = String.Format("[{0}] = '{1}'", ddlFilterColumn.SelectedValue, ddlFilterFavoriteCategoryId.SelectedValue);
				break;
			case "CreditCardId":
				//This column accepts nulls
				if (ddlFilterCreditCardId.SelectedIndex == 0)
				{
					filter = String.Format("[{0}] IS NULL", ddlFilterColumn.SelectedValue);
				}
				else
				filter = String.Format("[{0}] = '{1}'", ddlFilterColumn.SelectedValue, ddlFilterCreditCardId.SelectedValue);
				break;
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
	
	#region objDsFavoriteCategoryId Methods
	
	protected void objDsFavoriteCategoryId_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = DataRepository.CategoryProvider;
    }
	
	protected void objDsFavoriteCategoryId_Selected(object sender, ObjectDataSourceStatusEventArgs e)
	{
		//This field allows nulls, so we must add a blank entity to the collection for databinding purposes.
		TList<Category> coll = (TList<Category>)e.ReturnValue;
		Category entity = new Category();
		entity.Id = string.Empty;
		coll.Insert(0, entity);
	}

	#endregion
	
	#region objDsCreditCardId Methods
	
	protected void objDsCreditCardId_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = DataRepository.CreditCardProvider;
    }
	
	protected void objDsCreditCardId_Selected(object sender, ObjectDataSourceStatusEventArgs e)
	{
		//This field allows nulls, so we must add a blank entity to the collection for databinding purposes.
		TList<CreditCard> coll = (TList<CreditCard>)e.ReturnValue;
		CreditCard entity = new CreditCard();
		entity.Id = string.Empty;
		coll.Insert(0, entity);
	}

	#endregion
	
	
	#endregion
}

