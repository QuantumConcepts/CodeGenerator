using System;

namespace QuantumConcepts.CodeGenerator.Sample.DataObjects
{
	/// <summary>Maps to the Status column.</summary>
	public enum CourseStatus
	{
		/// <summary>Enrolling: Enrolling. (Database Value: Enrolling</summary>
		Enrolling,
		
		/// <summary>Active: Active. (Database Value: Active</summary>
		Active,
		
		/// <summary>Inactive: Inactive. (Database Value: Inactive</summary>
		Inactive
	}
}