using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace {RootNamespace}.DataAccess
{
    public partial class {DataContextName}ObjectContext
    {
        public static {DataContextName}ObjectContext Create()
        {
            return new {DataContextName}ObjectContext();
        }
    }
}
