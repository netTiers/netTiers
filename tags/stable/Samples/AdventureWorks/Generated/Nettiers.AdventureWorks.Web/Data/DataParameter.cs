#region Using Directives
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Web.UI;
#endregion

namespace Nettiers.AdventureWorks.Web.Data
{
	/// <summary>
	/// Binds specific data from an <see cref="IListDataSource"/> to a parameter object.
	/// </summary>
	public class DataParameter : Parameter
	{
		private IListDataSource _dataSource;
		private String _dataSourceID;
		private String _entityKeyName;
		private String _propertyName;

		/// <summary>
		/// Initializes a new instance of the DataParameter class.
		/// </summary>
		public DataParameter()
		{
		}

		/// <summary>
		/// Gets or sets the DataSourceID.
		/// </summary>
		public String DataSourceID
		{
			get { return _dataSourceID; }
			set { _dataSourceID = value; }
		}

		/// <summary>
		/// Gets or sets the EntityKeyName.
		/// </summary>
		public String EntityKeyName
		{
			get { return _entityKeyName; }
			set { _entityKeyName = value; }
		}

		/// <summary>
		/// Gets or sets the PropertyName.
		/// </summary>
		public String PropertyName
		{
			get { return _propertyName; }
			set { _propertyName = value; }
		}

		/// <summary>
		/// Updates and returns the value of the DataParameter object.
		/// </summary>
		/// <param name="context">The current System.Web.HttpContext of the request.</param>
		/// <param name="control">The System.Web.UI.Control that the parameter is bound to.</param>
		/// <returns>A System.Object that represents the updated and current value of the parameter.</returns>
		protected override Object Evaluate(HttpContext context, Control control)
		{
			String value = String.Empty;

			if ( _dataSource == null && control != null )
			{
				_dataSource = control.FindControl(DataSourceID) as IListDataSource;
			}
			if ( _dataSource != null )
			{
				IEnumerable entityList = _dataSource.GetEntityList();

				if ( entityList != null )
				{
					CommaDelimitedStringCollection values = new CommaDelimitedStringCollection();
					String propertyName = PropertyName ?? EntityKeyName;
					IList list = EntityUtil.GetEntityList(entityList);
					Object temp;

					foreach ( Object item in list )
					{
						temp = EntityUtil.GetPropertyValue(item, EntityKeyName);

						if ( temp != null )
						{
							values.Add(String.Format("'{0}'", temp));
						}
					}

					if ( values.Count > 0 )
					{
						value = String.Format("{0} IN ({1})", propertyName, values.ToString());
					}
				}
			}

			return value;
		}
	}
}
