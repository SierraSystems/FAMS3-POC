using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Enum;
namespace DataModel.Models
{
    public class SearchResult<T>
    {
        public string RequestId { get; set; }
        public ResultTypes Type { get; set; }
        public string Provider { get; set; }
        public T Value { get; set; }
    }
}
