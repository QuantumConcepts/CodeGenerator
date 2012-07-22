using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Logic
{
	/// <summary>Contains logical functionality related to the Course class.</summary>
	public static partial class CourseLogic
	{
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static Course GetByID(int id)
		{
			return Course.GetByID(id);
		}
		
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static Course GetByID(SampleObjectContext context, int id)
		{
			return Course.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll()
		{
			return Course.GetAll();
		}
		
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll(SampleObjectContext context)
		{
			return Course.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(int iD)
		{
			return Course.GetBySemesterID(iD);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(SampleObjectContext context, int iD)
		{
			return Course.GetBySemesterID(context, iD);
		}

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(int iD)
		{
			return Course.GetByTeacherID(iD);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(SampleObjectContext context, int iD)
		{
			return Course.GetByTeacherID(context, iD);
		}
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static Course GetBySemesterIDAndNumber(int semesterID, string number)
		{
			return Course.GetBySemesterIDAndNumber(semesterID, number);
		}
		
		public static Course GetBySemesterIDAndNumber(SampleObjectContext context, int semesterID, string number)
		{
			return Course.GetBySemesterIDAndNumber(context, semesterID, number);
		}
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static Course GetBySemesterIDAndName(int semesterID, string name)
		{
			return Course.GetBySemesterIDAndName(semesterID, name);
		}
		
		public static Course GetBySemesterIDAndName(SampleObjectContext context, int semesterID, string name)
		{
			return Course.GetBySemesterIDAndName(context, semesterID, name);
		}
		public static List<Course> FindCourse(string keyword)
		{
			return FindCourse(new SampleObjectContext(), keyword);
		}
		
		public static List<Course> FindCourse(SampleObjectContext context, string keyword)
		{
			return FindCourseAPI(context, keyword);
		}
		
	    
		public static Course LoadCourseFromDataContext(this Course obj, SampleObjectContext dataContext)
		{
			return Course.GetByID(dataContext, obj.ID);
		}
    
		public static Course CreateCourse(int SemesterID_Parameter, int TeacherID_Parameter, string Number_Parameter, string Name_Parameter, CourseStatus Status_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Course obj = CreateCourse(context, SemesterID_Parameter, TeacherID_Parameter, Number_Parameter, Name_Parameter, Status_Parameter);
			
			context.AcceptAllChanges();
			Course.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Course CreateCourse(SampleObjectContext context, int SemesterID_Parameter, int TeacherID_Parameter, string Number_Parameter, string Name_Parameter, CourseStatus Status_Parameter)
		{
			Course obj = new Course();
			
			obj.SemesterID = SemesterID_Parameter;
			obj.TeacherID = TeacherID_Parameter;
			obj.Number = Number_Parameter;
			obj.Name = Name_Parameter;
			obj.Status = Status_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Courses.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static Course CreateCourse(Semester Semester_Parameter, Teacher Teacher_Parameter, string Number_Parameter, string Name_Parameter, CourseStatus Status_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Course obj = CreateCourse(context, Semester_Parameter, Teacher_Parameter, Number_Parameter, Name_Parameter, Status_Parameter);
			
			context.AcceptAllChanges();
			Course.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Course CreateCourse(SampleObjectContext context, Semester Semester_Parameter, Teacher Teacher_Parameter, string Number_Parameter, string Name_Parameter, CourseStatus Status_Parameter)
		{
			Course obj = new Course();
			
			obj.Semester = Semester_Parameter;
			obj.Teacher = Teacher_Parameter;
			obj.Number = Number_Parameter;
			obj.Name = Name_Parameter;
			obj.Status = Status_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Courses.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteCourse(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteCourse(context, id);
			
			context.AcceptAllChanges();
			Course.OnCacheNeedsRefresh();
		}
		
		public static void DeleteCourse(SampleObjectContext context, int id)
		{
			Course obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Courses.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Course obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Course obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Course obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Course obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Course obj);
	}

	/// <summary>Contains logical functionality related to the Enrollment class.</summary>
	public static partial class EnrollmentLogic
	{
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static Enrollment GetByID(int id)
		{
			return Enrollment.GetByID(id);
		}
		
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static Enrollment GetByID(SampleObjectContext context, int id)
		{
			return Enrollment.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll()
		{
			return Enrollment.GetAll();
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll(SampleObjectContext context)
		{
			return Enrollment.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(int iD)
		{
			return Enrollment.GetByStudentID(iD);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(SampleObjectContext context, int iD)
		{
			return Enrollment.GetByStudentID(context, iD);
		}

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(int iD)
		{
			return Enrollment.GetByCourseID(iD);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(SampleObjectContext context, int iD)
		{
			return Enrollment.GetByCourseID(context, iD);
		}
		/// <summary>Gets the Enrollment matching the unique index using the passed-in values.</summary>
		public static Enrollment GetByStudentIDAndCourseID(int studentID, int courseID)
		{
			return Enrollment.GetByStudentIDAndCourseID(studentID, courseID);
		}
		
		public static Enrollment GetByStudentIDAndCourseID(SampleObjectContext context, int studentID, int courseID)
		{
			return Enrollment.GetByStudentIDAndCourseID(context, studentID, courseID);
		}
	    
		public static Enrollment LoadEnrollmentFromDataContext(this Enrollment obj, SampleObjectContext dataContext)
		{
			return Enrollment.GetByID(dataContext, obj.ID);
		}
    
		public static Enrollment CreateEnrollment(int StudentID_Parameter, int CourseID_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Enrollment obj = CreateEnrollment(context, StudentID_Parameter, CourseID_Parameter);
			
			context.AcceptAllChanges();
			Enrollment.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Enrollment CreateEnrollment(SampleObjectContext context, int StudentID_Parameter, int CourseID_Parameter)
		{
			Enrollment obj = new Enrollment();
			
			obj.StudentID = StudentID_Parameter;
			obj.CourseID = CourseID_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Enrollments.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static Enrollment CreateEnrollment(Student Student_Parameter, Course Course_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Enrollment obj = CreateEnrollment(context, Student_Parameter, Course_Parameter);
			
			context.AcceptAllChanges();
			Enrollment.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Enrollment CreateEnrollment(SampleObjectContext context, Student Student_Parameter, Course Course_Parameter)
		{
			Enrollment obj = new Enrollment();
			
			obj.Student = Student_Parameter;
			obj.Course = Course_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Enrollments.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteEnrollment(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteEnrollment(context, id);
			
			context.AcceptAllChanges();
			Enrollment.OnCacheNeedsRefresh();
		}
		
		public static void DeleteEnrollment(SampleObjectContext context, int id)
		{
			Enrollment obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Enrollments.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Enrollment obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Enrollment obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Enrollment obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Enrollment obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Enrollment obj);
	}

	/// <summary>Contains logical functionality related to the Major class.</summary>
	public static partial class MajorLogic
	{
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static Major GetByID(int id)
		{
			return Major.GetByID(id);
		}
		
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static Major GetByID(SampleObjectContext context, int id)
		{
			return Major.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll()
		{
			return Major.GetAll();
		}
		
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll(SampleObjectContext context)
		{
			return Major.GetAll(context);
		}
		
		/// <summary>Gets the Major matching the unique index using the passed-in values.</summary>
		public static Major GetByName(string name)
		{
			return Major.GetByName(name);
		}
		
		public static Major GetByName(SampleObjectContext context, string name)
		{
			return Major.GetByName(context, name);
		}
	    
		public static Major LoadMajorFromDataContext(this Major obj, SampleObjectContext dataContext)
		{
			return Major.GetByID(dataContext, obj.ID);
		}
    
		public static Major CreateMajor(string Name_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Major obj = CreateMajor(context, Name_Parameter);
			
			context.AcceptAllChanges();
			Major.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Major CreateMajor(SampleObjectContext context, string Name_Parameter)
		{
			Major obj = new Major();
			
			obj.Name = Name_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Majors.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteMajor(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteMajor(context, id);
			
			context.AcceptAllChanges();
			Major.OnCacheNeedsRefresh();
		}
		
		public static void DeleteMajor(SampleObjectContext context, int id)
		{
			Major obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Majors.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Major obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Major obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Major obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Major obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Major obj);
	}

	/// <summary>Contains logical functionality related to the Semester class.</summary>
	public static partial class SemesterLogic
	{
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static Semester GetByID(int id)
		{
			return Semester.GetByID(id);
		}
		
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static Semester GetByID(SampleObjectContext context, int id)
		{
			return Semester.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll()
		{
			return Semester.GetAll();
		}
		
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll(SampleObjectContext context)
		{
			return Semester.GetAll(context);
		}
		
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static Semester GetByBeginAndEnd(DateTime begin, DateTime end)
		{
			return Semester.GetByBeginAndEnd(begin, end);
		}
		
		public static Semester GetByBeginAndEnd(SampleObjectContext context, DateTime begin, DateTime end)
		{
			return Semester.GetByBeginAndEnd(context, begin, end);
		}
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static Semester GetByName(string name)
		{
			return Semester.GetByName(name);
		}
		
		public static Semester GetByName(SampleObjectContext context, string name)
		{
			return Semester.GetByName(context, name);
		}
	    
		public static Semester LoadSemesterFromDataContext(this Semester obj, SampleObjectContext dataContext)
		{
			return Semester.GetByID(dataContext, obj.ID);
		}
    
		public static Semester CreateSemester(DateTime Begin_Parameter, DateTime End_Parameter, string Name_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Semester obj = CreateSemester(context, Begin_Parameter, End_Parameter, Name_Parameter);
			
			context.AcceptAllChanges();
			Semester.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Semester CreateSemester(SampleObjectContext context, DateTime Begin_Parameter, DateTime End_Parameter, string Name_Parameter)
		{
			Semester obj = new Semester();
			
			obj.Begin = Begin_Parameter;
			obj.End = End_Parameter;
			obj.Name = Name_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Semesters.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteSemester(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteSemester(context, id);
			
			context.AcceptAllChanges();
			Semester.OnCacheNeedsRefresh();
		}
		
		public static void DeleteSemester(SampleObjectContext context, int id)
		{
			Semester obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Semesters.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Semester obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Semester obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Semester obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Semester obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Semester obj);
	}

	/// <summary>Contains logical functionality related to the Student class.</summary>
	public static partial class StudentLogic
	{
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static Student GetByID(int id)
		{
			return Student.GetByID(id);
		}
		
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static Student GetByID(SampleObjectContext context, int id)
		{
			return Student.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll()
		{
			return Student.GetAll();
		}
		
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll(SampleObjectContext context)
		{
			return Student.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(int iD)
		{
			return Student.GetByMajorID(iD);
		}
		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(SampleObjectContext context, int iD)
		{
			return Student.GetByMajorID(context, iD);
		}
		/// <summary>Gets the Student matching the unique index using the passed-in values.</summary>
		public static Student GetBySSN(string sSN)
		{
			return Student.GetBySSN(sSN);
		}
		
		public static Student GetBySSN(SampleObjectContext context, string sSN)
		{
			return Student.GetBySSN(context, sSN);
		}
	    
		public static Student LoadStudentFromDataContext(this Student obj, SampleObjectContext dataContext)
		{
			return Student.GetByID(dataContext, obj.ID);
		}
    
		public static Student CreateStudent(int MajorID_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Student obj = CreateStudent(context, MajorID_Parameter, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.AcceptAllChanges();
			Student.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Student CreateStudent(SampleObjectContext context, int MajorID_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			Student obj = new Student();
			
			obj.MajorID = MajorID_Parameter;
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Students.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static Student CreateStudent(Major Major_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Student obj = CreateStudent(context, Major_Parameter, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.AcceptAllChanges();
			Student.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Student CreateStudent(SampleObjectContext context, Major Major_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			Student obj = new Student();
			
			obj.Major = Major_Parameter;
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Students.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteStudent(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteStudent(context, id);
			
			context.AcceptAllChanges();
			Student.OnCacheNeedsRefresh();
		}
		
		public static void DeleteStudent(SampleObjectContext context, int id)
		{
			Student obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Students.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Student obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Student obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Student obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Student obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Student obj);
	}

	/// <summary>Contains logical functionality related to the Teacher class.</summary>
	public static partial class TeacherLogic
	{
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static Teacher GetByID(int id)
		{
			return Teacher.GetByID(id);
		}
		
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static Teacher GetByID(SampleObjectContext context, int id)
		{
			return Teacher.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll()
		{
			return Teacher.GetAll();
		}
		
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll(SampleObjectContext context)
		{
			return Teacher.GetAll(context);
		}
		
		/// <summary>Gets the Teacher matching the unique index using the passed-in values.</summary>
		public static Teacher GetBySSN(string sSN)
		{
			return Teacher.GetBySSN(sSN);
		}
		
		public static Teacher GetBySSN(SampleObjectContext context, string sSN)
		{
			return Teacher.GetBySSN(context, sSN);
		}
	    
		public static Teacher LoadTeacherFromDataContext(this Teacher obj, SampleObjectContext dataContext)
		{
			return Teacher.GetByID(dataContext, obj.ID);
		}
    
		public static Teacher CreateTeacher(string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			SampleObjectContext context = new SampleObjectContext();
			Teacher obj = CreateTeacher(context, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.AcceptAllChanges();
			Teacher.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static Teacher CreateTeacher(SampleObjectContext context, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			Teacher obj = new Teacher();
			
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Teachers.AddObject(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteTeacher(int id)
		{
			SampleObjectContext context = new SampleObjectContext();
			
			DeleteTeacher(context, id);
			
			context.AcceptAllChanges();
			Teacher.OnCacheNeedsRefresh();
		}
		
		public static void DeleteTeacher(SampleObjectContext context, int id)
		{
			Teacher obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Teachers.DeleteObject(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(SampleObjectContext context, Teacher obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(SampleObjectContext context, Teacher obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(SampleObjectContext context, Teacher obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(SampleObjectContext context, Teacher obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(SampleObjectContext context, Teacher obj);
	}
}