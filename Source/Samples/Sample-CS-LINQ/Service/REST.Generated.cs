using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using DO = QuantumConcepts.CodeGenerator.Sample.DataObjects;
using SO = QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.REST;
using DA = QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;
using QuantumConcepts.CodeGenerator.Sample.Service.Utils;
using WcfRestContrib.ServiceModel.Description;

namespace QuantumConcepts.CodeGenerator.Sample.Service
{
	/// <summary>Exposes functionality through one or more service end points.</summary>
	[AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
	[WebDispatchFormatterConfiguration("application/xml")]
   	[WebDispatchFormatterMimeType(typeof(WcfRestContrib.ServiceModel.Dispatcher.Formatters.PoxDataContract), "application/xml", "text/xml")]
	public partial class REST : IREST
	{

		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public IEnumerable<SO.Course> GetCourses(string page)
		{
			return GetPage(CourseLogic.GetAll(), page).Select(o => SO.Course.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Courses exist.<summary>
		public int GetCoursesCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Courses.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Courses method.<summary>
		public int GetCoursesPageCount()
		{
			return ServiceUtil.GetPageCount(GetCoursesCount());
		}
		
		/// <summary>Gets the Course with the specified primary key.</summary>
		/// <param name="id">The primary key of the Course to return.</param>
		/// <returns>The matching Course, if one exists, or null.</returns>
		public SO.Course GetCourseByID(string id)
		{
			return SO.Course.FromDataAccessObject(CourseLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public IEnumerable<SO.Course> GetCoursesBySemesterID(string semesterID, string page)
		{
			IEnumerable<DA.Course> returnValue = CourseLogic.GetBySemesterID(ParseInt("id", semesterID));
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, ParseInt("page", page)).Select(o => SO.Course.FromDataAccessObject(o));
			
			return null;
		}
		
		/// <summary>Gets how many Courses by SemesterID exist.<summary>
		public int GetCoursesBySemesterIDCount(string semesterID)
		{
			return CourseLogic.GetBySemesterID(ParseInt("semesterID", semesterID)).Count();
		}
		
		/// <summary>Gets how many pages of data exist for the Courses by SemesterID method.<summary>
		public int GetCoursesBySemesterIDPageCount(string semesterID)
		{
			return ServiceUtil.GetPageCount(GetCoursesBySemesterIDCount(semesterID));
		}

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public IEnumerable<SO.Course> GetCoursesByTeacherID(string teacherID, string page)
		{
			IEnumerable<DA.Course> returnValue = CourseLogic.GetByTeacherID(ParseInt("id", teacherID));
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, ParseInt("page", page)).Select(o => SO.Course.FromDataAccessObject(o));
			
			return null;
		}
		
		/// <summary>Gets how many Courses by TeacherID exist.<summary>
		public int GetCoursesByTeacherIDCount(string teacherID)
		{
			return CourseLogic.GetByTeacherID(ParseInt("teacherID", teacherID)).Count();
		}
		
		/// <summary>Gets how many pages of data exist for the Courses by TeacherID method.<summary>
		public int GetCoursesByTeacherIDPageCount(string teacherID)
		{
			return ServiceUtil.GetPageCount(GetCoursesByTeacherIDCount(teacherID));
		}

		/// <summary>Maps to the UX_Course_1 foreign key in the database.</summary>
		public SO.Course GetCourseBySemesterIDAndNumber(string semesterID, string number)
		{
			return SO.Course.FromDataAccessObject(CourseLogic.GetBySemesterIDAndNumber(ParseInt("SemesterID", semesterID), number));
		}

		/// <summary>Maps to the UX_Course_2 foreign key in the database.</summary>
		public SO.Course GetCourseBySemesterIDAndName(string semesterID, string name)
		{
			return SO.Course.FromDataAccessObject(CourseLogic.GetBySemesterIDAndName(ParseInt("SemesterID", semesterID), name));
		}

		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public IEnumerable<SO.Enrollment> GetEnrollments(string page)
		{
			return GetPage(EnrollmentLogic.GetAll(), page).Select(o => SO.Enrollment.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Enrollments exist.<summary>
		public int GetEnrollmentsCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Enrollments.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Enrollments method.<summary>
		public int GetEnrollmentsPageCount()
		{
			return ServiceUtil.GetPageCount(GetEnrollmentsCount());
		}
		
		/// <summary>Gets the Enrollment with the specified primary key.</summary>
		/// <param name="id">The primary key of the Enrollment to return.</param>
		/// <returns>The matching Enrollment, if one exists, or null.</returns>
		public SO.Enrollment GetEnrollmentByID(string id)
		{
			return SO.Enrollment.FromDataAccessObject(EnrollmentLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public IEnumerable<SO.Enrollment> GetEnrollmentsByStudentID(string studentID, string page)
		{
			IEnumerable<DA.Enrollment> returnValue = EnrollmentLogic.GetByStudentID(ParseInt("id", studentID));
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, ParseInt("page", page)).Select(o => SO.Enrollment.FromDataAccessObject(o));
			
			return null;
		}
		
		/// <summary>Gets how many Enrollments by StudentID exist.<summary>
		public int GetEnrollmentsByStudentIDCount(string studentID)
		{
			return EnrollmentLogic.GetByStudentID(ParseInt("studentID", studentID)).Count();
		}
		
		/// <summary>Gets how many pages of data exist for the Enrollments by StudentID method.<summary>
		public int GetEnrollmentsByStudentIDPageCount(string studentID)
		{
			return ServiceUtil.GetPageCount(GetEnrollmentsByStudentIDCount(studentID));
		}

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public IEnumerable<SO.Enrollment> GetEnrollmentsByCourseID(string courseID, string page)
		{
			IEnumerable<DA.Enrollment> returnValue = EnrollmentLogic.GetByCourseID(ParseInt("id", courseID));
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, ParseInt("page", page)).Select(o => SO.Enrollment.FromDataAccessObject(o));
			
			return null;
		}
		
		/// <summary>Gets how many Enrollments by CourseID exist.<summary>
		public int GetEnrollmentsByCourseIDCount(string courseID)
		{
			return EnrollmentLogic.GetByCourseID(ParseInt("courseID", courseID)).Count();
		}
		
		/// <summary>Gets how many pages of data exist for the Enrollments by CourseID method.<summary>
		public int GetEnrollmentsByCourseIDPageCount(string courseID)
		{
			return ServiceUtil.GetPageCount(GetEnrollmentsByCourseIDCount(courseID));
		}

		/// <summary>Maps to the UX_Enrollment_1 foreign key in the database.</summary>
		public SO.Enrollment GetEnrollmentByStudentIDAndCourseID(string studentID, string courseID)
		{
			return SO.Enrollment.FromDataAccessObject(EnrollmentLogic.GetByStudentIDAndCourseID(ParseInt("StudentID", studentID), ParseInt("CourseID", courseID)));
		}

		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public IEnumerable<SO.Major> GetMajors(string page)
		{
			return GetPage(MajorLogic.GetAll(), page).Select(o => SO.Major.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Majors exist.<summary>
		public int GetMajorsCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Majors.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Majors method.<summary>
		public int GetMajorsPageCount()
		{
			return ServiceUtil.GetPageCount(GetMajorsCount());
		}
		
		/// <summary>Gets the Major with the specified primary key.</summary>
		/// <param name="id">The primary key of the Major to return.</param>
		/// <returns>The matching Major, if one exists, or null.</returns>
		public SO.Major GetMajorByID(string id)
		{
			return SO.Major.FromDataAccessObject(MajorLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Maps to the UX_Major foreign key in the database.</summary>
		public SO.Major GetMajorByName(string name)
		{
			return SO.Major.FromDataAccessObject(MajorLogic.GetByName(name));
		}

		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public IEnumerable<SO.Semester> GetSemesters(string page)
		{
			return GetPage(SemesterLogic.GetAll(), page).Select(o => SO.Semester.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Semesters exist.<summary>
		public int GetSemestersCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Semesters.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Semesters method.<summary>
		public int GetSemestersPageCount()
		{
			return ServiceUtil.GetPageCount(GetSemestersCount());
		}
		
		/// <summary>Gets the Semester with the specified primary key.</summary>
		/// <param name="id">The primary key of the Semester to return.</param>
		/// <returns>The matching Semester, if one exists, or null.</returns>
		public SO.Semester GetSemesterByID(string id)
		{
			return SO.Semester.FromDataAccessObject(SemesterLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Maps to the UX_Semester_1 foreign key in the database.</summary>
		public SO.Semester GetSemesterByBeginAndEnd(string begin, string end)
		{
			return SO.Semester.FromDataAccessObject(SemesterLogic.GetByBeginAndEnd(ParseDateTime("Begin", begin), ParseDateTime("End", end)));
		}

		/// <summary>Maps to the UX_Semester_2 foreign key in the database.</summary>
		public SO.Semester GetSemesterByName(string name)
		{
			return SO.Semester.FromDataAccessObject(SemesterLogic.GetByName(name));
		}

		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public IEnumerable<SO.Student> GetStudents(string page)
		{
			return GetPage(StudentLogic.GetAll(), page).Select(o => SO.Student.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Students exist.<summary>
		public int GetStudentsCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Students.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Students method.<summary>
		public int GetStudentsPageCount()
		{
			return ServiceUtil.GetPageCount(GetStudentsCount());
		}
		
		/// <summary>Gets the Student with the specified primary key.</summary>
		/// <param name="id">The primary key of the Student to return.</param>
		/// <returns>The matching Student, if one exists, or null.</returns>
		public SO.Student GetStudentByID(string id)
		{
			return SO.Student.FromDataAccessObject(StudentLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public IEnumerable<SO.Student> GetStudentsByMajorID(string majorID, string page)
		{
			IEnumerable<DA.Student> returnValue = StudentLogic.GetByMajorID(ParseInt("id", majorID));
			
			if (returnValue != null)
				return ServiceUtil.GetPage(returnValue, ParseInt("page", page)).Select(o => SO.Student.FromDataAccessObject(o));
			
			return null;
		}
		
		/// <summary>Gets how many Students by MajorID exist.<summary>
		public int GetStudentsByMajorIDCount(string majorID)
		{
			return StudentLogic.GetByMajorID(ParseInt("majorID", majorID)).Count();
		}
		
		/// <summary>Gets how many pages of data exist for the Students by MajorID method.<summary>
		public int GetStudentsByMajorIDPageCount(string majorID)
		{
			return ServiceUtil.GetPageCount(GetStudentsByMajorIDCount(majorID));
		}

		/// <summary>Maps to the UX_Student_1 foreign key in the database.</summary>
		public SO.Student GetStudentBySSN(string sSN)
		{
			return SO.Student.FromDataAccessObject(StudentLogic.GetBySSN(sSN));
		}

		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public IEnumerable<SO.Teacher> GetTeachers(string page)
		{
			return GetPage(TeacherLogic.GetAll(), page).Select(o => SO.Teacher.FromDataAccessObject(o));
		}
		
		/// <summary>Gets how many Teachers exist.<summary>
		public int GetTeachersCount()
		{
			using(DA.SampleDataContext dataContext = new DA.SampleDataContext())
			{
				return dataContext.Teachers.Count();
			}
		}
		
		/// <summary>Gets how many pages of data exist for the Teachers method.<summary>
		public int GetTeachersPageCount()
		{
			return ServiceUtil.GetPageCount(GetTeachersCount());
		}
		
		/// <summary>Gets the Teacher with the specified primary key.</summary>
		/// <param name="id">The primary key of the Teacher to return.</param>
		/// <returns>The matching Teacher, if one exists, or null.</returns>
		public SO.Teacher GetTeacherByID(string id)
		{
			return SO.Teacher.FromDataAccessObject(TeacherLogic.GetByID(ParseInt("id", id)));
		}

		/// <summary>Maps to the UX_Teacher_1 foreign key in the database.</summary>
		public SO.Teacher GetTeacherBySSN(string sSN)
		{
			return SO.Teacher.FromDataAccessObject(TeacherLogic.GetBySSN(sSN));
		}
	}
}