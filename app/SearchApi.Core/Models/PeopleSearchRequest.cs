using System.ComponentModel;
using Newtonsoft.Json;

namespace SearchApi.Core.Models
{
    [Description("A people search request")]
    public class PeopleSearchRequest
    {
   
        [JsonConstructor]
        public PeopleSearchRequest(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        
        [Description("A person first name.")]
        public string FirstName { get; private set; }
        [Description("A person first name.")]
        public string LastName { get; private set; }
        [Description("A person email.")]
        public string Email { get; private set; }

    }
}