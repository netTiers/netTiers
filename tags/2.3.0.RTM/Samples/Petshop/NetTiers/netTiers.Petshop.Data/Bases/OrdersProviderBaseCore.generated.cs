#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="OrdersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class OrdersProviderBaseCore : EntityProviderBase<netTiers.Petshop.Entities.Orders, netTiers.Petshop.Entities.OrdersKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, netTiers.Petshop.Entities.OrdersKey key)
		{
			return Delete(transactionManager, key.OrderId, ((key.Entity != null) ? key.Entity.Timestamp : new byte[0]));
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="orderId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 orderId, byte[] timestamp)
		{
			return Delete(null, orderId, timestamp);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId">. Primary Key.</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 orderId, byte[] timestamp);		
		
		#endregion
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		FK_Orders_Account Description: 
		/// </summary>
		/// <param name="accountId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByAccountId(System.Guid accountId)
		{
			int count = -1;
			return GetByAccountId(accountId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		FK_Orders_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Orders> GetByAccountId(TransactionManager transactionManager, System.Guid accountId)
		{
			int count = -1;
			return GetByAccountId(transactionManager, accountId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		FK_Orders_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByAccountId(TransactionManager transactionManager, System.Guid accountId, int start, int pageLength)
		{
			int count = -1;
			return GetByAccountId(transactionManager, accountId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		fK_Orders_Account Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByAccountId(System.Guid accountId, int start, int pageLength)
		{
			int count =  -1;
			return GetByAccountId(null, accountId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		fK_Orders_Account Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="accountId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByAccountId(System.Guid accountId, int start, int pageLength,out int count)
		{
			return GetByAccountId(null, accountId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Account key.
		///		FK_Orders_Account Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="accountId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Orders> GetByAccountId(TransactionManager transactionManager, System.Guid accountId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		FK_Orders_Courier Description: 
		/// </summary>
		/// <param name="courierId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCourierId(System.Guid courierId)
		{
			int count = -1;
			return GetByCourierId(courierId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		FK_Orders_Courier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Orders> GetByCourierId(TransactionManager transactionManager, System.Guid courierId)
		{
			int count = -1;
			return GetByCourierId(transactionManager, courierId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		FK_Orders_Courier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCourierId(TransactionManager transactionManager, System.Guid courierId, int start, int pageLength)
		{
			int count = -1;
			return GetByCourierId(transactionManager, courierId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		fK_Orders_Courier Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="courierId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCourierId(System.Guid courierId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCourierId(null, courierId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		fK_Orders_Courier Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="courierId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCourierId(System.Guid courierId, int start, int pageLength,out int count)
		{
			return GetByCourierId(null, courierId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_Courier key.
		///		FK_Orders_Courier Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="courierId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Orders> GetByCourierId(TransactionManager transactionManager, System.Guid courierId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		FK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="creditCardId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(System.Guid creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(creditCardId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		FK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		/// <remarks></remarks>
		public netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(TransactionManager transactionManager, System.Guid creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, creditCardId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		FK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(TransactionManager transactionManager, System.Guid creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		fK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="creditCardId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(System.Guid creditCardId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCreditCardId(null, creditCardId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		fK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="creditCardId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(System.Guid creditCardId, int start, int pageLength,out int count)
		{
			return GetByCreditCardId(null, creditCardId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Orders_CreditCard key.
		///		FK_Orders_CreditCard Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="creditCardId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.Orders objects.</returns>
		public abstract netTiers.Petshop.Entities.TList<Orders> GetByCreditCardId(TransactionManager transactionManager, System.Guid creditCardId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override netTiers.Petshop.Entities.Orders Get(TransactionManager transactionManager, netTiers.Petshop.Entities.OrdersKey key, int start, int pageLength)
		{
			return GetByOrderId(transactionManager, key.OrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public netTiers.Petshop.Entities.Orders GetByOrderId(System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(null,orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public netTiers.Petshop.Entities.Orders GetByOrderId(System.Int32 orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(null, orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public netTiers.Petshop.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 orderId)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public netTiers.Petshop.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength)
		{
			int count = -1;
			return GetByOrderId(transactionManager, orderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public netTiers.Petshop.Entities.Orders GetByOrderId(System.Int32 orderId, int start, int pageLength, out int count)
		{
			return GetByOrderId(null, orderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Orders__0CBAE877 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.Orders"/> class.</returns>
		public abstract netTiers.Petshop.Entities.Orders GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a netTiers.Petshop.Entities.TList&lt;Orders&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="netTiers.Petshop.Entities.TList&lt;Orders&gt;"/></returns>
		public static netTiers.Petshop.Entities.TList<Orders> Fill(IDataReader reader, netTiers.Petshop.Entities.TList<Orders> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				netTiers.Petshop.Entities.Orders c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"Orders" 
							+ (reader.IsDBNull(reader.GetOrdinal("OrderId"))?(int)0:(System.Int32)reader["OrderId"]).ToString();

					c = EntityManager.LocateOrCreate<Orders>(
						key.ToString(), // EntityTrackingKey 
						"Orders",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new netTiers.Petshop.Entities.Orders();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.OrderId = (System.Int32)reader["OrderId"];
					c.AccountId = (System.Guid)reader["AccountId"];
					c.OrderDate = (System.DateTime)reader["OrderDate"];
					c.ShipAddr1 = (System.String)reader["ShipAddr1"];
					c.ShipAddr2 = (reader.IsDBNull(reader.GetOrdinal("ShipAddr2")))?null:(System.String)reader["ShipAddr2"];
					c.ShipCity = (System.String)reader["ShipCity"];
					c.ShipState = (System.String)reader["ShipState"];
					c.ShipZip = (System.String)reader["ShipZip"];
					c.ShipCountry = (reader.IsDBNull(reader.GetOrdinal("ShipCountry")))?null:(System.String)reader["ShipCountry"];
					c.BillAddr1 = (System.String)reader["BillAddr1"];
					c.BillAddr2 = (reader.IsDBNull(reader.GetOrdinal("BillAddr2")))?null:(System.String)reader["BillAddr2"];
					c.BillCity = (System.String)reader["BillCity"];
					c.BillState = (System.String)reader["BillState"];
					c.BillZip = (System.String)reader["BillZip"];
					c.BillCountry = (reader.IsDBNull(reader.GetOrdinal("BillCountry")))?null:(System.String)reader["BillCountry"];
					c.CourierId = (System.Guid)reader["CourierId"];
					c.TotalPrice = (reader.IsDBNull(reader.GetOrdinal("TotalPrice")))?null:(System.Decimal?)reader["TotalPrice"];
					c.BillToFirstName = (System.String)reader["BillToFirstName"];
					c.BillToLastName = (System.String)reader["BillToLastName"];
					c.ShipToFirstName = (System.String)reader["ShipToFirstName"];
					c.ShipToLastName = (System.String)reader["ShipToLastName"];
					c.CreditCardId = (System.Guid)reader["CreditCardId"];
					c.Locale = (reader.IsDBNull(reader.GetOrdinal("Locale")))?null:(System.String)reader["Locale"];
					c.Timestamp = (System.Byte[])reader["Timestamp"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Orders"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Orders"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, netTiers.Petshop.Entities.Orders entity)
		{
			if (!reader.Read()) return;
			
			entity.OrderId = (System.Int32)reader["OrderId"];
			entity.AccountId = (System.Guid)reader["AccountId"];
			entity.OrderDate = (System.DateTime)reader["OrderDate"];
			entity.ShipAddr1 = (System.String)reader["ShipAddr1"];
			entity.ShipAddr2 = (reader.IsDBNull(reader.GetOrdinal("ShipAddr2")))?null:(System.String)reader["ShipAddr2"];
			entity.ShipCity = (System.String)reader["ShipCity"];
			entity.ShipState = (System.String)reader["ShipState"];
			entity.ShipZip = (System.String)reader["ShipZip"];
			entity.ShipCountry = (reader.IsDBNull(reader.GetOrdinal("ShipCountry")))?null:(System.String)reader["ShipCountry"];
			entity.BillAddr1 = (System.String)reader["BillAddr1"];
			entity.BillAddr2 = (reader.IsDBNull(reader.GetOrdinal("BillAddr2")))?null:(System.String)reader["BillAddr2"];
			entity.BillCity = (System.String)reader["BillCity"];
			entity.BillState = (System.String)reader["BillState"];
			entity.BillZip = (System.String)reader["BillZip"];
			entity.BillCountry = (reader.IsDBNull(reader.GetOrdinal("BillCountry")))?null:(System.String)reader["BillCountry"];
			entity.CourierId = (System.Guid)reader["CourierId"];
			entity.TotalPrice = (reader.IsDBNull(reader.GetOrdinal("TotalPrice")))?null:(System.Decimal?)reader["TotalPrice"];
			entity.BillToFirstName = (System.String)reader["BillToFirstName"];
			entity.BillToLastName = (System.String)reader["BillToLastName"];
			entity.ShipToFirstName = (System.String)reader["ShipToFirstName"];
			entity.ShipToLastName = (System.String)reader["ShipToLastName"];
			entity.CreditCardId = (System.Guid)reader["CreditCardId"];
			entity.Locale = (reader.IsDBNull(reader.GetOrdinal("Locale")))?null:(System.String)reader["Locale"];
			entity.Timestamp = (System.Byte[])reader["Timestamp"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="netTiers.Petshop.Entities.Orders"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Orders"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, netTiers.Petshop.Entities.Orders entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.OrderId = (System.Int32)dataRow["OrderId"];
			entity.AccountId = (System.Guid)dataRow["AccountId"];
			entity.OrderDate = (System.DateTime)dataRow["OrderDate"];
			entity.ShipAddr1 = (System.String)dataRow["ShipAddr1"];
			entity.ShipAddr2 = (Convert.IsDBNull(dataRow["ShipAddr2"]))?null:(System.String)dataRow["ShipAddr2"];
			entity.ShipCity = (System.String)dataRow["ShipCity"];
			entity.ShipState = (System.String)dataRow["ShipState"];
			entity.ShipZip = (System.String)dataRow["ShipZip"];
			entity.ShipCountry = (Convert.IsDBNull(dataRow["ShipCountry"]))?null:(System.String)dataRow["ShipCountry"];
			entity.BillAddr1 = (System.String)dataRow["BillAddr1"];
			entity.BillAddr2 = (Convert.IsDBNull(dataRow["BillAddr2"]))?null:(System.String)dataRow["BillAddr2"];
			entity.BillCity = (System.String)dataRow["BillCity"];
			entity.BillState = (System.String)dataRow["BillState"];
			entity.BillZip = (System.String)dataRow["BillZip"];
			entity.BillCountry = (Convert.IsDBNull(dataRow["BillCountry"]))?null:(System.String)dataRow["BillCountry"];
			entity.CourierId = (System.Guid)dataRow["CourierId"];
			entity.TotalPrice = (Convert.IsDBNull(dataRow["TotalPrice"]))?null:(System.Decimal?)dataRow["TotalPrice"];
			entity.BillToFirstName = (System.String)dataRow["BillToFirstName"];
			entity.BillToLastName = (System.String)dataRow["BillToLastName"];
			entity.ShipToFirstName = (System.String)dataRow["ShipToFirstName"];
			entity.ShipToLastName = (System.String)dataRow["ShipToLastName"];
			entity.CreditCardId = (System.Guid)dataRow["CreditCardId"];
			entity.Locale = (Convert.IsDBNull(dataRow["Locale"]))?null:(System.String)dataRow["Locale"];
			entity.Timestamp = (System.Byte[])dataRow["Timestamp"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="netTiers.Petshop.Entities.Orders"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Orders Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, netTiers.Petshop.Entities.Orders entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region AccountIdSource	
			if (CanDeepLoad(entity, "Account", "AccountIdSource", deepLoadType, innerList) 
				&& entity.AccountIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.AccountId;
				Account tmpEntity = EntityManager.LocateEntity<Account>(EntityLocator.ConstructKeyFromPkItems(typeof(Account), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.AccountIdSource = tmpEntity;
				else
					entity.AccountIdSource = DataRepository.AccountProvider.GetById(entity.AccountId);
			
				if (deep && entity.AccountIdSource != null)
				{
					DataRepository.AccountProvider.DeepLoad(transactionManager, entity.AccountIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion AccountIdSource

			#region CourierIdSource	
			if (CanDeepLoad(entity, "Courier", "CourierIdSource", deepLoadType, innerList) 
				&& entity.CourierIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CourierId;
				Courier tmpEntity = EntityManager.LocateEntity<Courier>(EntityLocator.ConstructKeyFromPkItems(typeof(Courier), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CourierIdSource = tmpEntity;
				else
					entity.CourierIdSource = DataRepository.CourierProvider.GetByCourierId(entity.CourierId);
			
				if (deep && entity.CourierIdSource != null)
				{
					DataRepository.CourierProvider.DeepLoad(transactionManager, entity.CourierIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CourierIdSource

			#region CreditCardIdSource	
			if (CanDeepLoad(entity, "CreditCard", "CreditCardIdSource", deepLoadType, innerList) 
				&& entity.CreditCardIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CreditCardId;
				CreditCard tmpEntity = EntityManager.LocateEntity<CreditCard>(EntityLocator.ConstructKeyFromPkItems(typeof(CreditCard), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CreditCardIdSource = tmpEntity;
				else
					entity.CreditCardIdSource = DataRepository.CreditCardProvider.GetById(entity.CreditCardId);
			
				if (deep && entity.CreditCardIdSource != null)
				{
					DataRepository.CreditCardProvider.DeepLoad(transactionManager, entity.CreditCardIdSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion CreditCardIdSource
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByOrderId methods when available
			
			#region OrderStatusCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<OrderStatus>", "OrderStatusCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'OrderStatusCollection' loaded.");
				#endif 

				entity.OrderStatusCollection = DataRepository.OrderStatusProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.OrderStatusCollection.Count > 0)
				{
					DataRepository.OrderStatusProvider.DeepLoad(transactionManager, entity.OrderStatusCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
			
			#region LineItemCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<LineItem>", "LineItemCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'LineItemCollection' loaded.");
				#endif 

				entity.LineItemCollection = DataRepository.LineItemProvider.GetByOrderId(transactionManager, entity.OrderId);

				if (deep && entity.LineItemCollection.Count > 0)
				{
					DataRepository.LineItemProvider.DeepLoad(transactionManager, entity.LineItemCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the netTiers.Petshop.Entities.Orders object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">netTiers.Petshop.Entities.Orders instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">netTiers.Petshop.Entities.Orders Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, netTiers.Petshop.Entities.Orders entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region AccountIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Account"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Account"] == null))
			{
				if (entity.AccountIdSource != null )
				{			
					DataRepository.AccountProvider.Save(transactionManager, entity.AccountIdSource);
				}
			}
			#endregion 
			
			#region CourierIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["Courier"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" Courier"] == null))
			{
				if (entity.CourierIdSource != null )
				{			
					DataRepository.CourierProvider.Save(transactionManager, entity.CourierIdSource);
				}
			}
			#endregion 
			
			#region CreditCardIdSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["CreditCard"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList[" CreditCard"] == null))
			{
				if (entity.CreditCardIdSource != null )
				{			
					DataRepository.CreditCardProvider.Save(transactionManager, entity.CreditCardIdSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties


			#region List<OrderStatus>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<OrderStatus>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<OrderStatus>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(OrderStatus child in entity.OrderStatusCollection)
			{
					child.OrderId = entity.OrderId;			}
			
			if (entity.OrderStatusCollection.Count > 0)
				DataRepository.OrderStatusProvider.DeepSave(transactionManager, entity.OrderStatusCollection, deepSaveType, childTypes);
			} 
			#endregion 

			#region List<LineItem>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<LineItem>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<LineItem>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(LineItem child in entity.LineItemCollection)
			{
					child.OrderId = entity.OrderId;			}
			
			if (entity.LineItemCollection.Count > 0)
				DataRepository.LineItemProvider.DeepSave(transactionManager, entity.LineItemCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region OrdersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>netTiers.Petshop.Entities.Orders</c>
	///</summary>
	public enum OrdersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Account</c> at AccountIdSource
		///</summary>
		[ChildEntityType(typeof(Account))]
		Account,
			
		///<summary>
		/// Composite Property for <c>Courier</c> at CourierIdSource
		///</summary>
		[ChildEntityType(typeof(Courier))]
		Courier,
			
		///<summary>
		/// Composite Property for <c>CreditCard</c> at CreditCardIdSource
		///</summary>
		[ChildEntityType(typeof(CreditCard))]
		CreditCard,
	
		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for OrderStatusCollection
		///</summary>
		[ChildEntityType(typeof(TList<OrderStatus>))]
		OrderStatusCollection,

		///<summary>
		/// Collection of <c>Orders</c> as OneToMany for LineItemCollection
		///</summary>
		[ChildEntityType(typeof(TList<LineItem>))]
		LineItemCollection,
	}
	
	#endregion OrdersChildEntityTypes
	
	#region OrdersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Orders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class OrdersFilterBuilder : SqlFilterBuilder<OrdersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		public OrdersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public OrdersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the OrdersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public OrdersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion OrdersFilterBuilder
} // end namespace
