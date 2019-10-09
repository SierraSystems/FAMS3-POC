using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Enum
{
    public enum  ResultTypes
    {
        Address,
        Phone,
        Investment,
        BankAccounts
    }

    public static class ResultTypesExtensions
    {
        public static string GetName(this ResultTypes resultType)
        {
            return System.Enum.GetName(typeof(ResultTypes), resultType);
        }
    }
}
