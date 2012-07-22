using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Linq.Expressions;
using DO = QuantumConcepts.CodeGenerator.Sample.DataObjects;
using DA = QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Logic
{
	/// <summary>Contains logical functionality related to the Course class.</summary>
	public static partial class CourseLogic
	{
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static DA.Course GetByID(int id)
		{
			return DA.Course.GetByID(id);
		}
		
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static DA.Course GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Course.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetAll()
		{
			return DA.Course.GetAll();
		}
		
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetAll(DA.SampleDataContext context)
		{
			return DA.Course.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetBySemesterID(int iD)
		{
			return DA.Course.GetBySemesterID(iD);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetBySemesterID(DA.SampleDataContext context, int iD)
		{
			return DA.Course.GetBySemesterID(context, iD);
		}

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetByTeacherID(int iD)
		{
			return DA.Course.GetByTeacherID(iD);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<DA.Course> GetByTeacherID(DA.SampleDataContext context, int iD)
		{
			return DA.Course.GetByTeacherID(context, iD);
		}
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static DA.Course GetBySemesterIDAndNumber(int semesterID, string number)
		{
			return DA.Course.GetBySemesterIDAndNumber(semesterID, number);
		}
		
		public static DA.Course GetBySemesterIDAndNumber(DA.SampleDataContext context, int semesterID, string number)
		{
			return DA.Course.GetBySemesterIDAndNumber(context, semesterID, number);
		}
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static DA.Course GetBySemesterIDAndName(int semesterID, string name)
		{
			return DA.Course.GetBySemesterIDAndName(semesterID, name);
		}
		
		public static DA.Course GetBySemesterIDAndName(DA.SampleDataContext context, int semesterID, string name)
		{
			return DA.Course.GetBySemesterIDAndName(context, semesterID, name);
		}
		public static List<DA.Course> FindCourse(string keyword)
		{
			return FindCourse(new DA.SampleDataContext(), keyword);
		}
		
		public static List<DA.Course> FindCourse(DA.SampleDataContext context, string keyword)
		{
			return FindCourseAPI(context, keyword);
		}
		
	    
		public static DA.Course LoadCourseFromDataContext(this DA.Course obj, DA.SampleDataContext dataContext)
		{
			return DA.Course.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Course CreateCourse(int SemesterID_Parameter, int TeacherID_Parameter, string Number_Parameter, string Name_Parameter, DO.CourseStatus Status_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Course obj = CreateCourse(context, SemesterID_Parameter, TeacherID_Parameter, Number_Parameter, Name_Parameter, Status_Parameter);
			
			context.SubmitChanges();
			DA.Course.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Course CreateCourse(DA.SampleDataContext context, int SemesterID_Parameter, int TeacherID_Parameter, string Number_Parameter, string Name_Parameter, DO.CourseStatus Status_Parameter)
		{
			DA.Course obj = new DA.Course();
			
			obj.SemesterID = SemesterID_Parameter;
			obj.TeacherID = TeacherID_Parameter;
			obj.Number = Number_Parameter;
			obj.Name = Name_Parameter;
			obj.Status = Status_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Courses.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static DA.Course CreateCourse(DA.Semester Semester_Parameter, DA.Teacher Teacher_Parameter, string Number_Parameter, string Name_Parameter, DO.CourseStatus Status_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Course obj = CreateCourse(context, Semester_Parameter, Teacher_Parameter, Number_Parameter, Name_Parameter, Status_Parameter);
			
			context.SubmitChanges();
			DA.Course.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Course CreateCourse(DA.SampleDataContext context, DA.Semester Semester_Parameter, DA.Teacher Teacher_Parameter, string Number_Parameter, string Name_Parameter, DO.CourseStatus Status_Parameter)
		{
			DA.Course obj = new DA.Course();
			
			obj.Semester = Semester_Parameter;
			obj.Teacher = Teacher_Parameter;
			obj.Number = Number_Parameter;
			obj.Name = Name_Parameter;
			obj.Status = Status_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Courses.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteCourse(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteCourse(context, id);
			
			context.SubmitChanges();
			DA.Course.OnCacheNeedsRefresh();
		}
		
		public static void DeleteCourse(DA.SampleDataContext context, int id)
		{
			DA.Course obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Courses.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Course obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Course obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Course obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Course obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Course obj);
	}

	/// <summary>Contains logical functionality related to the Enrollment class.</summary>
	public static partial class EnrollmentLogic
	{
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static DA.Enrollment GetByID(int id)
		{
			return DA.Enrollment.GetByID(id);
		}
		
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static DA.Enrollment GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Enrollment.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetAll()
		{
			return DA.Enrollment.GetAll();
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetAll(DA.SampleDataContext context)
		{
			return DA.Enrollment.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetByStudentID(int iD)
		{
			return DA.Enrollment.GetByStudentID(iD);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetByStudentID(DA.SampleDataContext context, int iD)
		{
			return DA.Enrollment.GetByStudentID(context, iD);
		}

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetByCourseID(int iD)
		{
			return DA.Enrollment.GetByCourseID(iD);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<DA.Enrollment> GetByCourseID(DA.SampleDataContext context, int iD)
		{
			return DA.Enrollment.GetByCourseID(context, iD);
		}
		/// <summary>Gets the Enrollment matching the unique index using the passed-in values.</summary>
		public static DA.Enrollment GetByStudentIDAndCourseID(int studentID, int courseID)
		{
			return DA.Enrollment.GetByStudentIDAndCourseID(studentID, courseID);
		}
		
		public static DA.Enrollment GetByStudentIDAndCourseID(DA.SampleDataContext context, int studentID, int courseID)
		{
			return DA.Enrollment.GetByStudentIDAndCourseID(context, studentID, courseID);
		}
	    
		public static DA.Enrollment LoadEnrollmentFromDataContext(this DA.Enrollment obj, DA.SampleDataContext dataContext)
		{
			return DA.Enrollment.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Enrollment CreateEnrollment(int StudentID_Parameter, int CourseID_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Enrollment obj = CreateEnrollment(context, StudentID_Parameter, CourseID_Parameter);
			
			context.SubmitChanges();
			DA.Enrollment.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Enrollment CreateEnrollment(DA.SampleDataContext context, int StudentID_Parameter, int CourseID_Parameter)
		{
			DA.Enrollment obj = new DA.Enrollment();
			
			obj.StudentID = StudentID_Parameter;
			obj.CourseID = CourseID_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Enrollments.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static DA.Enrollment CreateEnrollment(DA.Student Student_Parameter, DA.Course Course_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Enrollment obj = CreateEnrollment(context, Student_Parameter, Course_Parameter);
			
			context.SubmitChanges();
			DA.Enrollment.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Enrollment CreateEnrollment(DA.SampleDataContext context, DA.Student Student_Parameter, DA.Course Course_Parameter)
		{
			DA.Enrollment obj = new DA.Enrollment();
			
			obj.Student = Student_Parameter;
			obj.Course = Course_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Enrollments.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteEnrollment(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteEnrollment(context, id);
			
			context.SubmitChanges();
			DA.Enrollment.OnCacheNeedsRefresh();
		}
		
		public static void DeleteEnrollment(DA.SampleDataContext context, int id)
		{
			DA.Enrollment obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Enrollments.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Enrollment obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Enrollment obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Enrollment obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Enrollment obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Enrollment obj);
	}

	/// <summary>Contains logical functionality related to the Major class.</summary>
	public static partial class MajorLogic
	{
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static DA.Major GetByID(int id)
		{
			return DA.Major.GetByID(id);
		}
		
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static DA.Major GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Major.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<DA.Major> GetAll()
		{
			return DA.Major.GetAll();
		}
		
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<DA.Major> GetAll(DA.SampleDataContext context)
		{
			return DA.Major.GetAll(context);
		}
		
		/// <summary>Gets the Major matching the unique index using the passed-in values.</summary>
		public static DA.Major GetByName(string name)
		{
			return DA.Major.GetByName(name);
		}
		
		public static DA.Major GetByName(DA.SampleDataContext context, string name)
		{
			return DA.Major.GetByName(context, name);
		}
	    
		public static DA.Major LoadMajorFromDataContext(this DA.Major obj, DA.SampleDataContext dataContext)
		{
			return DA.Major.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Major CreateMajor(string Name_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Major obj = CreateMajor(context, Name_Parameter);
			
			context.SubmitChanges();
			DA.Major.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Major CreateMajor(DA.SampleDataContext context, string Name_Parameter)
		{
			DA.Major obj = new DA.Major();
			
			obj.Name = Name_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Majors.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteMajor(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteMajor(context, id);
			
			context.SubmitChanges();
			DA.Major.OnCacheNeedsRefresh();
		}
		
		public static void DeleteMajor(DA.SampleDataContext context, int id)
		{
			DA.Major obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Majors.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Major obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Major obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Major obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Major obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Major obj);
	}

	/// <summary>Contains logical functionality related to the Semester class.</summary>
	public static partial class SemesterLogic
	{
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static DA.Semester GetByID(int id)
		{
			return DA.Semester.GetByID(id);
		}
		
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static DA.Semester GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Semester.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<DA.Semester> GetAll()
		{
			return DA.Semester.GetAll();
		}
		
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<DA.Semester> GetAll(DA.SampleDataContext context)
		{
			return DA.Semester.GetAll(context);
		}
		
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static DA.Semester GetByBeginAndEnd(DateTime begin, DateTime end)
		{
			return DA.Semester.GetByBeginAndEnd(begin, end);
		}
		
		public static DA.Semester GetByBeginAndEnd(DA.SampleDataContext context, DateTime begin, DateTime end)
		{
			return DA.Semester.GetByBeginAndEnd(context, begin, end);
		}
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static DA.Semester GetByName(string name)
		{
			return DA.Semester.GetByName(name);
		}
		
		public static DA.Semester GetByName(DA.SampleDataContext context, string name)
		{
			return DA.Semester.GetByName(context, name);
		}
	    
		public static DA.Semester LoadSemesterFromDataContext(this DA.Semester obj, DA.SampleDataContext dataContext)
		{
			return DA.Semester.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Semester CreateSemester(DateTime Begin_Parameter, DateTime End_Parameter, string Name_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Semester obj = CreateSemester(context, Begin_Parameter, End_Parameter, Name_Parameter);
			
			context.SubmitChanges();
			DA.Semester.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Semester CreateSemester(DA.SampleDataContext context, DateTime Begin_Parameter, DateTime End_Parameter, string Name_Parameter)
		{
			DA.Semester obj = new DA.Semester();
			
			obj.Begin = Begin_Parameter;
			obj.End = End_Parameter;
			obj.Name = Name_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Semesters.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteSemester(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteSemester(context, id);
			
			context.SubmitChanges();
			DA.Semester.OnCacheNeedsRefresh();
		}
		
		public static void DeleteSemester(DA.SampleDataContext context, int id)
		{
			DA.Semester obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Semesters.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Semester obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Semester obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Semester obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Semester obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Semester obj);
	}

	/// <summary>Contains logical functionality related to the Student class.</summary>
	public static partial class StudentLogic
	{
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static DA.Student GetByID(int id)
		{
			return DA.Student.GetByID(id);
		}
		
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static DA.Student GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Student.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<DA.Student> GetAll()
		{
			return DA.Student.GetAll();
		}
		
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<DA.Student> GetAll(DA.SampleDataContext context)
		{
			return DA.Student.GetAll(context);
		}
		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<DA.Student> GetByMajorID(int iD)
		{
			return DA.Student.GetByMajorID(iD);
		}
		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<DA.Student> GetByMajorID(DA.SampleDataContext context, int iD)
		{
			return DA.Student.GetByMajorID(context, iD);
		}
		/// <summary>Gets the Student matching the unique index using the passed-in values.</summary>
		public static DA.Student GetBySSN(string sSN)
		{
			return DA.Student.GetBySSN(sSN);
		}
		
		public static DA.Student GetBySSN(DA.SampleDataContext context, string sSN)
		{
			return DA.Student.GetBySSN(context, sSN);
		}
	    
		public static DA.Student LoadStudentFromDataContext(this DA.Student obj, DA.SampleDataContext dataContext)
		{
			return DA.Student.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Student CreateStudent(int MajorID_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Student obj = CreateStudent(context, MajorID_Parameter, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.SubmitChanges();
			DA.Student.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Student CreateStudent(DA.SampleDataContext context, int MajorID_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.Student obj = new DA.Student();
			
			obj.MajorID = MajorID_Parameter;
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Students.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static DA.Student CreateStudent(DA.Major Major_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Student obj = CreateStudent(context, Major_Parameter, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.SubmitChanges();
			DA.Student.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Student CreateStudent(DA.SampleDataContext context, DA.Major Major_Parameter, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.Student obj = new DA.Student();
			
			obj.Major = Major_Parameter;
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Students.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
		
		public static void DeleteStudent(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteStudent(context, id);
			
			context.SubmitChanges();
			DA.Student.OnCacheNeedsRefresh();
		}
		
		public static void DeleteStudent(DA.SampleDataContext context, int id)
		{
			DA.Student obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Students.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Student obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Student obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Student obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Student obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Student obj);
	}

	/// <summary>Contains logical functionality related to the Teacher class.</summary>
	public static partial class TeacherLogic
	{
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static DA.Teacher GetByID(int id)
		{
			return DA.Teacher.GetByID(id);
		}
		
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static DA.Teacher GetByID(DA.SampleDataContext context, int id)
		{
			return DA.Teacher.GetByID(context, id);
		}
		
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<DA.Teacher> GetAll()
		{
			return DA.Teacher.GetAll();
		}
		
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<DA.Teacher> GetAll(DA.SampleDataContext context)
		{
			return DA.Teacher.GetAll(context);
		}
		
		/// <summary>Gets the Teacher matching the unique index using the passed-in values.</summary>
		public static DA.Teacher GetBySSN(string sSN)
		{
			return DA.Teacher.GetBySSN(sSN);
		}
		
		public static DA.Teacher GetBySSN(DA.SampleDataContext context, string sSN)
		{
			return DA.Teacher.GetBySSN(context, sSN);
		}
	    
		public static DA.Teacher LoadTeacherFromDataContext(this DA.Teacher obj, DA.SampleDataContext dataContext)
		{
			return DA.Teacher.GetByID(dataContext, obj.ID);
		}
    
		public static DA.Teacher CreateTeacher(string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			DA.Teacher obj = CreateTeacher(context, SSN_Parameter, FirstName_Parameter, LastName_Parameter, Active_Parameter);
			
			context.SubmitChanges();
			DA.Teacher.OnCacheNeedsRefresh();
			
			return obj;
		}
		
		public static DA.Teacher CreateTeacher(DA.SampleDataContext context, string SSN_Parameter, string FirstName_Parameter, string LastName_Parameter, bool Active_Parameter)
		{
			DA.Teacher obj = new DA.Teacher();
			
			obj.SSN = SSN_Parameter;
			obj.FirstName = FirstName_Parameter;
			obj.LastName = LastName_Parameter;
			obj.Active = Active_Parameter;
			
			Validate(context, obj);
			
			PerformPreCreateLogic(context, obj);
			
			context.Teachers.InsertOnSubmit(obj);
			
			PerformPostCreateLogic(context, obj);
			
			return obj;
		}
    		
		public static void DeleteTeacher(int id)
		{
			DA.SampleDataContext context = new DA.SampleDataContext();
			
			DeleteTeacher(context, id);
			
			context.SubmitChanges();
			DA.Teacher.OnCacheNeedsRefresh();
		}
		
		public static void DeleteTeacher(DA.SampleDataContext context, int id)
		{
			DA.Teacher obj = GetByID(context, id);
			
			PerformPreDeleteLogic(context, obj);
			
			context.Teachers.DeleteOnSubmit(obj);
			
			PerformPostDeleteLogic(context, obj);
		}

		/// <summary>When implemented, validates that the object conforms to standard business rules using the supplied data context.</summary>
		static partial void Validate(DA.SampleDataContext context, DA.Teacher obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is created using the supplied data context.</summary>
		static partial void PerformPreCreateLogic(DA.SampleDataContext context, DA.Teacher obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is created using the supplied data context.</summary>
		static partial void PerformPostCreateLogic(DA.SampleDataContext context, DA.Teacher obj);
    
		/// <summary>When implemented, allows logic to be performed before the object is deleted using the supplied data context.</summary>
		static partial void PerformPreDeleteLogic(DA.SampleDataContext context, DA.Teacher obj);
		
		/// <summary>When implemented, allows logic to be performed after the object is deleted using the supplied data context.</summary>
		static partial void PerformPostDeleteLogic(DA.SampleDataContext context, DA.Teacher obj);
	}
}