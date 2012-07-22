using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess.Cache
{
    /// <summary>This interface marks an object as a cache object.</summary>
    public interface ICache
    {
        /// <summary>This method does not perform any operation but will cause the static initializer to fire.</summary>
        void Touch();

        /// <summary>Refreshes the cache.</summary>
        void Refresh();
    }
}
