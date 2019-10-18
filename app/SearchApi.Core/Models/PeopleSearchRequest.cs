using Newtonsoft.Json;

namespace SearchApi.Core.Models
{
    public class PeopleSearchRequest
    {

        [JsonConstructor]
        public PeopleSearchRequest(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

    }
}