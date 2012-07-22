using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using QuantumConcepts.CodeGenerator.Sample.Service.Utils;

namespace  QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.REST
{
	/// <summary>Maps to the Course table in the database.</summary>
	[DataContract]
	public partial class Course : ServiceObjects.Course
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Course()
		{
			this.Links = new List<Link>();
		}
		
		public static Course FromDataAccessObject(DataAccess.Course obj)
		{
			if (obj == null)
				return null;

            Course newObj = new Course();
			ServiceObjects.Course.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Semester", LinkType.Semester, RESTUrlUtil.Service.RESTSvc.GetSemesterByID(newObj.SemesterID)));
			newObj.Links.Add(new Link("Teacher", LinkType.Teacher, RESTUrlUtil.Service.RESTSvc.GetTeacherByID(newObj.TeacherID)));
			newObj.Links.Add(new Link("Enrollments", LinkType.Enrollments, RESTUrlUtil.Service.RESTSvc.GetEnrollmentsByCourseID(newObj.ID, 1)));
			
			return newObj;
		}
	}

	/// <summary>Maps to the Enrollment table in the database.</summary>
	[DataContract]
	public partial class Enrollment : ServiceObjects.Enrollment
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Enrollment()
		{
			this.Links = new List<Link>();
		}
		
		public static Enrollment FromDataAccessObject(DataAccess.Enrollment obj)
		{
			if (obj == null)
				return null;

            Enrollment newObj = new Enrollment();
			ServiceObjects.Enrollment.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Student", LinkType.Student, RESTUrlUtil.Service.RESTSvc.GetStudentByID(newObj.StudentID)));
			newObj.Links.Add(new Link("Course", LinkType.Course, RESTUrlUtil.Service.RESTSvc.GetCourseByID(newObj.CourseID)));
			
			return newObj;
		}
	}

	/// <summary>Maps to the Major table in the database.</summary>
	[DataContract]
	public partial class Major : ServiceObjects.Major
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Major()
		{
			this.Links = new List<Link>();
		}
		
		public static Major FromDataAccessObject(DataAccess.Major obj)
		{
			if (obj == null)
				return null;

            Major newObj = new Major();
			ServiceObjects.Major.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Students", LinkType.Students, RESTUrlUtil.Service.RESTSvc.GetStudentsByMajorID(newObj.ID, 1)));
			
			return newObj;
		}
	}

	/// <summary>Maps to the Semester table in the database.</summary>
	[DataContract]
	public partial class Semester : ServiceObjects.Semester
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Semester()
		{
			this.Links = new List<Link>();
		}
		
		public static Semester FromDataAccessObject(DataAccess.Semester obj)
		{
			if (obj == null)
				return null;

            Semester newObj = new Semester();
			ServiceObjects.Semester.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Courses", LinkType.Courses, RESTUrlUtil.Service.RESTSvc.GetCoursesBySemesterID(newObj.ID, 1)));
			
			return newObj;
		}
	}

	/// <summary>Maps to the Student table in the database.</summary>
	[DataContract]
	public partial class Student : ServiceObjects.Student
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Student()
		{
			this.Links = new List<Link>();
		}
		
		public static Student FromDataAccessObject(DataAccess.Student obj)
		{
			if (obj == null)
				return null;

            Student newObj = new Student();
			ServiceObjects.Student.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Major", LinkType.Major, RESTUrlUtil.Service.RESTSvc.GetMajorByID(newObj.MajorID)));
			newObj.Links.Add(new Link("Enrollments", LinkType.Enrollments, RESTUrlUtil.Service.RESTSvc.GetEnrollmentsByStudentID(newObj.ID, 1)));
			
			return newObj;
		}
	}

	/// <summary>Maps to the Teacher table in the database.</summary>
	[DataContract]
	public partial class Teacher : ServiceObjects.Teacher
	{
		[DataMember]
		public List<Link> Links { get; set;}
	
		public Teacher()
		{
			this.Links = new List<Link>();
		}
		
		public static Teacher FromDataAccessObject(DataAccess.Teacher obj)
		{
			if (obj == null)
				return null;

            Teacher newObj = new Teacher();
			ServiceObjects.Teacher.Copy(obj, newObj);
			
			newObj.Links.Add(new Link("Courses", LinkType.Courses, RESTUrlUtil.Service.RESTSvc.GetCoursesByTeacherID(newObj.ID, 1)));
			
			return newObj;
		}
	}

}