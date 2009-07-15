
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using PetShop.Business;

#endregion

namespace PetShop.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current OrderStatusProviderBase instance.
		///</summary>
		public virtual OrderStatusProviderBase OrderStatusProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CartProviderBase instance.
		///</summary>
		public virtual CartProviderBase CartProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current OrderProviderBase instance.
		///</summary>
		public virtual OrderProviderBase OrderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current InventoryProviderBase instance.
		///</summary>
		public virtual InventoryProviderBase InventoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SupplierProviderBase instance.
		///</summary>
		public virtual SupplierProviderBase SupplierProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CategoryProviderBase instance.
		///</summary>
		public virtual CategoryProviderBase CategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProviderBase instance.
		///</summary>
		public virtual ProductProviderBase ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LineItemProviderBase instance.
		///</summary>
		public virtual LineItemProviderBase LineItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AccountProviderBase instance.
		///</summary>
		public virtual AccountProviderBase AccountProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProfileProviderBase instance.
		///</summary>
		public virtual ProfileProviderBase ProfileProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ItemProviderBase instance.
		///</summary>
		public virtual ItemProviderBase ItemProvider{get {throw new NotImplementedException();}}
		
		
	}
}
