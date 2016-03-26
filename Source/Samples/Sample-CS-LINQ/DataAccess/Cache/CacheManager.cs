using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess.Cache
{
    /// <summary>This class keeps track of all cache objects.</summary>
    public static class CacheManager
    {
        private static List<ICache> _caches = new List<ICache>();

        /// <summary>Registers the specified cache with the CacheManager.</summary>
        /// <param name="cache">The cache to register.</param>
        public static void Register(ICache cache)
        {
            //Refresh the cache.
            cache.Refresh();

            //Add it to the list of caches.
            _caches.Add(cache);
        }

        /// <summary>Refreshes all of the caches.</summary>
        public static void RefreshAll()
        {
            foreach (ICache c in _caches)
            {
                lock (typeof(CacheManager))
                {
                    c.Refresh();
                }
            }
        }
    }
}
