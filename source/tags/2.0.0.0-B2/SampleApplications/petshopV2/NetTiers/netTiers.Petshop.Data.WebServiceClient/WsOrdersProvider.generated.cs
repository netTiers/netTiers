﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file netTiers.Petshop.Entities.Orders.cs instead.
*/

#region "Using directives"

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data.Bases;

#endregion

namespace netTiers.Petshop.Data.WebServiceClient
{

	///<summary>
	/// This class is the webservice client implementation that exposes CRUD methods for netTiers.Petshop.Entities.Orders objects.
	///</summary>
	public partial class WsOrdersProvider : OrdersProviderBase
	{
		#region "Declarations"	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		protected string _url;
			
		#endregion "Declarations"
		
		#region "Constructors"
	
		/// <summary>
		/// Creates a new <see cref="WsOrdersProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsOrdersProvider()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsOrdersProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsOrdersProvider(string url)
		{
			this._url = url;
		}
			
		#endregion "Constructors"
		
		public string Url
        {
        	get {return this._url;}
        	set {this._url = value;}
        }
		
		#region "Convertion utility"
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static netTiers.Petshop.Entities.TList<Orders> Convert(WsProxy.Orders[] items)
		{
			netTiers.Petshop.Entities.TList<Orders> outItems = new netTiers.Petshop.Entities.TList<Orders>();
			foreach(WsProxy.Orders item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static netTiers.Petshop.Entities.Orders Convert(WsProxy.Orders item)
		{	
			netTiers.Petshop.Entities.Orders outItem = new netTiers.Petshop.Entities.Orders();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static netTiers.Petshop.Entities.Orders Convert(netTiers.Petshop.Entities.Orders outItem , WsProxy.Orders item)
		{	
			outItem.OrderId = item.OrderId;
			outItem.AccountId = item.AccountId;
			outItem.OrderDate = item.OrderDate;
			outItem.ShipAddr1 = item.ShipAddr1;
			outItem.ShipAddr2 = item.ShipAddr2;
			outItem.ShipCity = item.ShipCity;
			outItem.ShipState = item.ShipState;
			outItem.ShipZip = item.ShipZip;
			outItem.ShipCountry = item.ShipCountry;
			outItem.BillAddr1 = item.BillAddr1;
			outItem.BillAddr2 = item.BillAddr2;
			outItem.BillCity = item.BillCity;
			outItem.BillState = item.BillState;
			outItem.BillZip = item.BillZip;
			outItem.BillCountry = item.BillCountry;
			outItem.CourierId = item.CourierId;
			outItem.TotalPrice = item.TotalPrice;
			outItem.BillToFirstName = item.BillToFirstName;
			outItem.BillToLastName = item.BillToLastName;
			outItem.ShipToFirstName = item.ShipToFirstName;
			outItem.ShipToLastName = item.ShipToLastName;
			outItem.CreditCardId = item.CreditCardId;
			outItem.Locale = item.Locale;
			outItem.Timestamp = item.Timestamp;
			
							
			outItem.AcceptChanges();			
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.Orders Convert(netTiers.Petshop.Entities.Orders item)
		{			
			WsProxy.Orders outItem = new WsProxy.Orders();			
			outItem.OrderId = item.OrderId;
			outItem.AccountId = item.AccountId;
			outItem.OrderDate = item.OrderDate;
			outItem.ShipAddr1 = item.ShipAddr1;
			outItem.ShipAddr2 = item.ShipAddr2;
			outItem.ShipCity = item.ShipCity;
			outItem.ShipState = item.ShipState;
			outItem.ShipZip = item.ShipZip;
			outItem.ShipCountry = item.ShipCountry;
			outItem.BillAddr1 = item.BillAddr1;
			outItem.BillAddr2 = item.BillAddr2;
			outItem.BillCity = item.BillCity;
			outItem.BillState = item.BillState;
			outItem.BillZip = item.BillZip;
			outItem.BillCountry = item.BillCountry;
			outItem.CourierId = item.CourierId;
			outItem.TotalPrice = item.TotalPrice;
			outItem.BillToFirstName = item.BillToFirstName;
			outItem.BillToLastName = item.BillToLastName;
			outItem.ShipToFirstName = item.ShipToFirstName;
			outItem.ShipToLastName = item.ShipToLastName;
			outItem.CreditCardId = item.CreditCardId;
			outItem.Locale = item.Locale;
			outItem.Timestamp = item.Timestamp;

							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.Orders[] Convert(netTiers.Petshop.Entities.TList<Orders> items)
		{
			WsProxy.Orders[] outItems = new WsProxy.Orders[items.Count];
			int count = 0;
		
			foreach (netTiers.Petshop.Entities.Orders item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region "Get from  Many To Many Relationship Functions"
		#endregion	
		
		
		#region "Delete Functions"			
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="OrderId">. Primary Key.</param>	
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 orderId, byte[] timestamp)
			{
				// call the proxy
				WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
				proxy.Url = this._url;
				
				bool result = proxy.OrdersProvider_Delete(orderId, timestamp);				
				return result;
			}
			
			#endregion
	
		
		#region "Find Functions"
		
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			WsProxy.Orders[] items = proxy.OrdersProvider_Find(whereClause, start, pagelen, out count);
			
			return Convert(items); 
		}
		
		#endregion "Find Functions"
		
		
		#region "GetList Functions"
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>			
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
				
			WsProxy.Orders[] items = proxy.OrdersProvider_GetAll(start, pageLength, out count);
			
			return Convert(items); 
		}
		
		#endregion
		
		#region Get Paged
						
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			WsProxy.Orders[] items = proxy.OrdersProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
			// Create a collection and fill it with the dataset
			return Convert(items); 
		}
		
		#endregion		
	
		
		#region "Get By Foreign Key Functions"
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		FK_Orders_Account Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> GetByAccountId(TransactionManager transactionManager, System.Guid accountId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.Orders[] items = proxy.OrdersProvider_GetByAccountId(accountId, start, pageLength, out count);
			
			return Convert(items); 
		}
			
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		FK_Orders_Courier Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> GetByCourierId(TransactionManager transactionManager, System.Guid courierId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.Orders[] items = proxy.OrdersProvider_GetByCourierId(courierId, start, pageLength, out count);
			
			return Convert(items); 
		}
			
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		FK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public override netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(TransactionManager transactionManager, System.Guid creditCardId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.Orders[] items = proxy.OrdersProvider_GetByCreditCardId(creditCardId, start, pageLength, out count);
			
			return Convert(items); 
		}
			
		#endregion
		
		
		#region "Get By Index Functions"
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public override netTiers.Petshop.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.Orders items = proxy.OrdersProvider_GetByOrderId(orderId, start, pageLength, out count);
			
			return Convert(items); 
		}
		
		#endregion "Get By Index Functions"
	
	
		#region "Insert Functions"
		/// <summary>
		/// 	Inserts a netTiers.Petshop.Entities.Orders object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.Orders object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, netTiers.Petshop.Entities.Orders entity)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			try
			{
				WsProxy.Orders result = proxy.OrdersProvider_Insert(Convert(entity));
				Convert(entity, result);
				return true;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return false;
			}
		}
	
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">NOTE: The transaction manager should be null for the web service client implementation.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		/// After inserting into the datasource, the netTiers.Petshop.Entities.Orders object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, TList<netTiers.Petshop.Entities.Orders> entityList)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			try
			{
				proxy.OrdersProvider_BulkInsert(Convert(entityList));
			}
			catch (Exception ex)
			{	
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		#endregion
	
	
		#region "Update Functions"
						
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.Orders object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, netTiers.Petshop.Entities.Orders entity)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			try
			{
				WsProxy.Orders result = proxy.OrdersProvider_Update(Convert(entity));
				Convert(entity, result);
				entity.AcceptChanges();
				return true;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return false;
			}
		}
		
		#endregion
			
		#region "Custom Methods"
		
		
		#endregion
					
	}//end class
} // end namespace