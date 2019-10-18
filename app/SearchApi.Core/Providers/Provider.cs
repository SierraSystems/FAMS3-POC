using System;

namespace SearchApi.Core.Providers
{
    /// <summary>
    /// Represents a data provider.
    /// Data providers are entity that can deliver information about a person
    /// </summary>
    public class Provider
    {

        protected Provider() { }

        private Provider(Guid id, String name)
        {
            if(id == default(Guid)) throw new ArgumentNullException(nameof(id));
            if(String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Unique identifier of the Provider.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// The Name of the Providers.
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Creates a new Provider
        /// </summary>
        /// <param name="name">The name of the provider</param>
        /// <returns></returns>
        public static Provider Create(string name)
        {
            return new Provider(Guid.NewGuid(), name);
        }

    }
}