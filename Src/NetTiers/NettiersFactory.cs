//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Configuration Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

namespace NetTiers
{
  /// <summary>
  /// Static factory class used to get instances of an <see cref="IGreetingProvider"/>.
  /// </summary>
  public sealed class NetTiersFactory
  {
    private static NetTiersDataProviderFactory factory = new NetTiersDataProviderFactory();
    private static object lockObject = new object();

    private NetTiersFactory()
    {
    }

    /// <summary>
    /// Returns the default <see cref="INetTiersDataProvider"/> instance. 
    /// Guaranteed to return an intialized <see cref="IGreetingProvider"/> if no exception thrown
    /// </summary>
    /// <returns>Default <see cref="INetTiersDataProvider"/> instance.</returns>
    /// <exception cref="ConfigurationException">Unable to create default <see cref="IGreetingProvider"/>.</exception>
    public static INetTiersDataProvider GetNetTiersProvider()
    {
      lock (lockObject)
      {
        return factory.GetNetTiersProvider();
      }
    }

    /// <summary>
    /// Returns the named <see cref="INetTiersDataProvider"/> instance. Guaranteed to return an initialized <see cref="INetTiersDataProvider"/> if no exception thrown.
    /// </summary>
    /// <param name="providerName">Name defined in configuration of the <see cref="INetTiersDataProvider"/> to instantiate.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">providerName is null</exception>
    /// <exception cref="ArgumentException">providerName is empty</exception>
    /// <exception cref="ConfigurationException">Could not find instance specified in providerName</exception>
    /// <exception cref="InvalidOperationException">Error processing configuration information defined in application configuration file.</exception>
    public static INetTiersDataProvider GetNetTiersProvider(string providerName)
    {
      lock (lockObject)
      {
        return factory.GetNetTiersProvider(providerName);
      }
    }
  }
}