using System;

namespace DataModel.Models
{
    public class Person
    {
        public string SocialInsuranceNumber{ get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
