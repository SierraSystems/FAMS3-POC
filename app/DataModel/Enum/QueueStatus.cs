using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Enum
{
    public enum  QueueStatus
    {
        ReadyForSearch=0,
        SearchInProgress=1,
        SearchCompleted=2
    }

    public static class QueueStatusExtensions
    {
        public static string GetName(this QueueStatus queryStatus)
        {
            return System.Enum.GetName(typeof(QueueStatus), queryStatus);
        }
    }
}
