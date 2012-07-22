using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace QuantumConcepts.CodeGenerator.Sample.Service.Utils
{
    public static class ServiceUtil
    {
        public const int PageSize = 1000;

        public static IEnumerable<T> GetPage<T>(IEnumerable<T> items, int page)
        {
            if (items == null)
                return null;
            else
            {
                if (page < 1)
                    page = 1;

                return items.Skip((page - 1) * ServiceUtil.PageSize).Take(ServiceUtil.PageSize);
            }
        }

        public static int GetPageCount(int itemCount)
        {
            return (int)Math.Ceiling(itemCount / (decimal)ServiceUtil.PageSize);
        }
    }
}
