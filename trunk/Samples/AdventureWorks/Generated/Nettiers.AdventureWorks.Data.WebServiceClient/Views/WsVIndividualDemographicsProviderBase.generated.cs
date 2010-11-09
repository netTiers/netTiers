﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VIndividualDemographics.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Diagnostics;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{

	/// <summary>
	///	This class is the base repository for the CRUD operations on the VIndividualDemographics objects.
	/// </summary>
	public partial class WsVIndividualDemographicsProviderBase : VIndividualDemographicsProviderBase
	{
		#region Declarations	
			
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion 
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsVIndividualDemographicsProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsVIndividualDemographicsProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsVIndividualDemographicsProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the webservice.</param>
		public WsVIndividualDemographicsProviderBase(string url)
		{
			this.url = url;
		}
			
		#endregion Constructors
		
		#region Url
		///<summary>
		/// Current URL for webservice endpoint. 
		///</summary>
		public string Url
        {
        	get {return this.url;}
        	set {this.url = value;}
        }
		#endregion 
	
		#region Convertion utility
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static VList<VIndividualDemographics> Convert(WsProxy.VIndividualDemographics[] items)
		{
			VList<VIndividualDemographics> outItems = new VList<VIndividualDemographics>();
			foreach(WsProxy.VIndividualDemographics item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static VIndividualDemographics Convert(WsProxy.VIndividualDemographics item)
		{			
			VIndividualDemographics outItem = new VIndividualDemographics();			
			outItem.CustomerId = item.CustomerId;
			outItem.TotalPurchaseYtd = item.TotalPurchaseYtd;
			outItem.DateFirstPurchase = item.DateFirstPurchase;
			outItem.BirthDate = item.BirthDate;
			outItem.MaritalStatus = item.MaritalStatus;
			outItem.YearlyIncome = item.YearlyIncome;
			outItem.Gender = item.Gender;
			outItem.TotalChildren = item.TotalChildren;
			outItem.NumberChildrenAtHome = item.NumberChildrenAtHome;
			outItem.Education = item.Education;
			outItem.Occupation = item.Occupation;
			outItem.HomeOwnerFlag = item.HomeOwnerFlag;
			outItem.NumberCarsOwned = item.NumberCarsOwned;
							
			outItem.AcceptChanges();			
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.VIndividualDemographics Convert(VIndividualDemographics item)
		{			
			WsProxy.VIndividualDemographics outItem = new WsProxy.VIndividualDemographics();			
			outItem.CustomerId = item.CustomerId;
			outItem.TotalPurchaseYtd = item.TotalPurchaseYtd;
			outItem.DateFirstPurchase = item.DateFirstPurchase;
			outItem.BirthDate = item.BirthDate;
			outItem.MaritalStatus = item.MaritalStatus;
			outItem.YearlyIncome = item.YearlyIncome;
			outItem.Gender = item.Gender;
			outItem.TotalChildren = item.TotalChildren;
			outItem.NumberChildrenAtHome = item.NumberChildrenAtHome;
			outItem.Education = item.Education;
			outItem.Occupation = item.Occupation;
			outItem.HomeOwnerFlag = item.HomeOwnerFlag;
			outItem.NumberCarsOwned = item.NumberCarsOwned;
							
			return outItem;
		}
		
		#endregion
	
		#region Get Methods
		/// <summary>
		/// 	Gets All rows from the DataSource by a specific predicate filter.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of total rows.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VIndividualDemographics objects.</returns>
		public override VList<VIndividualDemographics> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VIndividualDemographics[] items = proxy.VIndividualDemographicsProvider_Get(whereClause, orderBy, start, pageLength, out count);
			
			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		#endregion Get Methods
		
		#region GetAll Methods
						
		/// <summary>
		/// 	Gets All rows from the DataSource a specific predicate filter.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VIndividualDemographics objects.</returns>
		public override VList<VIndividualDemographics> GetAll(TransactionManager transactionManager, int start, int pageLength)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VIndividualDemographics[] items = proxy.VIndividualDemographicsProvider_GetAll(start, pageLength);			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">count of records returned</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VIndividualDemographics objects.</returns>
		public override VList<VIndividualDemographics> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VIndividualDemographics[] items = proxy.VIndividualDemographicsProvider_GetAll(start, pageLength);   
			
			count = items.Length;
			return Convert(items);
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetAll Methods
	
		#region Get Methods
			
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VIndividualDemographics objects.</returns>
		public override VList<VIndividualDemographics> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
					
			int count;
			WsProxy.VIndividualDemographics[] items = proxy.VIndividualDemographicsProvider_Get(whereClause, orderBy, start, pageLength, out count);
				
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Get Methods
	
	#region Custom Methods
	

	#endregion

	
	
	}//end class
} // end namespace