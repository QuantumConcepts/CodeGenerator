using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.REST
{
	/// <summary>Exposes functionality through one or more service end points.</summary>
	public enum LinkType
	{
		Course,
		Courses,
		Enrollment,
		Enrollments,
		Major,
		Majors,
		Semester,
		Semesters,
		Student,
		Students,
		Teacher,
		Teachers
	}
}