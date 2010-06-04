
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Nettiers.AdventureWorks.Entities;

#endregion

namespace Nettiers.AdventureWorks.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current SalesTerritoryProviderBase instance.
		///</summary>
		public virtual SalesTerritoryProviderBase SalesTerritoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current LocationProviderBase instance.
		///</summary>
		public virtual LocationProviderBase LocationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesReasonProviderBase instance.
		///</summary>
		public virtual SalesReasonProviderBase SalesReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesPersonQuotaHistoryProviderBase instance.
		///</summary>
		public virtual SalesPersonQuotaHistoryProviderBase SalesPersonQuotaHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesOrderHeaderProviderBase instance.
		///</summary>
		public virtual SalesOrderHeaderProviderBase SalesOrderHeaderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesOrderHeaderSalesReasonProviderBase instance.
		///</summary>
		public virtual SalesOrderHeaderSalesReasonProviderBase SalesOrderHeaderSalesReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductModelProviderBase instance.
		///</summary>
		public virtual ProductModelProviderBase ProductModelProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesTaxRateProviderBase instance.
		///</summary>
		public virtual SalesTaxRateProviderBase SalesTaxRateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesPersonProviderBase instance.
		///</summary>
		public virtual SalesPersonProviderBase SalesPersonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductCategoryProviderBase instance.
		///</summary>
		public virtual ProductCategoryProviderBase ProductCategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductSubcategoryProviderBase instance.
		///</summary>
		public virtual ProductSubcategoryProviderBase ProductSubcategoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProviderBase instance.
		///</summary>
		public virtual ProductProviderBase ProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesTerritoryHistoryProviderBase instance.
		///</summary>
		public virtual SalesTerritoryHistoryProviderBase SalesTerritoryHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PurchaseOrderDetailProviderBase instance.
		///</summary>
		public virtual PurchaseOrderDetailProviderBase PurchaseOrderDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SalesOrderDetailProviderBase instance.
		///</summary>
		public virtual SalesOrderDetailProviderBase SalesOrderDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductProductPhotoProviderBase instance.
		///</summary>
		public virtual ProductProductPhotoProviderBase ProductProductPhotoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductReviewProviderBase instance.
		///</summary>
		public virtual ProductReviewProviderBase ProductReviewProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PurchaseOrderHeaderProviderBase instance.
		///</summary>
		public virtual PurchaseOrderHeaderProviderBase PurchaseOrderHeaderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductVendorProviderBase instance.
		///</summary>
		public virtual ProductVendorProviderBase ProductVendorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ScrapReasonProviderBase instance.
		///</summary>
		public virtual ScrapReasonProviderBase ScrapReasonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UnitMeasureProviderBase instance.
		///</summary>
		public virtual UnitMeasureProviderBase UnitMeasureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShiftProviderBase instance.
		///</summary>
		public virtual ShiftProviderBase ShiftProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TransactionHistoryArchiveProviderBase instance.
		///</summary>
		public virtual TransactionHistoryArchiveProviderBase TransactionHistoryArchiveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VendorProviderBase instance.
		///</summary>
		public virtual VendorProviderBase VendorProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AddressProviderBase instance.
		///</summary>
		public virtual AddressProviderBase AddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WorkOrderProviderBase instance.
		///</summary>
		public virtual WorkOrderProviderBase WorkOrderProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VendorAddressProviderBase instance.
		///</summary>
		public virtual VendorAddressProviderBase VendorAddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TransactionHistoryProviderBase instance.
		///</summary>
		public virtual TransactionHistoryProviderBase TransactionHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VendorContactProviderBase instance.
		///</summary>
		public virtual VendorContactProviderBase VendorContactProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TimestampPkProviderBase instance.
		///</summary>
		public virtual TimestampPkProviderBase TimestampPkProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShoppingCartItemProviderBase instance.
		///</summary>
		public virtual ShoppingCartItemProviderBase ShoppingCartItemProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current TestVariantProviderBase instance.
		///</summary>
		public virtual TestVariantProviderBase TestVariantProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SpecialOfferProviderBase instance.
		///</summary>
		public virtual SpecialOfferProviderBase SpecialOfferProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ShipMethodProviderBase instance.
		///</summary>
		public virtual ShipMethodProviderBase ShipMethodProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current SpecialOfferProductProviderBase instance.
		///</summary>
		public virtual SpecialOfferProductProviderBase SpecialOfferProductProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StateProvinceProviderBase instance.
		///</summary>
		public virtual StateProvinceProviderBase StateProvinceProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StoreProviderBase instance.
		///</summary>
		public virtual StoreProviderBase StoreProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductPhotoProviderBase instance.
		///</summary>
		public virtual ProductPhotoProviderBase ProductPhotoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current StoreContactProviderBase instance.
		///</summary>
		public virtual StoreContactProviderBase StoreContactProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductModelProductDescriptionCultureProviderBase instance.
		///</summary>
		public virtual ProductModelProductDescriptionCultureProviderBase ProductModelProductDescriptionCultureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurrencyProviderBase instance.
		///</summary>
		public virtual CurrencyProviderBase CurrencyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerProviderBase instance.
		///</summary>
		public virtual CustomerProviderBase CustomerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CurrencyRateProviderBase instance.
		///</summary>
		public virtual CurrencyRateProviderBase CurrencyRateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DepartmentProviderBase instance.
		///</summary>
		public virtual DepartmentProviderBase DepartmentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CustomerAddressProviderBase instance.
		///</summary>
		public virtual CustomerAddressProviderBase CustomerAddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CultureProviderBase instance.
		///</summary>
		public virtual CultureProviderBase CultureProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DatabaseLogProviderBase instance.
		///</summary>
		public virtual DatabaseLogProviderBase DatabaseLogProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CreditCardProviderBase instance.
		///</summary>
		public virtual CreditCardProviderBase CreditCardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current BillOfMaterialsProviderBase instance.
		///</summary>
		public virtual BillOfMaterialsProviderBase BillOfMaterialsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountryRegionCurrencyProviderBase instance.
		///</summary>
		public virtual CountryRegionCurrencyProviderBase CountryRegionCurrencyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContactProviderBase instance.
		///</summary>
		public virtual ContactProviderBase ContactProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AwBuildVersionProviderBase instance.
		///</summary>
		public virtual AwBuildVersionProviderBase AwBuildVersionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current CountryRegionProviderBase instance.
		///</summary>
		public virtual CountryRegionProviderBase CountryRegionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContactCreditCardProviderBase instance.
		///</summary>
		public virtual ContactCreditCardProviderBase ContactCreditCardProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DocumentProviderBase instance.
		///</summary>
		public virtual DocumentProviderBase DocumentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ContactTypeProviderBase instance.
		///</summary>
		public virtual ContactTypeProviderBase ContactTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeProviderBase instance.
		///</summary>
		public virtual EmployeeProviderBase EmployeeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductDocumentProviderBase instance.
		///</summary>
		public virtual ProductDocumentProviderBase ProductDocumentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeAddressProviderBase instance.
		///</summary>
		public virtual EmployeeAddressProviderBase EmployeeAddressProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductInventoryProviderBase instance.
		///</summary>
		public virtual ProductInventoryProviderBase ProductInventoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductDescriptionProviderBase instance.
		///</summary>
		public virtual ProductDescriptionProviderBase ProductDescriptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductModelIllustrationProviderBase instance.
		///</summary>
		public virtual ProductModelIllustrationProviderBase ProductModelIllustrationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductListPriceHistoryProviderBase instance.
		///</summary>
		public virtual ProductListPriceHistoryProviderBase ProductListPriceHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ProductCostHistoryProviderBase instance.
		///</summary>
		public virtual ProductCostHistoryProviderBase ProductCostHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current WorkOrderRoutingProviderBase instance.
		///</summary>
		public virtual WorkOrderRoutingProviderBase WorkOrderRoutingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NullFkeyParentProviderBase instance.
		///</summary>
		public virtual NullFkeyParentProviderBase NullFkeyParentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeePayHistoryProviderBase instance.
		///</summary>
		public virtual EmployeePayHistoryProviderBase EmployeePayHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current NullFkeyChildProviderBase instance.
		///</summary>
		public virtual NullFkeyChildProviderBase NullFkeyChildProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current ErrorLogProviderBase instance.
		///</summary>
		public virtual ErrorLogProviderBase ErrorLogProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EmployeeDepartmentHistoryProviderBase instance.
		///</summary>
		public virtual EmployeeDepartmentHistoryProviderBase EmployeeDepartmentHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current JobCandidateProviderBase instance.
		///</summary>
		public virtual JobCandidateProviderBase JobCandidateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IllustrationProviderBase instance.
		///</summary>
		public virtual IllustrationProviderBase IllustrationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current AddressTypeProviderBase instance.
		///</summary>
		public virtual AddressTypeProviderBase AddressTypeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current IndividualProviderBase instance.
		///</summary>
		public virtual IndividualProviderBase IndividualProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current VAdditionalContactInfoProviderBase instance.
		///</summary>
		public virtual VAdditionalContactInfoProviderBase VAdditionalContactInfoProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VEmployeeProviderBase instance.
		///</summary>
		public virtual VEmployeeProviderBase VEmployeeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VEmployeeDepartmentProviderBase instance.
		///</summary>
		public virtual VEmployeeDepartmentProviderBase VEmployeeDepartmentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VEmployeeDepartmentHistoryProviderBase instance.
		///</summary>
		public virtual VEmployeeDepartmentHistoryProviderBase VEmployeeDepartmentHistoryProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VIndividualCustomerProviderBase instance.
		///</summary>
		public virtual VIndividualCustomerProviderBase VIndividualCustomerProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VIndividualDemographicsProviderBase instance.
		///</summary>
		public virtual VIndividualDemographicsProviderBase VIndividualDemographicsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VJobCandidateProviderBase instance.
		///</summary>
		public virtual VJobCandidateProviderBase VJobCandidateProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VJobCandidateEducationProviderBase instance.
		///</summary>
		public virtual VJobCandidateEducationProviderBase VJobCandidateEducationProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VJobCandidateEmploymentProviderBase instance.
		///</summary>
		public virtual VJobCandidateEmploymentProviderBase VJobCandidateEmploymentProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VProductAndDescriptionProviderBase instance.
		///</summary>
		public virtual VProductAndDescriptionProviderBase VProductAndDescriptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VProductModelCatalogDescriptionProviderBase instance.
		///</summary>
		public virtual VProductModelCatalogDescriptionProviderBase VProductModelCatalogDescriptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VProductModelInstructionsProviderBase instance.
		///</summary>
		public virtual VProductModelInstructionsProviderBase VProductModelInstructionsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VSalesPersonProviderBase instance.
		///</summary>
		public virtual VSalesPersonProviderBase VSalesPersonProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VSalesPersonSalesByFiscalYearsProviderBase instance.
		///</summary>
		public virtual VSalesPersonSalesByFiscalYearsProviderBase VSalesPersonSalesByFiscalYearsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VStateProvinceCountryRegionProviderBase instance.
		///</summary>
		public virtual VStateProvinceCountryRegionProviderBase VStateProvinceCountryRegionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VStoreWithDemographicsProviderBase instance.
		///</summary>
		public virtual VStoreWithDemographicsProviderBase VStoreWithDemographicsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VVendorProviderBase instance.
		///</summary>
		public virtual VVendorProviderBase VVendorProvider{get {throw new NotImplementedException();}}
		
	}
}
