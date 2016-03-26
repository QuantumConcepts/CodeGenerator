using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace  QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects
{
	/// <summary>Maps to the Course table in the database.</summary>
	[DataContract]
	public abstract partial class Course : DataObjects.Course
	{
		protected static void Copy(DataAccess.Course obj, Course newObj)
		{
			newObj.ID = obj.ID;
			newObj.SemesterID = obj.SemesterID;
			newObj.TeacherID = obj.TeacherID;
			newObj.Number = obj.Number;
			newObj.Name = obj.Name;
			newObj.Status = obj.Status;
		}
	}

	/// <summary>Maps to the Enrollment table in the database.</summary>
	[DataContract]
	public abstract partial class Enrollment : DataObjects.Enrollment
	{
		protected static void Copy(DataAccess.Enrollment obj, Enrollment newObj)
		{
			newObj.ID = obj.ID;
			newObj.StudentID = obj.StudentID;
			newObj.CourseID = obj.CourseID;
		}
	}

	/// <summary>Maps to the Major table in the database.</summary>
	[DataContract]
	public abstract partial class Major : DataObjects.Major
	{
		protected static void Copy(DataAccess.Major obj, Major newObj)
		{
			newObj.ID = obj.ID;
			newObj.Name = obj.Name;
		}
	}

	/// <summary>Maps to the Semester table in the database.</summary>
	[DataContract]
	public abstract partial class Semester : DataObjects.Semester
	{
		protected static void Copy(DataAccess.Semester obj, Semester newObj)
		{
			newObj.ID = obj.ID;
			newObj.Begin = obj.Begin;
			newObj.End = obj.End;
			newObj.Name = obj.Name;
		}
	}

	/// <summary>Maps to the Student table in the database.</summary>
	[DataContract]
	public abstract partial class Student : DataObjects.Student
	{
		protected static void Copy(DataAccess.Student obj, Student newObj)
		{
			newObj.ID = obj.ID;
			newObj.MajorID = obj.MajorID;
			newObj.SSN = obj.SSN;
			newObj.FirstName = obj.FirstName;
			newObj.LastName = obj.LastName;
			newObj.Active = obj.Active;
		}
	}

	/// <summary>Maps to the Teacher table in the database.</summary>
	[DataContract]
	public abstract partial class Teacher : DataObjects.Teacher
	{
		protected static void Copy(DataAccess.Teacher obj, Teacher newObj)
		{
			newObj.ID = obj.ID;
			newObj.SSN = obj.SSN;
			newObj.FirstName = obj.FirstName;
			newObj.LastName = obj.LastName;
			newObj.Active = obj.Active;
		}
	}

}