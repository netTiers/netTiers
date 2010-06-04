#region Using Directives

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Channels;
using Nettiers.AdventureWorks.Services;
using Nettiers.AdventureWorks.Contracts;
using Nettiers.AdventureWorks.Contracts.Services;
using System.Net;

#endregion Using Directives

namespace Nettiers.AdventureWorks.Proxy
{
    /// <summary>
    /// The Proxy Factory class is used to instanciate instances of the WCF Services locally.
    /// </summary>
    public static class ProxyFactory
    {
        #region Properties

        private static string bindingConfigName = "GZipBindingConfig";

        /// <summary>
        /// Communication Platform : Direct / WCF
        /// </summary>
        private static CommunicationPlatform defaultPlatform;
        private static NetworkCredential clientCredentials;
		
		/// <summary>
        /// Base URL of the WCF Services
        /// </summary>
        private static string baseAddress;

        /// <summary>
        /// Gets the Communication Platform : Direct / WCF
        /// </summary>
        public static CommunicationPlatform Platform
        {
            get { return defaultPlatform; }
        }
        
        /// <summary>
        /// Gets the Client Credentials
        /// </summary>
        public static NetworkCredential ClientCredentials
        {
            get { return clientCredentials; }
            set { clientCredentials = value; }
        }
		
		/// <summary>
        /// Sets the base address
        /// </summary>
        public static string BaseAddress
        {
            get { return baseAddress; }
			set { baseAddress = value; }
        }

        /// <summary>
        /// Enum for the Communication Platform
        /// </summary>
        public enum CommunicationPlatform
        {
            /// <summary>
            /// Windows Communication Foundation
            /// </summary>
            WCF,
            /// <summary>
            /// Direct Access
            /// </summary>
            Direct,
            /// <summary>
            /// Base Address
            /// </summary>
			BaseAddress
		}

        #endregion Properties

        #region Constructor
                
        /// <summary>
        /// ProxyFactory Constructor
        /// </summary>
        static ProxyFactory()
        {
            try
            {
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                defaultPlatform = (ProxyFactory.CommunicationPlatform)Enum.Parse(
                                typeof(ProxyFactory.CommunicationPlatform),
                                ConfigurationManager.AppSettings["communicationPlatform"]);
            }
            catch { }
        }

        #endregion Constructor
        
        #region Public Properties
                
        #endregion Public Properties
        
        #region AddressService

        /// <summary>
        /// AddressService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressService> factoryAddressService = null;
                
        /// <summary>
        /// Creates a new AddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAddressService AddressServiceProxyInstance()
        {
            return AddressServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new AddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAddressService AddressServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IAddressService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new AddressService() as IAddressService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryAddressService == null)
                        {
                            factoryAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressService>("AddressService");                            
                            factoryAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryAddressService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryAddressService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "AddressService.svc/gzip");                    
                    	factoryAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressService>(binding, endpoint);
                        factoryAddressService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryAddressService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryAddressService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region AddressTypeService

        /// <summary>
        /// AddressTypeService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService> factoryAddressTypeService = null;
                
        /// <summary>
        /// Creates a new AddressTypeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService AddressTypeServiceProxyInstance()
        {
            return AddressTypeServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new AddressTypeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService AddressTypeServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new AddressTypeService() as IAddressTypeService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryAddressTypeService == null)
                        {
                            factoryAddressTypeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService>("AddressTypeService");                            
                            factoryAddressTypeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryAddressTypeService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryAddressTypeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryAddressTypeService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "AddressTypeService.svc/gzip");                    
                    	factoryAddressTypeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAddressTypeService>(binding, endpoint);
                        factoryAddressTypeService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryAddressTypeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryAddressTypeService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryAddressTypeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryAddressTypeService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region AwBuildVersionService

        /// <summary>
        /// AwBuildVersionService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService> factoryAwBuildVersionService = null;
                
        /// <summary>
        /// Creates a new AwBuildVersionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService AwBuildVersionServiceProxyInstance()
        {
            return AwBuildVersionServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new AwBuildVersionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService AwBuildVersionServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new AwBuildVersionService() as IAwBuildVersionService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryAwBuildVersionService == null)
                        {
                            factoryAwBuildVersionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService>("AwBuildVersionService");                            
                            factoryAwBuildVersionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryAwBuildVersionService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryAwBuildVersionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryAwBuildVersionService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "AwBuildVersionService.svc/gzip");                    
                    	factoryAwBuildVersionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IAwBuildVersionService>(binding, endpoint);
                        factoryAwBuildVersionService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryAwBuildVersionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryAwBuildVersionService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryAwBuildVersionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryAwBuildVersionService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region BillOfMaterialsService

        /// <summary>
        /// BillOfMaterialsService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService> factoryBillOfMaterialsService = null;
                
        /// <summary>
        /// Creates a new BillOfMaterialsService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService BillOfMaterialsServiceProxyInstance()
        {
            return BillOfMaterialsServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new BillOfMaterialsService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService BillOfMaterialsServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new BillOfMaterialsService() as IBillOfMaterialsService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryBillOfMaterialsService == null)
                        {
                            factoryBillOfMaterialsService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService>("BillOfMaterialsService");                            
                            factoryBillOfMaterialsService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryBillOfMaterialsService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryBillOfMaterialsService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryBillOfMaterialsService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "BillOfMaterialsService.svc/gzip");                    
                    	factoryBillOfMaterialsService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IBillOfMaterialsService>(binding, endpoint);
                        factoryBillOfMaterialsService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryBillOfMaterialsService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryBillOfMaterialsService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryBillOfMaterialsService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryBillOfMaterialsService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ContactService

        /// <summary>
        /// ContactService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactService> factoryContactService = null;
                
