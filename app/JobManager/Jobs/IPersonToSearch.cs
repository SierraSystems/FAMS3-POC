using DataModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JobManager.Jobs
{
    public interface IPersonToSearch
    {
        List<PersonSought> Get();
    }
    public class PersonToSearch : IPersonToSearch
    {
        public List<PersonSought> Get()
        {
            return new List<PersonSought>();
        }


    }
}
