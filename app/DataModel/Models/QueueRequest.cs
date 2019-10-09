using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Enum;

namespace DataModel.Models
{
    public class QueueRequest : Person
    {
       public QueueStatus Persons { get; set; }
    }
}
