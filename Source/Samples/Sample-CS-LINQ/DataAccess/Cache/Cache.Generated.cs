using System;
using System.Collections.Generic;
using System.Linq;
using QuantumConcepts.CodeGenerator.Sample.Common;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess.Cache
{
	/// <summary>Implements caching for the Major class.</summary>
	public partial class MajorCache : Cache<Major, int>
	{
        private static MajorCache _instance = null;

        /// <summary>Gets the singleton instance for the cache.</summary>
        public static MajorCache Instance { get { return _instance; } }
        
		static MajorCache()
		{
            _instance = new MajorCache();
			CacheManager.Register(new MajorCache());
			
			// Listen for changes and refresh the cache as needed.
			Major.CacheNeedsRefresh += new ParameterlessDelegate(delegate() { MajorCache.Instance.Refresh(); });
		}

		/// <summary>This method does not perform any operation but will cause the static initializer to fire.</summary>
		public override void Touch() {}

		/// <summary>Extracts the primary key from the provided Major.</summary>
		/// <param name="item">The Major from which the primary key should be extracted.</param>
		/// <returns>The primary key of the item.</returns>
		protected override int GetKey(Major o)
		{
			return o.ID;
		}

		/// <summary>Refreshes the Major cache.</summary>
		protected override void DoRefresh()
		{
			this.CachedItems = Major.GetAll().ToList();
			DoCustomRefresh();
		}

		partial void DoCustomRefresh();
	}

	/// <summary>Implements caching for the Semester class.</summary>
	public partial class SemesterCache : Cache<Semester, int>
	{
        private static SemesterCache _instance = null;

        /// <summary>Gets the singleton instance for the cache.</summary>
        public static SemesterCache Instance { get { return _instance; } }
        
		static SemesterCache()
		{
            _instance = new SemesterCache();
			CacheManager.Register(new SemesterCache());
			
			// Listen for changes and refresh the cache as needed.
			Semester.CacheNeedsRefresh += new ParameterlessDelegate(delegate() { SemesterCache.Instance.Refresh(); });
		}

		/// <summary>This method does not perform any operation but will cause the static initializer to fire.</summary>
		public override void Touch() {}

		/// <summary>Extracts the primary key from the provided Semester.</summary>
		/// <param name="item">The Semester from which the primary key should be extracted.</param>
		/// <returns>The primary key of the item.</returns>
		protected override int GetKey(Semester o)
		{
			return o.ID;
		}

		/// <summary>Refreshes the Semester cache.</summary>
		protected override void DoRefresh()
		{
			this.CachedItems = Semester.GetAll().ToList();
			DoCustomRefresh();
		}

		partial void DoCustomRefresh();
	}
}