using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace  QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.SOAP
{
	[DataContract]
	public partial class Course : ServiceObjects.Course
	{
		public static Course FromDataAccessObject(DataAccess.Course obj)
		{
			if (obj == null)
				return null;

            Course newObj = new Course();
			ServiceObjects.Course.Copy(obj, newObj);
			
			return newObj;
		}
	}

	[DataContract]
	public partial class Enrollment : ServiceObjects.Enrollment
	{
		public static Enrollment FromDataAccessObject(DataAccess.Enrollment obj)
		{
			if (obj == null)
				return null;

            Enrollment newObj = new Enrollment();
			ServiceObjects.Enrollment.Copy(obj, newObj);
			
			return newObj;
		}
	}

	[DataContract]
	public partial class Major : ServiceObjects.Major
	{
		public static Major FromDataAccessObject(DataAccess.Major obj)
		{
			if (obj == null)
				return null;

            Major newObj = new Major();
			ServiceObjects.Major.Copy(obj, newObj);
			
			return newObj;
		}
	}

	[DataContract]
	public partial class Semester : ServiceObjects.Semester
	{
		public static Semester FromDataAccessObject(DataAccess.Semester obj)
		{
			if (obj == null)
				return null;

            Semester newObj = new Semester();
			ServiceObjects.Semester.Copy(obj, newObj);
			
			return newObj;
		}
	}

	[DataContract]
	public partial class Student : ServiceObjects.Student
	{
		public static Student FromDataAccessObject(DataAccess.Student obj)
		{
			if (obj == null)
				return null;

            Student newObj = new Student();
			ServiceObjects.Student.Copy(obj, newObj);
			
			return newObj;
		}
	}

	[DataContract]
	public partial class Teacher : ServiceObjects.Teacher
	{
		public static Teacher FromDataAccessObject(DataAccess.Teacher obj)
		{
			if (obj == null)
				return null;

            Teacher newObj = new Teacher();
			ServiceObjects.Teacher.Copy(obj, newObj);
			
			return newObj;
		}
	}

}