        /// <summary>
        /// Creates a new ContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactService ContactServiceProxyInstance()
        {
            return ContactServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactService ContactServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IContactService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ContactService() as IContactService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryContactService == null)
                        {
                            factoryContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactService>("ContactService");                            
                            factoryContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryContactService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryContactService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ContactService.svc/gzip");                    
                    	factoryContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactService>(binding, endpoint);
                        factoryContactService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryContactService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryContactService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ContactCreditCardService

        /// <summary>
        /// ContactCreditCardService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService> factoryContactCreditCardService = null;
                
        /// <summary>
        /// Creates a new ContactCreditCardService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService ContactCreditCardServiceProxyInstance()
        {
            return ContactCreditCardServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ContactCreditCardService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService ContactCreditCardServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ContactCreditCardService() as IContactCreditCardService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryContactCreditCardService == null)
                        {
                            factoryContactCreditCardService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService>("ContactCreditCardService");                            
                            factoryContactCreditCardService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryContactCreditCardService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryContactCreditCardService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryContactCreditCardService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ContactCreditCardService.svc/gzip");                    
                    	factoryContactCreditCardService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactCreditCardService>(binding, endpoint);
                        factoryContactCreditCardService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryContactCreditCardService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryContactCreditCardService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryContactCreditCardService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryContactCreditCardService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ContactTypeService

        /// <summary>
        /// ContactTypeService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactTypeService> factoryContactTypeService = null;
                
        /// <summary>
        /// Creates a new ContactTypeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactTypeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactTypeService ContactTypeServiceProxyInstance()
        {
            return ContactTypeServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ContactTypeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IContactTypeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IContactTypeService ContactTypeServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IContactTypeService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ContactTypeService() as IContactTypeService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryContactTypeService == null)
                        {
                            factoryContactTypeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactTypeService>("ContactTypeService");                            
                            factoryContactTypeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryContactTypeService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryContactTypeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryContactTypeService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ContactTypeService.svc/gzip");                    
                    	factoryContactTypeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IContactTypeService>(binding, endpoint);
                        factoryContactTypeService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryContactTypeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryContactTypeService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryContactTypeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryContactTypeService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CountryRegionService

        /// <summary>
        /// CountryRegionService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService> factoryCountryRegionService = null;
                
        /// <summary>
        /// Creates a new CountryRegionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService CountryRegionServiceProxyInstance()
        {
            return CountryRegionServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CountryRegionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService CountryRegionServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CountryRegionService() as ICountryRegionService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCountryRegionService == null)
                        {
                            factoryCountryRegionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService>("CountryRegionService");                            
                            factoryCountryRegionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCountryRegionService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCountryRegionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCountryRegionService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CountryRegionService.svc/gzip");                    
                    	factoryCountryRegionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionService>(binding, endpoint);
                        factoryCountryRegionService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCountryRegionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCountryRegionService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCountryRegionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCountryRegionService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CountryRegionCurrencyService

        /// <summary>
        /// CountryRegionCurrencyService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService> factoryCountryRegionCurrencyService = null;
                
        /// <summary>
        /// Creates a new CountryRegionCurrencyService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService CountryRegionCurrencyServiceProxyInstance()
        {
            return CountryRegionCurrencyServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CountryRegionCurrencyService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService CountryRegionCurrencyServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CountryRegionCurrencyService() as ICountryRegionCurrencyService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCountryRegionCurrencyService == null)
                        {
                            factoryCountryRegionCurrencyService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService>("CountryRegionCurrencyService");                            
                            factoryCountryRegionCurrencyService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCountryRegionCurrencyService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCountryRegionCurrencyService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCountryRegionCurrencyService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CountryRegionCurrencyService.svc/gzip");                    
                    	factoryCountryRegionCurrencyService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICountryRegionCurrencyService>(binding, endpoint);
                        factoryCountryRegionCurrencyService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCountryRegionCurrencyService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCountryRegionCurrencyService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCountryRegionCurrencyService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCountryRegionCurrencyService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CreditCardService

        /// <summary>
        /// CreditCardService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICreditCardService> factoryCreditCardService = null;
                
        /// <summary>
        /// Creates a new CreditCardService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICreditCardService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICreditCardService CreditCardServiceProxyInstance()
        {
            return CreditCardServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CreditCardService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICreditCardService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICreditCardService CreditCardServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICreditCardService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CreditCardService() as ICreditCardService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCreditCardService == null)
                        {
                            factoryCreditCardService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICreditCardService>("CreditCardService");                            
                            factoryCreditCardService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCreditCardService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCreditCardService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCreditCardService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CreditCardService.svc/gzip");                    
                    	factoryCreditCardService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICreditCardService>(binding, endpoint);
                        factoryCreditCardService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCreditCardService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCreditCardService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCreditCardService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCreditCardService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CultureService

        /// <summary>
        /// CultureService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICultureService> factoryCultureService = null;
                
        /// <summary>
        /// Creates a new CultureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICultureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICultureService CultureServiceProxyInstance()
        {
            return CultureServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CultureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICultureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICultureService CultureServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICultureService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CultureService() as ICultureService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCultureService == null)
                        {
                            factoryCultureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICultureService>("CultureService");                            
                            factoryCultureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCultureService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCultureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCultureService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CultureService.svc/gzip");                    
                    	factoryCultureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICultureService>(binding, endpoint);
                        factoryCultureService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCultureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCultureService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCultureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCultureService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CurrencyService

        /// <summary>
        /// CurrencyService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyService> factoryCurrencyService = null;
                
        /// <summary>
        /// Creates a new CurrencyService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICurrencyService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICurrencyService CurrencyServiceProxyInstance()
        {
            return CurrencyServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CurrencyService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICurrencyService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICurrencyService CurrencyServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICurrencyService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CurrencyService() as ICurrencyService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCurrencyService == null)
                        {
                            factoryCurrencyService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyService>("CurrencyService");                            
                            factoryCurrencyService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCurrencyService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCurrencyService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCurrencyService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CurrencyService.svc/gzip");                    
                    	factoryCurrencyService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyService>(binding, endpoint);
                        factoryCurrencyService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCurrencyService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCurrencyService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCurrencyService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCurrencyService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CurrencyRateService

        /// <summary>
        /// CurrencyRateService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService> factoryCurrencyRateService = null;
                
        /// <summary>
        /// Creates a new CurrencyRateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService CurrencyRateServiceProxyInstance()
        {
            return CurrencyRateServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CurrencyRateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService CurrencyRateServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CurrencyRateService() as ICurrencyRateService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCurrencyRateService == null)
                        {
                            factoryCurrencyRateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService>("CurrencyRateService");                            
                            factoryCurrencyRateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCurrencyRateService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCurrencyRateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCurrencyRateService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CurrencyRateService.svc/gzip");                    
                    	factoryCurrencyRateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICurrencyRateService>(binding, endpoint);
                        factoryCurrencyRateService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCurrencyRateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCurrencyRateService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCurrencyRateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCurrencyRateService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CustomerService

        /// <summary>
        /// CustomerService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerService> factoryCustomerService = null;
                
        /// <summary>
        /// Creates a new CustomerService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICustomerService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICustomerService CustomerServiceProxyInstance()
        {
            return CustomerServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CustomerService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICustomerService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICustomerService CustomerServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICustomerService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CustomerService() as ICustomerService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCustomerService == null)
                        {
                            factoryCustomerService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerService>("CustomerService");                            
                            factoryCustomerService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCustomerService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCustomerService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCustomerService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CustomerService.svc/gzip");                    
                    	factoryCustomerService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerService>(binding, endpoint);
                        factoryCustomerService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCustomerService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCustomerService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCustomerService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCustomerService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region CustomerAddressService

        /// <summary>
        /// CustomerAddressService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService> factoryCustomerAddressService = null;
                
        /// <summary>
        /// Creates a new CustomerAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService CustomerAddressServiceProxyInstance()
        {
            return CustomerAddressServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new CustomerAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService CustomerAddressServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new CustomerAddressService() as ICustomerAddressService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryCustomerAddressService == null)
                        {
                            factoryCustomerAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService>("CustomerAddressService");                            
                            factoryCustomerAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryCustomerAddressService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryCustomerAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryCustomerAddressService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "CustomerAddressService.svc/gzip");                    
                    	factoryCustomerAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ICustomerAddressService>(binding, endpoint);
                        factoryCustomerAddressService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryCustomerAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryCustomerAddressService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryCustomerAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryCustomerAddressService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region DatabaseLogService

        /// <summary>
        /// DatabaseLogService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService> factoryDatabaseLogService = null;
                
        /// <summary>
        /// Creates a new DatabaseLogService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService DatabaseLogServiceProxyInstance()
        {
            return DatabaseLogServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new DatabaseLogService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService DatabaseLogServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new DatabaseLogService() as IDatabaseLogService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryDatabaseLogService == null)
                        {
                            factoryDatabaseLogService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService>("DatabaseLogService");                            
                            factoryDatabaseLogService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryDatabaseLogService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryDatabaseLogService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryDatabaseLogService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "DatabaseLogService.svc/gzip");                    
                    	factoryDatabaseLogService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDatabaseLogService>(binding, endpoint);
                        factoryDatabaseLogService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryDatabaseLogService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryDatabaseLogService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryDatabaseLogService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryDatabaseLogService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region DepartmentService

        /// <summary>
        /// DepartmentService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDepartmentService> factoryDepartmentService = null;
                
        /// <summary>
        /// Creates a new DepartmentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDepartmentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDepartmentService DepartmentServiceProxyInstance()
        {
            return DepartmentServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new DepartmentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDepartmentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDepartmentService DepartmentServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IDepartmentService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new DepartmentService() as IDepartmentService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryDepartmentService == null)
                        {
                            factoryDepartmentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDepartmentService>("DepartmentService");                            
                            factoryDepartmentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryDepartmentService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryDepartmentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryDepartmentService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "DepartmentService.svc/gzip");                    
                    	factoryDepartmentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDepartmentService>(binding, endpoint);
                        factoryDepartmentService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryDepartmentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryDepartmentService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryDepartmentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryDepartmentService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region DocumentService

        /// <summary>
        /// DocumentService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDocumentService> factoryDocumentService = null;
                
        /// <summary>
        /// Creates a new DocumentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDocumentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDocumentService DocumentServiceProxyInstance()
        {
            return DocumentServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new DocumentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IDocumentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IDocumentService DocumentServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IDocumentService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new DocumentService() as IDocumentService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryDocumentService == null)
                        {
                            factoryDocumentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDocumentService>("DocumentService");                            
                            factoryDocumentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryDocumentService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryDocumentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryDocumentService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "DocumentService.svc/gzip");                    
                    	factoryDocumentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IDocumentService>(binding, endpoint);
                        factoryDocumentService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryDocumentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryDocumentService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryDocumentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryDocumentService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region EmployeeService

        /// <summary>
        /// EmployeeService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeService> factoryEmployeeService = null;
                
        /// <summary>
        /// Creates a new EmployeeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeService EmployeeServiceProxyInstance()
        {
            return EmployeeServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new EmployeeService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeService EmployeeServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IEmployeeService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new EmployeeService() as IEmployeeService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryEmployeeService == null)
                        {
                            factoryEmployeeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeService>("EmployeeService");                            
                            factoryEmployeeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryEmployeeService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryEmployeeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryEmployeeService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "EmployeeService.svc/gzip");                    
                    	factoryEmployeeService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeService>(binding, endpoint);
                        factoryEmployeeService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryEmployeeService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryEmployeeService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryEmployeeService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryEmployeeService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region EmployeeAddressService

        /// <summary>
        /// EmployeeAddressService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService> factoryEmployeeAddressService = null;
                
        /// <summary>
        /// Creates a new EmployeeAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService EmployeeAddressServiceProxyInstance()
        {
            return EmployeeAddressServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new EmployeeAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService EmployeeAddressServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new EmployeeAddressService() as IEmployeeAddressService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryEmployeeAddressService == null)
                        {
                            factoryEmployeeAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService>("EmployeeAddressService");                            
                            factoryEmployeeAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryEmployeeAddressService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryEmployeeAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryEmployeeAddressService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "EmployeeAddressService.svc/gzip");                    
                    	factoryEmployeeAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeAddressService>(binding, endpoint);
                        factoryEmployeeAddressService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryEmployeeAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryEmployeeAddressService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryEmployeeAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryEmployeeAddressService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region EmployeeDepartmentHistoryService

        /// <summary>
        /// EmployeeDepartmentHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService> factoryEmployeeDepartmentHistoryService = null;
                
        /// <summary>
        /// Creates a new EmployeeDepartmentHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService EmployeeDepartmentHistoryServiceProxyInstance()
        {
            return EmployeeDepartmentHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new EmployeeDepartmentHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService EmployeeDepartmentHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new EmployeeDepartmentHistoryService() as IEmployeeDepartmentHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryEmployeeDepartmentHistoryService == null)
                        {
                            factoryEmployeeDepartmentHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService>("EmployeeDepartmentHistoryService");                            
                            factoryEmployeeDepartmentHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryEmployeeDepartmentHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryEmployeeDepartmentHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryEmployeeDepartmentHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "EmployeeDepartmentHistoryService.svc/gzip");                    
                    	factoryEmployeeDepartmentHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeeDepartmentHistoryService>(binding, endpoint);
                        factoryEmployeeDepartmentHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryEmployeeDepartmentHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryEmployeeDepartmentHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryEmployeeDepartmentHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryEmployeeDepartmentHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region EmployeePayHistoryService

        /// <summary>
        /// EmployeePayHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService> factoryEmployeePayHistoryService = null;
                
        /// <summary>
        /// Creates a new EmployeePayHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService EmployeePayHistoryServiceProxyInstance()
        {
            return EmployeePayHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new EmployeePayHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService EmployeePayHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new EmployeePayHistoryService() as IEmployeePayHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryEmployeePayHistoryService == null)
                        {
                            factoryEmployeePayHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService>("EmployeePayHistoryService");                            
                            factoryEmployeePayHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryEmployeePayHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryEmployeePayHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryEmployeePayHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "EmployeePayHistoryService.svc/gzip");                    
                    	factoryEmployeePayHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IEmployeePayHistoryService>(binding, endpoint);
                        factoryEmployeePayHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryEmployeePayHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryEmployeePayHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryEmployeePayHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryEmployeePayHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ErrorLogService

        /// <summary>
        /// ErrorLogService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IErrorLogService> factoryErrorLogService = null;
                
        /// <summary>
        /// Creates a new ErrorLogService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IErrorLogService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IErrorLogService ErrorLogServiceProxyInstance()
        {
            return ErrorLogServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ErrorLogService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IErrorLogService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IErrorLogService ErrorLogServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IErrorLogService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ErrorLogService() as IErrorLogService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryErrorLogService == null)
                        {
                            factoryErrorLogService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IErrorLogService>("ErrorLogService");                            
                            factoryErrorLogService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryErrorLogService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryErrorLogService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryErrorLogService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ErrorLogService.svc/gzip");                    
                    	factoryErrorLogService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IErrorLogService>(binding, endpoint);
                        factoryErrorLogService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryErrorLogService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryErrorLogService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryErrorLogService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryErrorLogService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region IllustrationService

        /// <summary>
        /// IllustrationService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIllustrationService> factoryIllustrationService = null;
                
        /// <summary>
        /// Creates a new IllustrationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IIllustrationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IIllustrationService IllustrationServiceProxyInstance()
        {
            return IllustrationServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new IllustrationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IIllustrationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IIllustrationService IllustrationServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IIllustrationService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new IllustrationService() as IIllustrationService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryIllustrationService == null)
                        {
                            factoryIllustrationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIllustrationService>("IllustrationService");                            
                            factoryIllustrationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryIllustrationService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryIllustrationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryIllustrationService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "IllustrationService.svc/gzip");                    
                    	factoryIllustrationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIllustrationService>(binding, endpoint);
                        factoryIllustrationService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryIllustrationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryIllustrationService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryIllustrationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryIllustrationService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region IndividualService

        /// <summary>
        /// IndividualService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIndividualService> factoryIndividualService = null;
                
        /// <summary>
        /// Creates a new IndividualService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IIndividualService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IIndividualService IndividualServiceProxyInstance()
        {
            return IndividualServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new IndividualService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IIndividualService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IIndividualService IndividualServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IIndividualService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new IndividualService() as IIndividualService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryIndividualService == null)
                        {
                            factoryIndividualService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIndividualService>("IndividualService");                            
                            factoryIndividualService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryIndividualService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryIndividualService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryIndividualService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "IndividualService.svc/gzip");                    
                    	factoryIndividualService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IIndividualService>(binding, endpoint);
                        factoryIndividualService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryIndividualService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryIndividualService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryIndividualService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryIndividualService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region JobCandidateService

        /// <summary>
        /// JobCandidateService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService> factoryJobCandidateService = null;
                
        /// <summary>
        /// Creates a new JobCandidateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService JobCandidateServiceProxyInstance()
        {
            return JobCandidateServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new JobCandidateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService JobCandidateServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new JobCandidateService() as IJobCandidateService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryJobCandidateService == null)
                        {
                            factoryJobCandidateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService>("JobCandidateService");                            
                            factoryJobCandidateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryJobCandidateService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryJobCandidateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryJobCandidateService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "JobCandidateService.svc/gzip");                    
                    	factoryJobCandidateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IJobCandidateService>(binding, endpoint);
                        factoryJobCandidateService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryJobCandidateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryJobCandidateService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryJobCandidateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryJobCandidateService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region LocationService

        /// <summary>
        /// LocationService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ILocationService> factoryLocationService = null;
                
        /// <summary>
        /// Creates a new LocationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ILocationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ILocationService LocationServiceProxyInstance()
        {
            return LocationServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new LocationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ILocationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ILocationService LocationServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ILocationService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new LocationService() as ILocationService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryLocationService == null)
                        {
                            factoryLocationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ILocationService>("LocationService");                            
                            factoryLocationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryLocationService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryLocationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryLocationService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "LocationService.svc/gzip");                    
                    	factoryLocationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ILocationService>(binding, endpoint);
                        factoryLocationService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryLocationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryLocationService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryLocationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryLocationService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region NullFkeyChildService

        /// <summary>
        /// NullFkeyChildService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService> factoryNullFkeyChildService = null;
                
        /// <summary>
        /// Creates a new NullFkeyChildService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService NullFkeyChildServiceProxyInstance()
        {
            return NullFkeyChildServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new NullFkeyChildService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService NullFkeyChildServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new NullFkeyChildService() as INullFkeyChildService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryNullFkeyChildService == null)
                        {
                            factoryNullFkeyChildService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService>("NullFkeyChildService");                            
                            factoryNullFkeyChildService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryNullFkeyChildService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryNullFkeyChildService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryNullFkeyChildService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "NullFkeyChildService.svc/gzip");                    
                    	factoryNullFkeyChildService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyChildService>(binding, endpoint);
                        factoryNullFkeyChildService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryNullFkeyChildService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryNullFkeyChildService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryNullFkeyChildService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryNullFkeyChildService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region NullFkeyParentService

        /// <summary>
        /// NullFkeyParentService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService> factoryNullFkeyParentService = null;
                
        /// <summary>
        /// Creates a new NullFkeyParentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService NullFkeyParentServiceProxyInstance()
        {
            return NullFkeyParentServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new NullFkeyParentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService NullFkeyParentServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new NullFkeyParentService() as INullFkeyParentService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryNullFkeyParentService == null)
                        {
                            factoryNullFkeyParentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService>("NullFkeyParentService");                            
                            factoryNullFkeyParentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryNullFkeyParentService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryNullFkeyParentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryNullFkeyParentService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "NullFkeyParentService.svc/gzip");                    
                    	factoryNullFkeyParentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.INullFkeyParentService>(binding, endpoint);
                        factoryNullFkeyParentService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryNullFkeyParentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryNullFkeyParentService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryNullFkeyParentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryNullFkeyParentService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductService

        /// <summary>
        /// ProductService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductService> factoryProductService = null;
                
        /// <summary>
        /// Creates a new ProductService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductService ProductServiceProxyInstance()
        {
            return ProductServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductService ProductServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductService() as IProductService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductService == null)
                        {
                            factoryProductService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductService>("ProductService");                            
                            factoryProductService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductService.svc/gzip");                    
                    	factoryProductService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductService>(binding, endpoint);
                        factoryProductService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductCategoryService

        /// <summary>
        /// ProductCategoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService> factoryProductCategoryService = null;
                
        /// <summary>
        /// Creates a new ProductCategoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService ProductCategoryServiceProxyInstance()
        {
            return ProductCategoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductCategoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService ProductCategoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductCategoryService() as IProductCategoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductCategoryService == null)
                        {
                            factoryProductCategoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService>("ProductCategoryService");                            
                            factoryProductCategoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductCategoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductCategoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductCategoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductCategoryService.svc/gzip");                    
                    	factoryProductCategoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCategoryService>(binding, endpoint);
                        factoryProductCategoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductCategoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductCategoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductCategoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductCategoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductCostHistoryService

        /// <summary>
        /// ProductCostHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService> factoryProductCostHistoryService = null;
                
        /// <summary>
        /// Creates a new ProductCostHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService ProductCostHistoryServiceProxyInstance()
        {
            return ProductCostHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductCostHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService ProductCostHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductCostHistoryService() as IProductCostHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductCostHistoryService == null)
                        {
                            factoryProductCostHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService>("ProductCostHistoryService");                            
                            factoryProductCostHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductCostHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductCostHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductCostHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductCostHistoryService.svc/gzip");                    
                    	factoryProductCostHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductCostHistoryService>(binding, endpoint);
                        factoryProductCostHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductCostHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductCostHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductCostHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductCostHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductDescriptionService

        /// <summary>
        /// ProductDescriptionService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService> factoryProductDescriptionService = null;
                
        /// <summary>
        /// Creates a new ProductDescriptionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService ProductDescriptionServiceProxyInstance()
        {
            return ProductDescriptionServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductDescriptionService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService ProductDescriptionServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductDescriptionService() as IProductDescriptionService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductDescriptionService == null)
                        {
                            factoryProductDescriptionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService>("ProductDescriptionService");                            
                            factoryProductDescriptionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductDescriptionService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductDescriptionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductDescriptionService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductDescriptionService.svc/gzip");                    
                    	factoryProductDescriptionService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDescriptionService>(binding, endpoint);
                        factoryProductDescriptionService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductDescriptionService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductDescriptionService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductDescriptionService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductDescriptionService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductDocumentService

        /// <summary>
        /// ProductDocumentService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService> factoryProductDocumentService = null;
                
        /// <summary>
        /// Creates a new ProductDocumentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService ProductDocumentServiceProxyInstance()
        {
            return ProductDocumentServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductDocumentService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService ProductDocumentServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductDocumentService() as IProductDocumentService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductDocumentService == null)
                        {
                            factoryProductDocumentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService>("ProductDocumentService");                            
                            factoryProductDocumentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductDocumentService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductDocumentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductDocumentService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductDocumentService.svc/gzip");                    
                    	factoryProductDocumentService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductDocumentService>(binding, endpoint);
                        factoryProductDocumentService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductDocumentService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductDocumentService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductDocumentService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductDocumentService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductInventoryService

        /// <summary>
        /// ProductInventoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService> factoryProductInventoryService = null;
                
        /// <summary>
        /// Creates a new ProductInventoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService ProductInventoryServiceProxyInstance()
        {
            return ProductInventoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductInventoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService ProductInventoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductInventoryService() as IProductInventoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductInventoryService == null)
                        {
                            factoryProductInventoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService>("ProductInventoryService");                            
                            factoryProductInventoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductInventoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductInventoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductInventoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductInventoryService.svc/gzip");                    
                    	factoryProductInventoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductInventoryService>(binding, endpoint);
                        factoryProductInventoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductInventoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductInventoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductInventoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductInventoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductListPriceHistoryService

        /// <summary>
        /// ProductListPriceHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService> factoryProductListPriceHistoryService = null;
                
        /// <summary>
        /// Creates a new ProductListPriceHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService ProductListPriceHistoryServiceProxyInstance()
        {
            return ProductListPriceHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductListPriceHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService ProductListPriceHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductListPriceHistoryService() as IProductListPriceHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductListPriceHistoryService == null)
                        {
                            factoryProductListPriceHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService>("ProductListPriceHistoryService");                            
                            factoryProductListPriceHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductListPriceHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductListPriceHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductListPriceHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductListPriceHistoryService.svc/gzip");                    
                    	factoryProductListPriceHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductListPriceHistoryService>(binding, endpoint);
                        factoryProductListPriceHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductListPriceHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductListPriceHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductListPriceHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductListPriceHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductModelService

        /// <summary>
        /// ProductModelService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelService> factoryProductModelService = null;
                
        /// <summary>
        /// Creates a new ProductModelService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelService ProductModelServiceProxyInstance()
        {
            return ProductModelServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductModelService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelService ProductModelServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductModelService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductModelService() as IProductModelService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductModelService == null)
                        {
                            factoryProductModelService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelService>("ProductModelService");                            
                            factoryProductModelService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductModelService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductModelService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductModelService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductModelService.svc/gzip");                    
                    	factoryProductModelService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelService>(binding, endpoint);
                        factoryProductModelService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductModelService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductModelService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductModelService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductModelService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductModelIllustrationService

        /// <summary>
        /// ProductModelIllustrationService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService> factoryProductModelIllustrationService = null;
                
        /// <summary>
        /// Creates a new ProductModelIllustrationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService ProductModelIllustrationServiceProxyInstance()
        {
            return ProductModelIllustrationServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductModelIllustrationService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService ProductModelIllustrationServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductModelIllustrationService() as IProductModelIllustrationService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductModelIllustrationService == null)
                        {
                            factoryProductModelIllustrationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService>("ProductModelIllustrationService");                            
                            factoryProductModelIllustrationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductModelIllustrationService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductModelIllustrationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductModelIllustrationService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductModelIllustrationService.svc/gzip");                    
                    	factoryProductModelIllustrationService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelIllustrationService>(binding, endpoint);
                        factoryProductModelIllustrationService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductModelIllustrationService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductModelIllustrationService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductModelIllustrationService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductModelIllustrationService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductModelProductDescriptionCultureService

        /// <summary>
        /// ProductModelProductDescriptionCultureService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService> factoryProductModelProductDescriptionCultureService = null;
                
        /// <summary>
        /// Creates a new ProductModelProductDescriptionCultureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService ProductModelProductDescriptionCultureServiceProxyInstance()
        {
            return ProductModelProductDescriptionCultureServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductModelProductDescriptionCultureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService ProductModelProductDescriptionCultureServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductModelProductDescriptionCultureService() as IProductModelProductDescriptionCultureService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductModelProductDescriptionCultureService == null)
                        {
                            factoryProductModelProductDescriptionCultureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService>("ProductModelProductDescriptionCultureService");                            
                            factoryProductModelProductDescriptionCultureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductModelProductDescriptionCultureService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductModelProductDescriptionCultureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductModelProductDescriptionCultureService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductModelProductDescriptionCultureService.svc/gzip");                    
                    	factoryProductModelProductDescriptionCultureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductModelProductDescriptionCultureService>(binding, endpoint);
                        factoryProductModelProductDescriptionCultureService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductModelProductDescriptionCultureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductModelProductDescriptionCultureService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductModelProductDescriptionCultureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductModelProductDescriptionCultureService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductPhotoService

        /// <summary>
        /// ProductPhotoService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService> factoryProductPhotoService = null;
                
        /// <summary>
        /// Creates a new ProductPhotoService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService ProductPhotoServiceProxyInstance()
        {
            return ProductPhotoServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductPhotoService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService ProductPhotoServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductPhotoService() as IProductPhotoService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductPhotoService == null)
                        {
                            factoryProductPhotoService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService>("ProductPhotoService");                            
                            factoryProductPhotoService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductPhotoService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductPhotoService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductPhotoService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductPhotoService.svc/gzip");                    
                    	factoryProductPhotoService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductPhotoService>(binding, endpoint);
                        factoryProductPhotoService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductPhotoService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductPhotoService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductPhotoService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductPhotoService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductProductPhotoService

        /// <summary>
        /// ProductProductPhotoService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService> factoryProductProductPhotoService = null;
                
        /// <summary>
        /// Creates a new ProductProductPhotoService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService ProductProductPhotoServiceProxyInstance()
        {
            return ProductProductPhotoServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductProductPhotoService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService ProductProductPhotoServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductProductPhotoService() as IProductProductPhotoService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductProductPhotoService == null)
                        {
                            factoryProductProductPhotoService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService>("ProductProductPhotoService");                            
                            factoryProductProductPhotoService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductProductPhotoService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductProductPhotoService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductProductPhotoService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductProductPhotoService.svc/gzip");                    
                    	factoryProductProductPhotoService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductProductPhotoService>(binding, endpoint);
                        factoryProductProductPhotoService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductProductPhotoService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductProductPhotoService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductProductPhotoService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductProductPhotoService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductReviewService

        /// <summary>
        /// ProductReviewService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductReviewService> factoryProductReviewService = null;
                
        /// <summary>
        /// Creates a new ProductReviewService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductReviewService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductReviewService ProductReviewServiceProxyInstance()
        {
            return ProductReviewServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductReviewService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductReviewService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductReviewService ProductReviewServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductReviewService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductReviewService() as IProductReviewService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductReviewService == null)
                        {
                            factoryProductReviewService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductReviewService>("ProductReviewService");                            
                            factoryProductReviewService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductReviewService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductReviewService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductReviewService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductReviewService.svc/gzip");                    
                    	factoryProductReviewService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductReviewService>(binding, endpoint);
                        factoryProductReviewService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductReviewService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductReviewService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductReviewService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductReviewService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductSubcategoryService

        /// <summary>
        /// ProductSubcategoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService> factoryProductSubcategoryService = null;
                
        /// <summary>
        /// Creates a new ProductSubcategoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService ProductSubcategoryServiceProxyInstance()
        {
            return ProductSubcategoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductSubcategoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService ProductSubcategoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductSubcategoryService() as IProductSubcategoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductSubcategoryService == null)
                        {
                            factoryProductSubcategoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService>("ProductSubcategoryService");                            
                            factoryProductSubcategoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductSubcategoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductSubcategoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductSubcategoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductSubcategoryService.svc/gzip");                    
                    	factoryProductSubcategoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductSubcategoryService>(binding, endpoint);
                        factoryProductSubcategoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductSubcategoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductSubcategoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductSubcategoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductSubcategoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ProductVendorService

        /// <summary>
        /// ProductVendorService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductVendorService> factoryProductVendorService = null;
                
        /// <summary>
        /// Creates a new ProductVendorService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductVendorService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductVendorService ProductVendorServiceProxyInstance()
        {
            return ProductVendorServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ProductVendorService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IProductVendorService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IProductVendorService ProductVendorServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IProductVendorService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ProductVendorService() as IProductVendorService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryProductVendorService == null)
                        {
                            factoryProductVendorService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductVendorService>("ProductVendorService");                            
                            factoryProductVendorService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryProductVendorService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryProductVendorService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryProductVendorService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ProductVendorService.svc/gzip");                    
                    	factoryProductVendorService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IProductVendorService>(binding, endpoint);
                        factoryProductVendorService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryProductVendorService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryProductVendorService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryProductVendorService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryProductVendorService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region PurchaseOrderDetailService

        /// <summary>
        /// PurchaseOrderDetailService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService> factoryPurchaseOrderDetailService = null;
                
        /// <summary>
        /// Creates a new PurchaseOrderDetailService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService PurchaseOrderDetailServiceProxyInstance()
        {
            return PurchaseOrderDetailServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new PurchaseOrderDetailService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService PurchaseOrderDetailServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new PurchaseOrderDetailService() as IPurchaseOrderDetailService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryPurchaseOrderDetailService == null)
                        {
                            factoryPurchaseOrderDetailService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService>("PurchaseOrderDetailService");                            
                            factoryPurchaseOrderDetailService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryPurchaseOrderDetailService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryPurchaseOrderDetailService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryPurchaseOrderDetailService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "PurchaseOrderDetailService.svc/gzip");                    
                    	factoryPurchaseOrderDetailService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderDetailService>(binding, endpoint);
                        factoryPurchaseOrderDetailService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryPurchaseOrderDetailService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryPurchaseOrderDetailService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryPurchaseOrderDetailService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryPurchaseOrderDetailService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region PurchaseOrderHeaderService

        /// <summary>
        /// PurchaseOrderHeaderService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService> factoryPurchaseOrderHeaderService = null;
                
        /// <summary>
        /// Creates a new PurchaseOrderHeaderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService PurchaseOrderHeaderServiceProxyInstance()
        {
            return PurchaseOrderHeaderServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new PurchaseOrderHeaderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService PurchaseOrderHeaderServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new PurchaseOrderHeaderService() as IPurchaseOrderHeaderService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryPurchaseOrderHeaderService == null)
                        {
                            factoryPurchaseOrderHeaderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService>("PurchaseOrderHeaderService");                            
                            factoryPurchaseOrderHeaderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryPurchaseOrderHeaderService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryPurchaseOrderHeaderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryPurchaseOrderHeaderService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "PurchaseOrderHeaderService.svc/gzip");                    
                    	factoryPurchaseOrderHeaderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IPurchaseOrderHeaderService>(binding, endpoint);
                        factoryPurchaseOrderHeaderService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryPurchaseOrderHeaderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryPurchaseOrderHeaderService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryPurchaseOrderHeaderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryPurchaseOrderHeaderService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesOrderDetailService

        /// <summary>
        /// SalesOrderDetailService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService> factorySalesOrderDetailService = null;
                
        /// <summary>
        /// Creates a new SalesOrderDetailService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService SalesOrderDetailServiceProxyInstance()
        {
            return SalesOrderDetailServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesOrderDetailService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService SalesOrderDetailServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesOrderDetailService() as ISalesOrderDetailService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesOrderDetailService == null)
                        {
                            factorySalesOrderDetailService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService>("SalesOrderDetailService");                            
                            factorySalesOrderDetailService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesOrderDetailService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesOrderDetailService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesOrderDetailService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesOrderDetailService.svc/gzip");                    
                    	factorySalesOrderDetailService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderDetailService>(binding, endpoint);
                        factorySalesOrderDetailService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesOrderDetailService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesOrderDetailService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesOrderDetailService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesOrderDetailService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesOrderHeaderService

        /// <summary>
        /// SalesOrderHeaderService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService> factorySalesOrderHeaderService = null;
                
        /// <summary>
        /// Creates a new SalesOrderHeaderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService SalesOrderHeaderServiceProxyInstance()
        {
            return SalesOrderHeaderServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesOrderHeaderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService SalesOrderHeaderServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesOrderHeaderService() as ISalesOrderHeaderService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesOrderHeaderService == null)
                        {
                            factorySalesOrderHeaderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService>("SalesOrderHeaderService");                            
                            factorySalesOrderHeaderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesOrderHeaderService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesOrderHeaderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesOrderHeaderService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesOrderHeaderService.svc/gzip");                    
                    	factorySalesOrderHeaderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderService>(binding, endpoint);
                        factorySalesOrderHeaderService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesOrderHeaderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesOrderHeaderService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesOrderHeaderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesOrderHeaderService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesOrderHeaderSalesReasonService

        /// <summary>
        /// SalesOrderHeaderSalesReasonService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService> factorySalesOrderHeaderSalesReasonService = null;
                
        /// <summary>
        /// Creates a new SalesOrderHeaderSalesReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService SalesOrderHeaderSalesReasonServiceProxyInstance()
        {
            return SalesOrderHeaderSalesReasonServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesOrderHeaderSalesReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService SalesOrderHeaderSalesReasonServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesOrderHeaderSalesReasonService() as ISalesOrderHeaderSalesReasonService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesOrderHeaderSalesReasonService == null)
                        {
                            factorySalesOrderHeaderSalesReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService>("SalesOrderHeaderSalesReasonService");                            
                            factorySalesOrderHeaderSalesReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesOrderHeaderSalesReasonService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesOrderHeaderSalesReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesOrderHeaderSalesReasonService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesOrderHeaderSalesReasonService.svc/gzip");                    
                    	factorySalesOrderHeaderSalesReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesOrderHeaderSalesReasonService>(binding, endpoint);
                        factorySalesOrderHeaderSalesReasonService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesOrderHeaderSalesReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesOrderHeaderSalesReasonService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesOrderHeaderSalesReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesOrderHeaderSalesReasonService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesPersonService

        /// <summary>
        /// SalesPersonService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService> factorySalesPersonService = null;
                
        /// <summary>
        /// Creates a new SalesPersonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService SalesPersonServiceProxyInstance()
        {
            return SalesPersonServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesPersonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService SalesPersonServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesPersonService() as ISalesPersonService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesPersonService == null)
                        {
                            factorySalesPersonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService>("SalesPersonService");                            
                            factorySalesPersonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesPersonService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesPersonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesPersonService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesPersonService.svc/gzip");                    
                    	factorySalesPersonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonService>(binding, endpoint);
                        factorySalesPersonService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesPersonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesPersonService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesPersonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesPersonService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesPersonQuotaHistoryService

        /// <summary>
        /// SalesPersonQuotaHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService> factorySalesPersonQuotaHistoryService = null;
                
        /// <summary>
        /// Creates a new SalesPersonQuotaHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService SalesPersonQuotaHistoryServiceProxyInstance()
        {
            return SalesPersonQuotaHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesPersonQuotaHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService SalesPersonQuotaHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesPersonQuotaHistoryService() as ISalesPersonQuotaHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesPersonQuotaHistoryService == null)
                        {
                            factorySalesPersonQuotaHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService>("SalesPersonQuotaHistoryService");                            
                            factorySalesPersonQuotaHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesPersonQuotaHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesPersonQuotaHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesPersonQuotaHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesPersonQuotaHistoryService.svc/gzip");                    
                    	factorySalesPersonQuotaHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesPersonQuotaHistoryService>(binding, endpoint);
                        factorySalesPersonQuotaHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesPersonQuotaHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesPersonQuotaHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesPersonQuotaHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesPersonQuotaHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesReasonService

        /// <summary>
        /// SalesReasonService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService> factorySalesReasonService = null;
                
        /// <summary>
        /// Creates a new SalesReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService SalesReasonServiceProxyInstance()
        {
            return SalesReasonServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService SalesReasonServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesReasonService() as ISalesReasonService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesReasonService == null)
                        {
                            factorySalesReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService>("SalesReasonService");                            
                            factorySalesReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesReasonService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesReasonService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesReasonService.svc/gzip");                    
                    	factorySalesReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesReasonService>(binding, endpoint);
                        factorySalesReasonService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesReasonService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesReasonService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesTaxRateService

        /// <summary>
        /// SalesTaxRateService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService> factorySalesTaxRateService = null;
                
        /// <summary>
        /// Creates a new SalesTaxRateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService SalesTaxRateServiceProxyInstance()
        {
            return SalesTaxRateServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesTaxRateService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService SalesTaxRateServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesTaxRateService() as ISalesTaxRateService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesTaxRateService == null)
                        {
                            factorySalesTaxRateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService>("SalesTaxRateService");                            
                            factorySalesTaxRateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesTaxRateService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesTaxRateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesTaxRateService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesTaxRateService.svc/gzip");                    
                    	factorySalesTaxRateService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTaxRateService>(binding, endpoint);
                        factorySalesTaxRateService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesTaxRateService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesTaxRateService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesTaxRateService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesTaxRateService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesTerritoryService

        /// <summary>
        /// SalesTerritoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService> factorySalesTerritoryService = null;
                
        /// <summary>
        /// Creates a new SalesTerritoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService SalesTerritoryServiceProxyInstance()
        {
            return SalesTerritoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesTerritoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService SalesTerritoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesTerritoryService() as ISalesTerritoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesTerritoryService == null)
                        {
                            factorySalesTerritoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService>("SalesTerritoryService");                            
                            factorySalesTerritoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesTerritoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesTerritoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesTerritoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesTerritoryService.svc/gzip");                    
                    	factorySalesTerritoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryService>(binding, endpoint);
                        factorySalesTerritoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesTerritoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesTerritoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesTerritoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesTerritoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SalesTerritoryHistoryService

        /// <summary>
        /// SalesTerritoryHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService> factorySalesTerritoryHistoryService = null;
                
        /// <summary>
        /// Creates a new SalesTerritoryHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService SalesTerritoryHistoryServiceProxyInstance()
        {
            return SalesTerritoryHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SalesTerritoryHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService SalesTerritoryHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SalesTerritoryHistoryService() as ISalesTerritoryHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySalesTerritoryHistoryService == null)
                        {
                            factorySalesTerritoryHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService>("SalesTerritoryHistoryService");                            
                            factorySalesTerritoryHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySalesTerritoryHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySalesTerritoryHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySalesTerritoryHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SalesTerritoryHistoryService.svc/gzip");                    
                    	factorySalesTerritoryHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISalesTerritoryHistoryService>(binding, endpoint);
                        factorySalesTerritoryHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySalesTerritoryHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySalesTerritoryHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySalesTerritoryHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySalesTerritoryHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ScrapReasonService

        /// <summary>
        /// ScrapReasonService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService> factoryScrapReasonService = null;
                
        /// <summary>
        /// Creates a new ScrapReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService ScrapReasonServiceProxyInstance()
        {
            return ScrapReasonServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ScrapReasonService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService ScrapReasonServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ScrapReasonService() as IScrapReasonService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryScrapReasonService == null)
                        {
                            factoryScrapReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService>("ScrapReasonService");                            
                            factoryScrapReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryScrapReasonService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryScrapReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryScrapReasonService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ScrapReasonService.svc/gzip");                    
                    	factoryScrapReasonService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IScrapReasonService>(binding, endpoint);
                        factoryScrapReasonService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryScrapReasonService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryScrapReasonService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryScrapReasonService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryScrapReasonService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ShiftService

        /// <summary>
        /// ShiftService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShiftService> factoryShiftService = null;
                
        /// <summary>
        /// Creates a new ShiftService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShiftService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShiftService ShiftServiceProxyInstance()
        {
            return ShiftServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ShiftService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShiftService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShiftService ShiftServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IShiftService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ShiftService() as IShiftService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryShiftService == null)
                        {
                            factoryShiftService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShiftService>("ShiftService");                            
                            factoryShiftService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryShiftService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryShiftService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryShiftService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ShiftService.svc/gzip");                    
                    	factoryShiftService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShiftService>(binding, endpoint);
                        factoryShiftService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryShiftService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryShiftService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryShiftService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryShiftService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ShipMethodService

        /// <summary>
        /// ShipMethodService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShipMethodService> factoryShipMethodService = null;
                
        /// <summary>
        /// Creates a new ShipMethodService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShipMethodService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShipMethodService ShipMethodServiceProxyInstance()
        {
            return ShipMethodServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ShipMethodService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShipMethodService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShipMethodService ShipMethodServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IShipMethodService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ShipMethodService() as IShipMethodService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryShipMethodService == null)
                        {
                            factoryShipMethodService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShipMethodService>("ShipMethodService");                            
                            factoryShipMethodService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryShipMethodService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryShipMethodService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryShipMethodService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ShipMethodService.svc/gzip");                    
                    	factoryShipMethodService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShipMethodService>(binding, endpoint);
                        factoryShipMethodService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryShipMethodService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryShipMethodService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryShipMethodService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryShipMethodService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region ShoppingCartItemService

        /// <summary>
        /// ShoppingCartItemService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService> factoryShoppingCartItemService = null;
                
        /// <summary>
        /// Creates a new ShoppingCartItemService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService ShoppingCartItemServiceProxyInstance()
        {
            return ShoppingCartItemServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new ShoppingCartItemService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService ShoppingCartItemServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new ShoppingCartItemService() as IShoppingCartItemService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryShoppingCartItemService == null)
                        {
                            factoryShoppingCartItemService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService>("ShoppingCartItemService");                            
                            factoryShoppingCartItemService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryShoppingCartItemService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryShoppingCartItemService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryShoppingCartItemService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "ShoppingCartItemService.svc/gzip");                    
                    	factoryShoppingCartItemService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IShoppingCartItemService>(binding, endpoint);
                        factoryShoppingCartItemService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryShoppingCartItemService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryShoppingCartItemService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryShoppingCartItemService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryShoppingCartItemService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SpecialOfferService

        /// <summary>
        /// SpecialOfferService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService> factorySpecialOfferService = null;
                
        /// <summary>
        /// Creates a new SpecialOfferService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService SpecialOfferServiceProxyInstance()
        {
            return SpecialOfferServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SpecialOfferService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService SpecialOfferServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SpecialOfferService() as ISpecialOfferService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySpecialOfferService == null)
                        {
                            factorySpecialOfferService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService>("SpecialOfferService");                            
                            factorySpecialOfferService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySpecialOfferService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySpecialOfferService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySpecialOfferService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SpecialOfferService.svc/gzip");                    
                    	factorySpecialOfferService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferService>(binding, endpoint);
                        factorySpecialOfferService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySpecialOfferService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySpecialOfferService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySpecialOfferService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySpecialOfferService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region SpecialOfferProductService

        /// <summary>
        /// SpecialOfferProductService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService> factorySpecialOfferProductService = null;
                
        /// <summary>
        /// Creates a new SpecialOfferProductService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService SpecialOfferProductServiceProxyInstance()
        {
            return SpecialOfferProductServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new SpecialOfferProductService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService SpecialOfferProductServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new SpecialOfferProductService() as ISpecialOfferProductService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factorySpecialOfferProductService == null)
                        {
                            factorySpecialOfferProductService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService>("SpecialOfferProductService");                            
                            factorySpecialOfferProductService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factorySpecialOfferProductService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factorySpecialOfferProductService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factorySpecialOfferProductService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "SpecialOfferProductService.svc/gzip");                    
                    	factorySpecialOfferProductService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ISpecialOfferProductService>(binding, endpoint);
                        factorySpecialOfferProductService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factorySpecialOfferProductService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factorySpecialOfferProductService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factorySpecialOfferProductService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factorySpecialOfferProductService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region StateProvinceService

        /// <summary>
        /// StateProvinceService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService> factoryStateProvinceService = null;
                
        /// <summary>
        /// Creates a new StateProvinceService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService StateProvinceServiceProxyInstance()
        {
            return StateProvinceServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new StateProvinceService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService StateProvinceServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new StateProvinceService() as IStateProvinceService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryStateProvinceService == null)
                        {
                            factoryStateProvinceService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService>("StateProvinceService");                            
                            factoryStateProvinceService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryStateProvinceService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryStateProvinceService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryStateProvinceService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "StateProvinceService.svc/gzip");                    
                    	factoryStateProvinceService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStateProvinceService>(binding, endpoint);
                        factoryStateProvinceService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryStateProvinceService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryStateProvinceService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryStateProvinceService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryStateProvinceService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region StoreService

        /// <summary>
        /// StoreService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreService> factoryStoreService = null;
                
        /// <summary>
        /// Creates a new StoreService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStoreService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStoreService StoreServiceProxyInstance()
        {
            return StoreServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new StoreService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStoreService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStoreService StoreServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IStoreService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new StoreService() as IStoreService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryStoreService == null)
                        {
                            factoryStoreService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreService>("StoreService");                            
                            factoryStoreService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryStoreService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryStoreService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryStoreService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "StoreService.svc/gzip");                    
                    	factoryStoreService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreService>(binding, endpoint);
                        factoryStoreService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryStoreService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryStoreService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryStoreService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryStoreService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region StoreContactService

        /// <summary>
        /// StoreContactService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreContactService> factoryStoreContactService = null;
                
        /// <summary>
        /// Creates a new StoreContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStoreContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStoreContactService StoreContactServiceProxyInstance()
        {
            return StoreContactServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new StoreContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IStoreContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IStoreContactService StoreContactServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IStoreContactService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new StoreContactService() as IStoreContactService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryStoreContactService == null)
                        {
                            factoryStoreContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreContactService>("StoreContactService");                            
                            factoryStoreContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryStoreContactService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryStoreContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryStoreContactService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "StoreContactService.svc/gzip");                    
                    	factoryStoreContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IStoreContactService>(binding, endpoint);
                        factoryStoreContactService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryStoreContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryStoreContactService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryStoreContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryStoreContactService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region TestVariantService

        /// <summary>
        /// TestVariantService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITestVariantService> factoryTestVariantService = null;
                
        /// <summary>
        /// Creates a new TestVariantService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITestVariantService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITestVariantService TestVariantServiceProxyInstance()
        {
            return TestVariantServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new TestVariantService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITestVariantService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITestVariantService TestVariantServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ITestVariantService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new TestVariantService() as ITestVariantService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryTestVariantService == null)
                        {
                            factoryTestVariantService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITestVariantService>("TestVariantService");                            
                            factoryTestVariantService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryTestVariantService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryTestVariantService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryTestVariantService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "TestVariantService.svc/gzip");                    
                    	factoryTestVariantService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITestVariantService>(binding, endpoint);
                        factoryTestVariantService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryTestVariantService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryTestVariantService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryTestVariantService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryTestVariantService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region TimestampPkService

        /// <summary>
        /// TimestampPkService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService> factoryTimestampPkService = null;
                
        /// <summary>
        /// Creates a new TimestampPkService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService TimestampPkServiceProxyInstance()
        {
            return TimestampPkServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new TimestampPkService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService TimestampPkServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new TimestampPkService() as ITimestampPkService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryTimestampPkService == null)
                        {
                            factoryTimestampPkService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService>("TimestampPkService");                            
                            factoryTimestampPkService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryTimestampPkService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryTimestampPkService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryTimestampPkService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "TimestampPkService.svc/gzip");                    
                    	factoryTimestampPkService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITimestampPkService>(binding, endpoint);
                        factoryTimestampPkService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryTimestampPkService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryTimestampPkService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryTimestampPkService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryTimestampPkService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region TransactionHistoryService

        /// <summary>
        /// TransactionHistoryService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService> factoryTransactionHistoryService = null;
                
        /// <summary>
        /// Creates a new TransactionHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService TransactionHistoryServiceProxyInstance()
        {
            return TransactionHistoryServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new TransactionHistoryService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService TransactionHistoryServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new TransactionHistoryService() as ITransactionHistoryService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryTransactionHistoryService == null)
                        {
                            factoryTransactionHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService>("TransactionHistoryService");                            
                            factoryTransactionHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryTransactionHistoryService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryTransactionHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryTransactionHistoryService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "TransactionHistoryService.svc/gzip");                    
                    	factoryTransactionHistoryService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryService>(binding, endpoint);
                        factoryTransactionHistoryService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryTransactionHistoryService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryTransactionHistoryService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryTransactionHistoryService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryTransactionHistoryService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region TransactionHistoryArchiveService

        /// <summary>
        /// TransactionHistoryArchiveService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService> factoryTransactionHistoryArchiveService = null;
                
        /// <summary>
        /// Creates a new TransactionHistoryArchiveService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService TransactionHistoryArchiveServiceProxyInstance()
        {
            return TransactionHistoryArchiveServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new TransactionHistoryArchiveService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService TransactionHistoryArchiveServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new TransactionHistoryArchiveService() as ITransactionHistoryArchiveService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryTransactionHistoryArchiveService == null)
                        {
                            factoryTransactionHistoryArchiveService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService>("TransactionHistoryArchiveService");                            
                            factoryTransactionHistoryArchiveService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryTransactionHistoryArchiveService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryTransactionHistoryArchiveService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryTransactionHistoryArchiveService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "TransactionHistoryArchiveService.svc/gzip");                    
                    	factoryTransactionHistoryArchiveService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.ITransactionHistoryArchiveService>(binding, endpoint);
                        factoryTransactionHistoryArchiveService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryTransactionHistoryArchiveService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryTransactionHistoryArchiveService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryTransactionHistoryArchiveService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryTransactionHistoryArchiveService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region UnitMeasureService

        /// <summary>
        /// UnitMeasureService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService> factoryUnitMeasureService = null;
                
        /// <summary>
        /// Creates a new UnitMeasureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService UnitMeasureServiceProxyInstance()
        {
            return UnitMeasureServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new UnitMeasureService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService UnitMeasureServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new UnitMeasureService() as IUnitMeasureService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryUnitMeasureService == null)
                        {
                            factoryUnitMeasureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService>("UnitMeasureService");                            
                            factoryUnitMeasureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryUnitMeasureService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryUnitMeasureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryUnitMeasureService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "UnitMeasureService.svc/gzip");                    
                    	factoryUnitMeasureService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IUnitMeasureService>(binding, endpoint);
                        factoryUnitMeasureService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryUnitMeasureService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryUnitMeasureService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryUnitMeasureService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryUnitMeasureService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region VendorService

        /// <summary>
        /// VendorService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorService> factoryVendorService = null;
                
        /// <summary>
        /// Creates a new VendorService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorService VendorServiceProxyInstance()
        {
            return VendorServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new VendorService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorService VendorServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IVendorService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new VendorService() as IVendorService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryVendorService == null)
                        {
                            factoryVendorService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorService>("VendorService");                            
                            factoryVendorService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryVendorService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryVendorService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryVendorService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "VendorService.svc/gzip");                    
                    	factoryVendorService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorService>(binding, endpoint);
                        factoryVendorService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryVendorService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryVendorService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryVendorService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryVendorService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region VendorAddressService

        /// <summary>
        /// VendorAddressService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService> factoryVendorAddressService = null;
                
        /// <summary>
        /// Creates a new VendorAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService VendorAddressServiceProxyInstance()
        {
            return VendorAddressServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new VendorAddressService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService VendorAddressServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new VendorAddressService() as IVendorAddressService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryVendorAddressService == null)
                        {
                            factoryVendorAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService>("VendorAddressService");                            
                            factoryVendorAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryVendorAddressService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryVendorAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryVendorAddressService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "VendorAddressService.svc/gzip");                    
                    	factoryVendorAddressService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorAddressService>(binding, endpoint);
                        factoryVendorAddressService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryVendorAddressService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryVendorAddressService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryVendorAddressService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryVendorAddressService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region VendorContactService

        /// <summary>
        /// VendorContactService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorContactService> factoryVendorContactService = null;
                
        /// <summary>
        /// Creates a new VendorContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorContactService VendorContactServiceProxyInstance()
        {
            return VendorContactServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new VendorContactService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IVendorContactService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IVendorContactService VendorContactServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IVendorContactService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new VendorContactService() as IVendorContactService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryVendorContactService == null)
                        {
                            factoryVendorContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorContactService>("VendorContactService");                            
                            factoryVendorContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryVendorContactService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryVendorContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryVendorContactService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "VendorContactService.svc/gzip");                    
                    	factoryVendorContactService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IVendorContactService>(binding, endpoint);
                        factoryVendorContactService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryVendorContactService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryVendorContactService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryVendorContactService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryVendorContactService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region WorkOrderService

        /// <summary>
        /// WorkOrderService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService> factoryWorkOrderService = null;
                
        /// <summary>
        /// Creates a new WorkOrderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService WorkOrderServiceProxyInstance()
        {
            return WorkOrderServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new WorkOrderService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService WorkOrderServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new WorkOrderService() as IWorkOrderService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryWorkOrderService == null)
                        {
                            factoryWorkOrderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService>("WorkOrderService");                            
                            factoryWorkOrderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryWorkOrderService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryWorkOrderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryWorkOrderService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "WorkOrderService.svc/gzip");                    
                    	factoryWorkOrderService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderService>(binding, endpoint);
                        factoryWorkOrderService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryWorkOrderService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryWorkOrderService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryWorkOrderService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryWorkOrderService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        
        #region WorkOrderRoutingService

        /// <summary>
        /// WorkOrderRoutingService Channel Factory
        /// </summary>
        static ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService> factoryWorkOrderRoutingService = null;
                
        /// <summary>
        /// Creates a new WorkOrderRoutingService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService WorkOrderRoutingServiceProxyInstance()
        {
            return WorkOrderRoutingServiceProxyInstance(defaultPlatform);
        }

        /// <summary>
        /// Creates a new WorkOrderRoutingService proxy instance
        /// </summary>
        /// <returns>Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService</returns>
        public static Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService WorkOrderRoutingServiceProxyInstance(CommunicationPlatform platform)
        {
            Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService proxy = null;

            try
            {
                switch (platform)
                {
                    case CommunicationPlatform.Direct:
                        proxy = new WorkOrderRoutingService() as IWorkOrderRoutingService;
                        break;

                    case CommunicationPlatform.WCF:
                        if (factoryWorkOrderRoutingService == null)
                        {
                            factoryWorkOrderRoutingService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService>("WorkOrderRoutingService");                            
                            factoryWorkOrderRoutingService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                            //factoryWorkOrderRoutingService.Credentials.Windows.AllowNtlm = true;
                        }

                        if (ClientCredentials != null)
                            factoryWorkOrderRoutingService.Credentials.Windows.ClientCredential = ClientCredentials;    
                            
                        proxy = factoryWorkOrderRoutingService.CreateChannel();
                        break;
						
					case CommunicationPlatform.BaseAddress:
                         CustomBinding binding = new CustomBinding(bindingConfigName);
                        //WSHttpBinding binding = new WSHttpBinding("WSHttpBindingConfig");
                        //BasicHttpBinding binding = new BasicHttpBinding("BasicHttpBindingConfig");
                    	EndpointAddress endpoint = new EndpointAddress(BaseAddress + "WorkOrderRoutingService.svc/gzip");                    
                    	factoryWorkOrderRoutingService = new ChannelFactory<Nettiers.AdventureWorks.Contracts.Services.IWorkOrderRoutingService>(binding, endpoint);
                        factoryWorkOrderRoutingService.Endpoint.Behaviors.Add(new SecurityEndpointBehavior());
                        factoryWorkOrderRoutingService.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                        //factoryWorkOrderRoutingService.Credentials.Windows.AllowNtlm = true;
                        
                        if (ClientCredentials != null)
                            factoryWorkOrderRoutingService.Credentials.Windows.ClientCredential = ClientCredentials;    
                        
						proxy = factoryWorkOrderRoutingService.CreateChannel();
						break;
                }
                
                if (proxy != null)
                {
                    OperationContextScope scope = new OperationContextScope((IContextChannel)proxy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proxy;
        }
                        
        #endregion
        

	} // End Class
} // End Namespace
