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

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Page.IsPostBack)
		{
			if (ViewState["AdminControl"] != null)
			{
				LoadAdminControl(ViewState["AdminControl"].ToString());
			}
		}

        //NetTiersTest2.Northwind.ProductsCollection coll =  NetTiersTest2.Northwind.DataAccessLayer.DataRepository.ProductsProvider.GetAll();
	}

	private void LoadAdminControl(string controlName)
	{
		ViewState["AdminControl"] = controlName;

		Control ctrl = null;
		if (ViewState[controlName] != null)
		{
			ctrl = (Control)Cache[controlName];
		}
		else
		{
			ctrl = LoadControl(String.Format("Controls/Admin/{0}UC.ascx", controlName));
			//Cache.Add(controlName, ctrl, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default,null);
			//ViewState[controlName] = ctrl;
		}

		ctrl.ID = "Admin" + controlName;



		plAdmin.Controls.Clear();
		plAdmin.Controls.Add(ctrl);
	}

	protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
	{
		string controlName = ((BulletedList)sender).Items[e.Index].Value;
		LoadAdminControl(controlName);

	}
	protected void MenuItem_Click(object sender, MenuEventArgs e)
	{
		string controlName = e.Item.Value; // ((BulletedList)sender).Items[e.Index].Value;
		LoadAdminControl(controlName);

	}
}
