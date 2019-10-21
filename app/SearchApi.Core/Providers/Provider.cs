using System;
using Newtonsoft.Json;

namespace SearchApi.Core.Providers
{
    /// <summary>
    /// Represents a data provider.
    /// Data providers are entity that can deliver information about a person
    /// </summary>
    public class Provider
    {

        /// <summary>
        /// The Name of the Providers.
        /// </summary>
        public String Name { get; set; }

    }
}