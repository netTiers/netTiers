#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="SalesOrderHeaderProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class SalesOrderHeaderProviderBaseCore : EntityProviderBase<Nettiers.AdventureWorks.Entities.SalesOrderHeader, Nettiers.AdventureWorks.Entities.SalesOrderHeaderKey>
	{		
		#region Get from Many To Many Relationship Functions
		#region GetBySalesReasonIdFromSalesOrderHeaderSalesReason
		
		/// <summary>
		///		Gets SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <returns>Returns a typed collection of SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonIdFromSalesOrderHeaderSalesReason(null,_salesReasonId, 0, int.MaxValue, out count);
			
		}
		
		/// <summary>
		///		Gets Nettiers.AdventureWorks.Entities.SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(System.Int32 _salesReasonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesReasonIdFromSalesOrderHeaderSalesReason(null, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager, System.Int32 _salesReasonId)
		{
			int count = -1;
			return GetBySalesReasonIdFromSalesOrderHeaderSalesReason(transactionManager, _salesReasonId, 0, int.MaxValue, out count);
		}
		
		
		/// <summary>
		///		Gets SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager, System.Int32 _salesReasonId,int start, int pageLength)
		{
			int count = -1;
			return GetBySalesReasonIdFromSalesOrderHeaderSalesReason(transactionManager, _salesReasonId, start, pageLength, out count);
		}
		
		/// <summary>
		///		Gets SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(System.Int32 _salesReasonId,int start, int pageLength, out int count)
		{
			
			return GetBySalesReasonIdFromSalesOrderHeaderSalesReason(null, _salesReasonId, start, pageLength, out count);
		}


		/// <summary>
		///		Gets SalesOrderHeader objects from the datasource by SalesReasonID in the
		///		SalesOrderHeaderSalesReason table. Table SalesOrderHeader is related to table SalesReason
		///		through the (M:N) relationship defined in the SalesOrderHeaderSalesReason table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <param name="_salesReasonId">Primary key. Foreign key to SalesReason.SalesReasonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a TList of SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetBySalesReasonIdFromSalesOrderHeaderSalesReason(TransactionManager transactionManager,System.Int32 _salesReasonId, int start, int pageLength, out int count);
		
		#endregion GetBySalesReasonIdFromSalesOrderHeaderSalesReason
		
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderKey key)
		{
			return Delete(transactionManager, key.SalesOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_salesOrderId">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _salesOrderId)
		{
			return Delete(null, _salesOrderId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key.. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _salesOrderId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		FK_SalesOrderHeader_Address_BillToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByBillToAddressId(System.Int32 _billToAddressId)
		{
			int count = -1;
			return GetByBillToAddressId(_billToAddressId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		FK_SalesOrderHeader_Address_BillToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByBillToAddressId(TransactionManager transactionManager, System.Int32 _billToAddressId)
		{
			int count = -1;
			return GetByBillToAddressId(transactionManager, _billToAddressId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		FK_SalesOrderHeader_Address_BillToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByBillToAddressId(TransactionManager transactionManager, System.Int32 _billToAddressId, int start, int pageLength)
		{
			int count = -1;
			return GetByBillToAddressId(transactionManager, _billToAddressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		fkSalesOrderHeaderAddressBillToAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByBillToAddressId(System.Int32 _billToAddressId, int start, int pageLength)
		{
			int count =  -1;
			return GetByBillToAddressId(null, _billToAddressId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		fkSalesOrderHeaderAddressBillToAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByBillToAddressId(System.Int32 _billToAddressId, int start, int pageLength,out int count)
		{
			return GetByBillToAddressId(null, _billToAddressId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_BillToAddressID key.
		///		FK_SalesOrderHeader_Address_BillToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_billToAddressId">Customer billing address. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByBillToAddressId(TransactionManager transactionManager, System.Int32 _billToAddressId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		FK_SalesOrderHeader_Address_ShipToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipToAddressId(System.Int32 _shipToAddressId)
		{
			int count = -1;
			return GetByShipToAddressId(_shipToAddressId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		FK_SalesOrderHeader_Address_ShipToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByShipToAddressId(TransactionManager transactionManager, System.Int32 _shipToAddressId)
		{
			int count = -1;
			return GetByShipToAddressId(transactionManager, _shipToAddressId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		FK_SalesOrderHeader_Address_ShipToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipToAddressId(TransactionManager transactionManager, System.Int32 _shipToAddressId, int start, int pageLength)
		{
			int count = -1;
			return GetByShipToAddressId(transactionManager, _shipToAddressId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		fkSalesOrderHeaderAddressShipToAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipToAddressId(System.Int32 _shipToAddressId, int start, int pageLength)
		{
			int count =  -1;
			return GetByShipToAddressId(null, _shipToAddressId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		fkSalesOrderHeaderAddressShipToAddressId Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipToAddressId(System.Int32 _shipToAddressId, int start, int pageLength,out int count)
		{
			return GetByShipToAddressId(null, _shipToAddressId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Address_ShipToAddressID key.
		///		FK_SalesOrderHeader_Address_ShipToAddressID Description: Foreign key constraint referencing Address.AddressID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipToAddressId">Customer shipping address. Foreign key to Address.AddressID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByShipToAddressId(TransactionManager transactionManager, System.Int32 _shipToAddressId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		FK_SalesOrderHeader_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByContactId(System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(_contactId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		FK_SalesOrderHeader_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		FK_SalesOrderHeader_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength)
		{
			int count = -1;
			return GetByContactId(transactionManager, _contactId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		fkSalesOrderHeaderContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByContactId(System.Int32 _contactId, int start, int pageLength)
		{
			int count =  -1;
			return GetByContactId(null, _contactId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		fkSalesOrderHeaderContactContactId Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByContactId(System.Int32 _contactId, int start, int pageLength,out int count)
		{
			return GetByContactId(null, _contactId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_Contact_ContactID key.
		///		FK_SalesOrderHeader_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Customer contact identification number. Foreign key to Contact.ContactID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		FK_SalesOrderHeader_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCreditCardId(System.Int32? _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(_creditCardId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		FK_SalesOrderHeader_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByCreditCardId(TransactionManager transactionManager, System.Int32? _creditCardId)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		FK_SalesOrderHeader_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCreditCardId(TransactionManager transactionManager, System.Int32? _creditCardId, int start, int pageLength)
		{
			int count = -1;
			return GetByCreditCardId(transactionManager, _creditCardId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		fkSalesOrderHeaderCreditCardCreditCardId Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCreditCardId(System.Int32? _creditCardId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCreditCardId(null, _creditCardId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		fkSalesOrderHeaderCreditCardCreditCardId Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCreditCardId(System.Int32? _creditCardId, int start, int pageLength,out int count)
		{
			return GetByCreditCardId(null, _creditCardId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CreditCard_CreditCardID key.
		///		FK_SalesOrderHeader_CreditCard_CreditCardID Description: Foreign key constraint referencing CreditCard.CreditCardID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_creditCardId">Credit card identification number. Foreign key to CreditCard.CreditCardID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByCreditCardId(TransactionManager transactionManager, System.Int32? _creditCardId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		FK_SalesOrderHeader_CurrencyRate_CurrencyRateID Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCurrencyRateId(System.Int32? _currencyRateId)
		{
			int count = -1;
			return GetByCurrencyRateId(_currencyRateId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		FK_SalesOrderHeader_CurrencyRate_CurrencyRateID Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByCurrencyRateId(TransactionManager transactionManager, System.Int32? _currencyRateId)
		{
			int count = -1;
			return GetByCurrencyRateId(transactionManager, _currencyRateId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		FK_SalesOrderHeader_CurrencyRate_CurrencyRateID Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCurrencyRateId(TransactionManager transactionManager, System.Int32? _currencyRateId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurrencyRateId(transactionManager, _currencyRateId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		fkSalesOrderHeaderCurrencyRateCurrencyRateId Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCurrencyRateId(System.Int32? _currencyRateId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurrencyRateId(null, _currencyRateId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		fkSalesOrderHeaderCurrencyRateCurrencyRateId Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByCurrencyRateId(System.Int32? _currencyRateId, int start, int pageLength,out int count)
		{
			return GetByCurrencyRateId(null, _currencyRateId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_CurrencyRate_CurrencyRateID key.
		///		FK_SalesOrderHeader_CurrencyRate_CurrencyRateID Description: Foreign key constraint referencing CurrencyRate.CurrencyRateID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_currencyRateId">Currency exchange rate used. Foreign key to CurrencyRate.CurrencyRateID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByCurrencyRateId(TransactionManager transactionManager, System.Int32? _currencyRateId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		FK_SalesOrderHeader_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByTerritoryId(System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(_territoryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		FK_SalesOrderHeader_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		FK_SalesOrderHeader_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength)
		{
			int count = -1;
			return GetByTerritoryId(transactionManager, _territoryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		fkSalesOrderHeaderSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByTerritoryId(null, _territoryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		fkSalesOrderHeaderSalesTerritoryTerritoryId Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByTerritoryId(System.Int32? _territoryId, int start, int pageLength,out int count)
		{
			return GetByTerritoryId(null, _territoryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_SalesTerritory_TerritoryID key.
		///		FK_SalesOrderHeader_SalesTerritory_TerritoryID Description: Foreign key constraint referencing SalesTerritory.TerritoryID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_territoryId">Territory in which the sale was made. Foreign key to SalesTerritory.SalesTerritoryID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByTerritoryId(TransactionManager transactionManager, System.Int32? _territoryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_SalesOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(_shipMethodId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_SalesOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		/// <remarks></remarks>
		public TList<SalesOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_SalesOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count = -1;
			return GetByShipMethodId(transactionManager, _shipMethodId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		fkSalesOrderHeaderShipMethodShipMethodId Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength)
		{
			int count =  -1;
			return GetByShipMethodId(null, _shipMethodId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		fkSalesOrderHeaderShipMethodShipMethodId Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public TList<SalesOrderHeader> GetByShipMethodId(System.Int32 _shipMethodId, int start, int pageLength,out int count)
		{
			return GetByShipMethodId(null, _shipMethodId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_SalesOrderHeader_ShipMethod_ShipMethodID key.
		///		FK_SalesOrderHeader_ShipMethod_ShipMethodID Description: Foreign key constraint referencing ShipMethod.ShipMethodID.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_shipMethodId">Shipping method. Foreign key to ShipMethod.ShipMethodID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.SalesOrderHeader objects.</returns>
		public abstract TList<SalesOrderHeader> GetByShipMethodId(TransactionManager transactionManager, System.Int32 _shipMethodId, int start, int pageLength, out int count);
		
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
		public override Nettiers.AdventureWorks.Entities.SalesOrderHeader Get(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeaderKey key, int start, int pageLength)
		{
			return GetBySalesOrderId(transactionManager, key.SalesOrderId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(null,_rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength)
		{
			int count = -1;
			return GetByRowguid(transactionManager, _rowguid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(System.Guid _rowguid, int start, int pageLength, out int count)
		{
			return GetByRowguid(null, _rowguid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_rowguid index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderHeader GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(System.String _salesOrderNumber)
		{
			int count = -1;
			return GetBySalesOrderNumber(null,_salesOrderNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(System.String _salesOrderNumber, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderNumber(null, _salesOrderNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(TransactionManager transactionManager, System.String _salesOrderNumber)
		{
			int count = -1;
			return GetBySalesOrderNumber(transactionManager, _salesOrderNumber, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(TransactionManager transactionManager, System.String _salesOrderNumber, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderNumber(transactionManager, _salesOrderNumber, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(System.String _salesOrderNumber, int start, int pageLength, out int count)
		{
			return GetBySalesOrderNumber(null, _salesOrderNumber, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_SalesOrderHeader_SalesOrderNumber index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderNumber">Unique sales order identification number.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderNumber(TransactionManager transactionManager, System.String _salesOrderNumber, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetByCustomerId(System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(null,_customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetByCustomerId(System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomerId(transactionManager, _customerId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetByCustomerId(System.Int32 _customerId, int start, int pageLength, out int count)
		{
			return GetByCustomerId(null, _customerId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_CustomerID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customerId">Customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public abstract TList<SalesOrderHeader> GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetBySalesPersonId(System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(null,_salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesPersonId(transactionManager, _salesPersonId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public TList<SalesOrderHeader> GetBySalesPersonId(System.Int32? _salesPersonId, int start, int pageLength, out int count)
		{
			return GetBySalesPersonId(null, _salesPersonId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the IX_SalesOrderHeader_SalesPersonID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesPersonId">Sales person who created the sales order. Foreign key to SalesPerson.SalePersonID.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="TList&lt;SalesOrderHeader&gt;"/> class.</returns>
		public abstract TList<SalesOrderHeader> GetBySalesPersonId(TransactionManager transactionManager, System.Int32? _salesPersonId, int start, int pageLength, out int count);
						
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(null,_salesOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength)
		{
			int count = -1;
			return GetBySalesOrderId(transactionManager, _salesOrderId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(System.Int32 _salesOrderId, int start, int pageLength, out int count)
		{
			return GetBySalesOrderId(null, _salesOrderId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_SalesOrderHeader_SalesOrderID index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_salesOrderId">Primary key.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> class.</returns>
		public abstract Nettiers.AdventureWorks.Entities.SalesOrderHeader GetBySalesOrderId(TransactionManager transactionManager, System.Int32 _salesOrderId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;SalesOrderHeader&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;SalesOrderHeader&gt;"/></returns>
		public static TList<SalesOrderHeader> Fill(IDataReader reader, TList<SalesOrderHeader> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
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
				
				Nettiers.AdventureWorks.Entities.SalesOrderHeader c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("SalesOrderHeader")
					.Append("|").Append((System.Int32)reader[((int)SalesOrderHeaderColumn.SalesOrderId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<SalesOrderHeader>(
					key.ToString(), // EntityTrackingKey
					"SalesOrderHeader",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new Nettiers.AdventureWorks.Entities.SalesOrderHeader();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.SalesOrderId = (System.Int32)reader[((int)SalesOrderHeaderColumn.SalesOrderId - 1)];
					c.RevisionNumber = (System.Byte)reader[((int)SalesOrderHeaderColumn.RevisionNumber - 1)];
					c.OrderDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.OrderDate - 1)];
					c.DueDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.DueDate - 1)];
					c.ShipDate = (reader.IsDBNull(((int)SalesOrderHeaderColumn.ShipDate - 1)))?null:(System.DateTime?)reader[((int)SalesOrderHeaderColumn.ShipDate - 1)];
					c.Status = (System.Byte)reader[((int)SalesOrderHeaderColumn.Status - 1)];
					c.OnlineOrderFlag = (System.Boolean)reader[((int)SalesOrderHeaderColumn.OnlineOrderFlag - 1)];
					c.SalesOrderNumber = (System.String)reader[((int)SalesOrderHeaderColumn.SalesOrderNumber - 1)];
					c.PurchaseOrderNumber = (reader.IsDBNull(((int)SalesOrderHeaderColumn.PurchaseOrderNumber - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.PurchaseOrderNumber - 1)];
					c.AccountNumber = (reader.IsDBNull(((int)SalesOrderHeaderColumn.AccountNumber - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.AccountNumber - 1)];
					c.CustomerId = (System.Int32)reader[((int)SalesOrderHeaderColumn.CustomerId - 1)];
					c.ContactId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ContactId - 1)];
					c.SalesPersonId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.SalesPersonId - 1)];
					c.TerritoryId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.TerritoryId - 1)];
					c.BillToAddressId = (System.Int32)reader[((int)SalesOrderHeaderColumn.BillToAddressId - 1)];
					c.ShipToAddressId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ShipToAddressId - 1)];
					c.ShipMethodId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ShipMethodId - 1)];
					c.CreditCardId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CreditCardId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.CreditCardId - 1)];
					c.CreditCardApprovalCode = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CreditCardApprovalCode - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.CreditCardApprovalCode - 1)];
					c.CurrencyRateId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CurrencyRateId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.CurrencyRateId - 1)];
					c.SubTotal = (System.Decimal)reader[((int)SalesOrderHeaderColumn.SubTotal - 1)];
					c.TaxAmt = (System.Decimal)reader[((int)SalesOrderHeaderColumn.TaxAmt - 1)];
					c.Freight = (System.Decimal)reader[((int)SalesOrderHeaderColumn.Freight - 1)];
					c.TotalDue = (System.Decimal)reader[((int)SalesOrderHeaderColumn.TotalDue - 1)];
					c.Comment = (reader.IsDBNull(((int)SalesOrderHeaderColumn.Comment - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.Comment - 1)];
					c.Rowguid = (System.Guid)reader[((int)SalesOrderHeaderColumn.Rowguid - 1)];
					c.ModifiedDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.ModifiedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, Nettiers.AdventureWorks.Entities.SalesOrderHeader entity)
		{
			if (!reader.Read()) return;
			
			entity.SalesOrderId = (System.Int32)reader[((int)SalesOrderHeaderColumn.SalesOrderId - 1)];
			entity.RevisionNumber = (System.Byte)reader[((int)SalesOrderHeaderColumn.RevisionNumber - 1)];
			entity.OrderDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.OrderDate - 1)];
			entity.DueDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.DueDate - 1)];
			entity.ShipDate = (reader.IsDBNull(((int)SalesOrderHeaderColumn.ShipDate - 1)))?null:(System.DateTime?)reader[((int)SalesOrderHeaderColumn.ShipDate - 1)];
			entity.Status = (System.Byte)reader[((int)SalesOrderHeaderColumn.Status - 1)];
			entity.OnlineOrderFlag = (System.Boolean)reader[((int)SalesOrderHeaderColumn.OnlineOrderFlag - 1)];
			entity.SalesOrderNumber = (System.String)reader[((int)SalesOrderHeaderColumn.SalesOrderNumber - 1)];
			entity.PurchaseOrderNumber = (reader.IsDBNull(((int)SalesOrderHeaderColumn.PurchaseOrderNumber - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.PurchaseOrderNumber - 1)];
			entity.AccountNumber = (reader.IsDBNull(((int)SalesOrderHeaderColumn.AccountNumber - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.AccountNumber - 1)];
			entity.CustomerId = (System.Int32)reader[((int)SalesOrderHeaderColumn.CustomerId - 1)];
			entity.ContactId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ContactId - 1)];
			entity.SalesPersonId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.SalesPersonId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.SalesPersonId - 1)];
			entity.TerritoryId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.TerritoryId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.TerritoryId - 1)];
			entity.BillToAddressId = (System.Int32)reader[((int)SalesOrderHeaderColumn.BillToAddressId - 1)];
			entity.ShipToAddressId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ShipToAddressId - 1)];
			entity.ShipMethodId = (System.Int32)reader[((int)SalesOrderHeaderColumn.ShipMethodId - 1)];
			entity.CreditCardId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CreditCardId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.CreditCardId - 1)];
			entity.CreditCardApprovalCode = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CreditCardApprovalCode - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.CreditCardApprovalCode - 1)];
			entity.CurrencyRateId = (reader.IsDBNull(((int)SalesOrderHeaderColumn.CurrencyRateId - 1)))?null:(System.Int32?)reader[((int)SalesOrderHeaderColumn.CurrencyRateId - 1)];
			entity.SubTotal = (System.Decimal)reader[((int)SalesOrderHeaderColumn.SubTotal - 1)];
			entity.TaxAmt = (System.Decimal)reader[((int)SalesOrderHeaderColumn.TaxAmt - 1)];
			entity.Freight = (System.Decimal)reader[((int)SalesOrderHeaderColumn.Freight - 1)];
			entity.TotalDue = (System.Decimal)reader[((int)SalesOrderHeaderColumn.TotalDue - 1)];
			entity.Comment = (reader.IsDBNull(((int)SalesOrderHeaderColumn.Comment - 1)))?null:(System.String)reader[((int)SalesOrderHeaderColumn.Comment - 1)];
			entity.Rowguid = (System.Guid)reader[((int)SalesOrderHeaderColumn.Rowguid - 1)];
			entity.ModifiedDate = (System.DateTime)reader[((int)SalesOrderHeaderColumn.ModifiedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, Nettiers.AdventureWorks.Entities.SalesOrderHeader entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.SalesOrderId = (System.Int32)dataRow["SalesOrderID"];
			entity.RevisionNumber = (System.Byte)dataRow["RevisionNumber"];
			entity.OrderDate = (System.DateTime)dataRow["OrderDate"];
			entity.DueDate = (System.DateTime)dataRow["DueDate"];
			entity.ShipDate = Convert.IsDBNull(dataRow["ShipDate"]) ? null : (System.DateTime?)dataRow["ShipDate"];
			entity.Status = (System.Byte)dataRow["Status"];
			entity.OnlineOrderFlag = (System.Boolean)dataRow["OnlineOrderFlag"];
			entity.SalesOrderNumber = (System.String)dataRow["SalesOrderNumber"];
			entity.PurchaseOrderNumber = Convert.IsDBNull(dataRow["PurchaseOrderNumber"]) ? null : (System.String)dataRow["PurchaseOrderNumber"];
			entity.AccountNumber = Convert.IsDBNull(dataRow["AccountNumber"]) ? null : (System.String)dataRow["AccountNumber"];
			entity.CustomerId = (System.Int32)dataRow["CustomerID"];
			entity.ContactId = (System.Int32)dataRow["ContactID"];
			entity.SalesPersonId = Convert.IsDBNull(dataRow["SalesPersonID"]) ? null : (System.Int32?)dataRow["SalesPersonID"];
			entity.TerritoryId = Convert.IsDBNull(dataRow["TerritoryID"]) ? null : (System.Int32?)dataRow["TerritoryID"];
			entity.BillToAddressId = (System.Int32)dataRow["BillToAddressID"];
			entity.ShipToAddressId = (System.Int32)dataRow["ShipToAddressID"];
			entity.ShipMethodId = (System.Int32)dataRow["ShipMethodID"];
			entity.CreditCardId = Convert.IsDBNull(dataRow["CreditCardID"]) ? null : (System.Int32?)dataRow["CreditCardID"];
			entity.CreditCardApprovalCode = Convert.IsDBNull(dataRow["CreditCardApprovalCode"]) ? null : (System.String)dataRow["CreditCardApprovalCode"];
			entity.CurrencyRateId = Convert.IsDBNull(dataRow["CurrencyRateID"]) ? null : (System.Int32?)dataRow["CurrencyRateID"];
			entity.SubTotal = (System.Decimal)dataRow["SubTotal"];
			entity.TaxAmt = (System.Decimal)dataRow["TaxAmt"];
			entity.Freight = (System.Decimal)dataRow["Freight"];
			entity.TotalDue = (System.Decimal)dataRow["TotalDue"];
			entity.Comment = Convert.IsDBNull(dataRow["Comment"]) ? null : (System.String)dataRow["Comment"];
			entity.Rowguid = (System.Guid)dataRow["rowguid"];
			entity.ModifiedDate = (System.DateTime)dataRow["ModifiedDate"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="Nettiers.AdventureWorks.Entities.SalesOrderHeader"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderHeader Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeader entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region BillToAddressIdSource	
			if (CanDeepLoad(entity, "Address|BillToAddressIdSource", deepLoadType, innerList) 
				&& entity.BillToAddressIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.BillToAddressId;
				Address tmpEntity = EntityManager.LocateEntity<Address>(EntityLocator.ConstructKeyFromPkItems(typeof(Address), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.BillToAddressIdSource = tmpEntity;
				else
					entity.BillToAddressIdSource = DataRepository.AddressProvider.GetByAddressId(transactionManager, entity.BillToAddressId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'BillToAddressIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.BillToAddressIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AddressProvider.DeepLoad(transactionManager, entity.BillToAddressIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion BillToAddressIdSource

			#region ShipToAddressIdSource	
			if (CanDeepLoad(entity, "Address|ShipToAddressIdSource", deepLoadType, innerList) 
				&& entity.ShipToAddressIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShipToAddressId;
				Address tmpEntity = EntityManager.LocateEntity<Address>(EntityLocator.ConstructKeyFromPkItems(typeof(Address), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShipToAddressIdSource = tmpEntity;
				else
					entity.ShipToAddressIdSource = DataRepository.AddressProvider.GetByAddressId(transactionManager, entity.ShipToAddressId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShipToAddressIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ShipToAddressIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.AddressProvider.DeepLoad(transactionManager, entity.ShipToAddressIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ShipToAddressIdSource

			#region ContactIdSource	
			if (CanDeepLoad(entity, "Contact|ContactIdSource", deepLoadType, innerList) 
				&& entity.ContactIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ContactId;
				Contact tmpEntity = EntityManager.LocateEntity<Contact>(EntityLocator.ConstructKeyFromPkItems(typeof(Contact), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ContactIdSource = tmpEntity;
				else
					entity.ContactIdSource = DataRepository.ContactProvider.GetByContactId(transactionManager, entity.ContactId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ContactIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ContactIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ContactProvider.DeepLoad(transactionManager, entity.ContactIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ContactIdSource

			#region CreditCardIdSource	
			if (CanDeepLoad(entity, "CreditCard|CreditCardIdSource", deepLoadType, innerList) 
				&& entity.CreditCardIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CreditCardId ?? (int)0);
				CreditCard tmpEntity = EntityManager.LocateEntity<CreditCard>(EntityLocator.ConstructKeyFromPkItems(typeof(CreditCard), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CreditCardIdSource = tmpEntity;
				else
					entity.CreditCardIdSource = DataRepository.CreditCardProvider.GetByCreditCardId(transactionManager, (entity.CreditCardId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CreditCardIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CreditCardIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CreditCardProvider.DeepLoad(transactionManager, entity.CreditCardIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CreditCardIdSource

			#region CurrencyRateIdSource	
			if (CanDeepLoad(entity, "CurrencyRate|CurrencyRateIdSource", deepLoadType, innerList) 
				&& entity.CurrencyRateIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.CurrencyRateId ?? (int)0);
				CurrencyRate tmpEntity = EntityManager.LocateEntity<CurrencyRate>(EntityLocator.ConstructKeyFromPkItems(typeof(CurrencyRate), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurrencyRateIdSource = tmpEntity;
				else
					entity.CurrencyRateIdSource = DataRepository.CurrencyRateProvider.GetByCurrencyRateId(transactionManager, (entity.CurrencyRateId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurrencyRateIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurrencyRateIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurrencyRateProvider.DeepLoad(transactionManager, entity.CurrencyRateIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurrencyRateIdSource

			#region CustomerIdSource	
			if (CanDeepLoad(entity, "Customer|CustomerIdSource", deepLoadType, innerList) 
				&& entity.CustomerIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomerId;
				Customer tmpEntity = EntityManager.LocateEntity<Customer>(EntityLocator.ConstructKeyFromPkItems(typeof(Customer), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomerIdSource = tmpEntity;
				else
					entity.CustomerIdSource = DataRepository.CustomerProvider.GetByCustomerId(transactionManager, entity.CustomerId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomerIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomerIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomerProvider.DeepLoad(transactionManager, entity.CustomerIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomerIdSource

			#region SalesPersonIdSource	
			if (CanDeepLoad(entity, "SalesPerson|SalesPersonIdSource", deepLoadType, innerList) 
				&& entity.SalesPersonIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.SalesPersonId ?? (int)0);
				SalesPerson tmpEntity = EntityManager.LocateEntity<SalesPerson>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesPerson), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.SalesPersonIdSource = tmpEntity;
				else
					entity.SalesPersonIdSource = DataRepository.SalesPersonProvider.GetBySalesPersonId(transactionManager, (entity.SalesPersonId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesPersonIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesPersonIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesPersonProvider.DeepLoad(transactionManager, entity.SalesPersonIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion SalesPersonIdSource

			#region TerritoryIdSource	
			if (CanDeepLoad(entity, "SalesTerritory|TerritoryIdSource", deepLoadType, innerList) 
				&& entity.TerritoryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.TerritoryId ?? (int)0);
				SalesTerritory tmpEntity = EntityManager.LocateEntity<SalesTerritory>(EntityLocator.ConstructKeyFromPkItems(typeof(SalesTerritory), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.TerritoryIdSource = tmpEntity;
				else
					entity.TerritoryIdSource = DataRepository.SalesTerritoryProvider.GetByTerritoryId(transactionManager, (entity.TerritoryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'TerritoryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.TerritoryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.SalesTerritoryProvider.DeepLoad(transactionManager, entity.TerritoryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion TerritoryIdSource

			#region ShipMethodIdSource	
			if (CanDeepLoad(entity, "ShipMethod|ShipMethodIdSource", deepLoadType, innerList) 
				&& entity.ShipMethodIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.ShipMethodId;
				ShipMethod tmpEntity = EntityManager.LocateEntity<ShipMethod>(EntityLocator.ConstructKeyFromPkItems(typeof(ShipMethod), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.ShipMethodIdSource = tmpEntity;
				else
					entity.ShipMethodIdSource = DataRepository.ShipMethodProvider.GetByShipMethodId(transactionManager, entity.ShipMethodId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'ShipMethodIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.ShipMethodIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ShipMethodProvider.DeepLoad(transactionManager, entity.ShipMethodIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion ShipMethodIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetBySalesOrderId methods when available
			
			#region SalesOrderHeaderSalesReasonCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderHeaderSalesReason>|SalesOrderHeaderSalesReasonCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderHeaderSalesReasonCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderHeaderSalesReasonCollection = DataRepository.SalesOrderHeaderSalesReasonProvider.GetBySalesOrderId(transactionManager, entity.SalesOrderId);

				if (deep && entity.SalesOrderHeaderSalesReasonCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderHeaderSalesReasonCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderHeaderSalesReason>) DataRepository.SalesOrderHeaderSalesReasonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderHeaderSalesReasonCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesOrderDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<SalesOrderDetail>|SalesOrderDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesOrderDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.SalesOrderDetailCollection = DataRepository.SalesOrderDetailProvider.GetBySalesOrderId(transactionManager, entity.SalesOrderId);

				if (deep && entity.SalesOrderDetailCollection.Count > 0)
				{
					deepHandles.Add("SalesOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<SalesOrderDetail>) DataRepository.SalesOrderDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesOrderDetailCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
			#region SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason
			// RelationshipType.ManyToMany
			if (CanDeepLoad(entity, "List<SalesReason>|SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason", deepLoadType, innerList))
			{
				entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason = DataRepository.SalesReasonProvider.GetBySalesOrderIdFromSalesOrderHeaderSalesReason(transactionManager, entity.SalesOrderId);			 
		
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason != null)
				{
					deepHandles.Add("SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason",
						new KeyValuePair<Delegate, object>((DeepLoadHandle< SalesReason >) DataRepository.SalesReasonProvider.DeepLoad,
						new object[] { transactionManager, entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason, deep, deepLoadType, childTypes, innerList }
					));
				}
			}
			#endregion
			
			
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the Nettiers.AdventureWorks.Entities.SalesOrderHeader object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.SalesOrderHeader instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">Nettiers.AdventureWorks.Entities.SalesOrderHeader Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.SalesOrderHeader entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region BillToAddressIdSource
			if (CanDeepSave(entity, "Address|BillToAddressIdSource", deepSaveType, innerList) 
				&& entity.BillToAddressIdSource != null)
			{
				DataRepository.AddressProvider.Save(transactionManager, entity.BillToAddressIdSource);
				entity.BillToAddressId = entity.BillToAddressIdSource.AddressId;
			}
			#endregion 
			
			#region ShipToAddressIdSource
			if (CanDeepSave(entity, "Address|ShipToAddressIdSource", deepSaveType, innerList) 
				&& entity.ShipToAddressIdSource != null)
			{
				DataRepository.AddressProvider.Save(transactionManager, entity.ShipToAddressIdSource);
				entity.ShipToAddressId = entity.ShipToAddressIdSource.AddressId;
			}
			#endregion 
			
			#region ContactIdSource
			if (CanDeepSave(entity, "Contact|ContactIdSource", deepSaveType, innerList) 
				&& entity.ContactIdSource != null)
			{
				DataRepository.ContactProvider.Save(transactionManager, entity.ContactIdSource);
				entity.ContactId = entity.ContactIdSource.ContactId;
			}
			#endregion 
			
			#region CreditCardIdSource
			if (CanDeepSave(entity, "CreditCard|CreditCardIdSource", deepSaveType, innerList) 
				&& entity.CreditCardIdSource != null)
			{
				DataRepository.CreditCardProvider.Save(transactionManager, entity.CreditCardIdSource);
				entity.CreditCardId = entity.CreditCardIdSource.CreditCardId;
			}
			#endregion 
			
			#region CurrencyRateIdSource
			if (CanDeepSave(entity, "CurrencyRate|CurrencyRateIdSource", deepSaveType, innerList) 
				&& entity.CurrencyRateIdSource != null)
			{
				DataRepository.CurrencyRateProvider.Save(transactionManager, entity.CurrencyRateIdSource);
				entity.CurrencyRateId = entity.CurrencyRateIdSource.CurrencyRateId;
			}
			#endregion 
			
			#region CustomerIdSource
			if (CanDeepSave(entity, "Customer|CustomerIdSource", deepSaveType, innerList) 
				&& entity.CustomerIdSource != null)
			{
				DataRepository.CustomerProvider.Save(transactionManager, entity.CustomerIdSource);
				entity.CustomerId = entity.CustomerIdSource.CustomerId;
			}
			#endregion 
			
			#region SalesPersonIdSource
			if (CanDeepSave(entity, "SalesPerson|SalesPersonIdSource", deepSaveType, innerList) 
				&& entity.SalesPersonIdSource != null)
			{
				DataRepository.SalesPersonProvider.Save(transactionManager, entity.SalesPersonIdSource);
				entity.SalesPersonId = entity.SalesPersonIdSource.SalesPersonId;
			}
			#endregion 
			
			#region TerritoryIdSource
			if (CanDeepSave(entity, "SalesTerritory|TerritoryIdSource", deepSaveType, innerList) 
				&& entity.TerritoryIdSource != null)
			{
				DataRepository.SalesTerritoryProvider.Save(transactionManager, entity.TerritoryIdSource);
				entity.TerritoryId = entity.TerritoryIdSource.TerritoryId;
			}
			#endregion 
			
			#region ShipMethodIdSource
			if (CanDeepSave(entity, "ShipMethod|ShipMethodIdSource", deepSaveType, innerList) 
				&& entity.ShipMethodIdSource != null)
			{
				DataRepository.ShipMethodProvider.Save(transactionManager, entity.ShipMethodIdSource);
				entity.ShipMethodId = entity.ShipMethodIdSource.ShipMethodId;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();

			#region SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason>
			if (CanDeepSave(entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason, "List<SalesReason>|SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason", deepSaveType, innerList))
			{
				if (entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason.Count > 0 || entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason.DeletedItems.Count > 0)
				{
					DataRepository.SalesReasonProvider.Save(transactionManager, entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason); 
					deepHandles.Add("SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason",
						new KeyValuePair<Delegate, object>((DeepSaveHandle<SalesReason>) DataRepository.SalesReasonProvider.DeepSave,
						new object[] { transactionManager, entity.SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason, deepSaveType, childTypes, innerList }
					));
				}
			}
			#endregion 
	
			#region List<SalesOrderHeaderSalesReason>
				if (CanDeepSave(entity.SalesOrderHeaderSalesReasonCollection, "List<SalesOrderHeaderSalesReason>|SalesOrderHeaderSalesReasonCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderHeaderSalesReason child in entity.SalesOrderHeaderSalesReasonCollection)
					{
						if(child.SalesOrderIdSource != null)
						{
								child.SalesOrderId = child.SalesOrderIdSource.SalesOrderId;
						}

						if(child.SalesReasonIdSource != null)
						{
								child.SalesReasonId = child.SalesReasonIdSource.SalesReasonId;
						}

					}

					if (entity.SalesOrderHeaderSalesReasonCollection.Count > 0 || entity.SalesOrderHeaderSalesReasonCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderHeaderSalesReasonProvider.Save(transactionManager, entity.SalesOrderHeaderSalesReasonCollection);
						
						deepHandles.Add("SalesOrderHeaderSalesReasonCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderHeaderSalesReason >) DataRepository.SalesOrderHeaderSalesReasonProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderHeaderSalesReasonCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
	
			#region List<SalesOrderDetail>
				if (CanDeepSave(entity.SalesOrderDetailCollection, "List<SalesOrderDetail>|SalesOrderDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(SalesOrderDetail child in entity.SalesOrderDetailCollection)
					{
						if(child.SalesOrderIdSource != null)
						{
							child.SalesOrderId = child.SalesOrderIdSource.SalesOrderId;
						}
						else
						{
							child.SalesOrderId = entity.SalesOrderId;
						}

					}

					if (entity.SalesOrderDetailCollection.Count > 0 || entity.SalesOrderDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.SalesOrderDetailProvider.Save(transactionManager, entity.SalesOrderDetailCollection);
						
						deepHandles.Add("SalesOrderDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< SalesOrderDetail >) DataRepository.SalesOrderDetailProvider.DeepSave,
							new object[] { transactionManager, entity.SalesOrderDetailCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region SalesOrderHeaderChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>Nettiers.AdventureWorks.Entities.SalesOrderHeader</c>
	///</summary>
	public enum SalesOrderHeaderChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Address</c> at BillToAddressIdSource
		///</summary>
		[ChildEntityType(typeof(Address))]
		Address,
			
		///<summary>
		/// Composite Property for <c>Contact</c> at ContactIdSource
		///</summary>
		[ChildEntityType(typeof(Contact))]
		Contact,
			
		///<summary>
		/// Composite Property for <c>CreditCard</c> at CreditCardIdSource
		///</summary>
		[ChildEntityType(typeof(CreditCard))]
		CreditCard,
			
		///<summary>
		/// Composite Property for <c>CurrencyRate</c> at CurrencyRateIdSource
		///</summary>
		[ChildEntityType(typeof(CurrencyRate))]
		CurrencyRate,
			
		///<summary>
		/// Composite Property for <c>Customer</c> at CustomerIdSource
		///</summary>
		[ChildEntityType(typeof(Customer))]
		Customer,
			
		///<summary>
		/// Composite Property for <c>SalesPerson</c> at SalesPersonIdSource
		///</summary>
		[ChildEntityType(typeof(SalesPerson))]
		SalesPerson,
			
		///<summary>
		/// Composite Property for <c>SalesTerritory</c> at TerritoryIdSource
		///</summary>
		[ChildEntityType(typeof(SalesTerritory))]
		SalesTerritory,
			
		///<summary>
		/// Composite Property for <c>ShipMethod</c> at ShipMethodIdSource
		///</summary>
		[ChildEntityType(typeof(ShipMethod))]
		ShipMethod,
	
		///<summary>
		/// Collection of <c>SalesOrderHeader</c> as OneToMany for SalesOrderHeaderSalesReasonCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderHeaderSalesReason>))]
		SalesOrderHeaderSalesReasonCollection,

		///<summary>
		/// Collection of <c>SalesOrderHeader</c> as OneToMany for SalesOrderDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<SalesOrderDetail>))]
		SalesOrderDetailCollection,

		///<summary>
		/// Collection of <c>SalesOrderHeader</c> as ManyToMany for SalesReasonCollection_From_SalesOrderHeaderSalesReason
		///</summary>
		[ChildEntityType(typeof(TList<SalesReason>))]
		SalesReasonIdSalesReasonCollection_From_SalesOrderHeaderSalesReason,
	}
	
	#endregion SalesOrderHeaderChildEntityTypes
	
	#region SalesOrderHeaderFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;SalesOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderFilterBuilder : SqlFilterBuilder<SalesOrderHeaderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilterBuilder class.
		/// </summary>
		public SalesOrderHeaderFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderFilterBuilder
	
	#region SalesOrderHeaderParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;SalesOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalesOrderHeaderParameterBuilder : ParameterizedSqlFilterBuilder<SalesOrderHeaderColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderParameterBuilder class.
		/// </summary>
		public SalesOrderHeaderParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalesOrderHeaderParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalesOrderHeaderParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalesOrderHeaderParameterBuilder
	
	#region SalesOrderHeaderSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;SalesOrderHeaderColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalesOrderHeader"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class SalesOrderHeaderSortBuilder : SqlSortBuilder<SalesOrderHeaderColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalesOrderHeaderSqlSortBuilder class.
		/// </summary>
		public SalesOrderHeaderSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion SalesOrderHeaderSortBuilder
	
} // end namespace
