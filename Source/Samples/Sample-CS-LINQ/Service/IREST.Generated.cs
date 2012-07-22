using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Linq.Expressions;
using QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.REST;
using QuantumConcepts.CodeGenerator.Sample.Service.Utils;
using WcfRestContrib.ServiceModel.Description;

namespace QuantumConcepts.CodeGenerator.Sample.Service
{
	/// <summary>Exposes functionality through one or more service end points.</summary>
    [ServiceContract]
	public partial interface IREST
	{
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Courses/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCourses(string page);
			
		/// <summary>Gets how many Courses exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Courses/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesCount();
			
		/// <summary>Gets how many pages of data exist for the Courses method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Courses/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesPageCount();
			
		/// <summary>Gets the Course with the specified primary key.</summary>
		/// <param name="id">The primary key of the Course to return.</param>
		/// <returns>The matching Course, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseByID(string id);

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/{semesterID}/Courses/{page}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCoursesBySemesterID(string semesterID, string page);

		/// <summary>Gets how many Courses by SemesterID exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/{semesterID}/Courses/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesBySemesterIDCount(string semesterID);

		/// <summary>Gets how many pages of data exist for the Courses by SemesterID method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/{semesterID}/Courses/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesBySemesterIDPageCount(string semesterID);

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Teacher/{teacherID}/Courses/{page}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCoursesByTeacherID(string teacherID, string page);

		/// <summary>Gets how many Courses by TeacherID exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Teacher/{teacherID}/Courses/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesByTeacherIDCount(string teacherID);

		/// <summary>Gets how many pages of data exist for the Courses by TeacherID method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Teacher/{teacherID}/Courses/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesByTeacherIDPageCount(string teacherID);

		/// <summary>Maps to the UX_Course_1 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/SemesterID={semesterID}/Number={number}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseBySemesterIDAndNumber(string semesterID, string number);

		/// <summary>Maps to the UX_Course_2 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/SemesterID={semesterID}/Name={name}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseBySemesterIDAndName(string semesterID, string name);
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Enrollments/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollments(string page);
			
		/// <summary>Gets how many Enrollments exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Enrollments/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsCount();
			
		/// <summary>Gets how many pages of data exist for the Enrollments method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Enrollments/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsPageCount();
			
		/// <summary>Gets the Enrollment with the specified primary key.</summary>
		/// <param name="id">The primary key of the Enrollment to return.</param>
		/// <returns>The matching Enrollment, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Enrollment/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Enrollment GetEnrollmentByID(string id);

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Student/{studentID}/Enrollments/{page}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollmentsByStudentID(string studentID, string page);

		/// <summary>Gets how many Enrollments by StudentID exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Student/{studentID}/Enrollments/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByStudentIDCount(string studentID);

		/// <summary>Gets how many pages of data exist for the Enrollments by StudentID method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Student/{studentID}/Enrollments/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByStudentIDPageCount(string studentID);

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/{courseID}/Enrollments/{page}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollmentsByCourseID(string courseID, string page);

		/// <summary>Gets how many Enrollments by CourseID exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/{courseID}/Enrollments/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByCourseIDCount(string courseID);

		/// <summary>Gets how many pages of data exist for the Enrollments by CourseID method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Course/{courseID}/Enrollments/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByCourseIDPageCount(string courseID);

		/// <summary>Maps to the UX_Enrollment_1 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Enrollment/StudentID={studentID}/CourseID={courseID}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Enrollment GetEnrollmentByStudentIDAndCourseID(string studentID, string courseID);
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Majors/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Major> GetMajors(string page);
			
		/// <summary>Gets how many Majors exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Majors/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetMajorsCount();
			
		/// <summary>Gets how many pages of data exist for the Majors method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Majors/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetMajorsPageCount();
			
		/// <summary>Gets the Major with the specified primary key.</summary>
		/// <param name="id">The primary key of the Major to return.</param>
		/// <returns>The matching Major, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Major/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Major GetMajorByID(string id);

		/// <summary>Maps to the UX_Major foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Major/Name={name}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Major GetMajorByName(string name);
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Semesters/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Semester> GetSemesters(string page);
			
		/// <summary>Gets how many Semesters exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semesters/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetSemestersCount();
			
		/// <summary>Gets how many pages of data exist for the Semesters method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semesters/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetSemestersPageCount();
			
		/// <summary>Gets the Semester with the specified primary key.</summary>
		/// <param name="id">The primary key of the Semester to return.</param>
		/// <returns>The matching Semester, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByID(string id);

		/// <summary>Maps to the UX_Semester_1 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/Begin={begin}/End={end}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByBeginAndEnd(string begin, string end);

		/// <summary>Maps to the UX_Semester_2 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Semester/Name={name}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByName(string name);
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Students/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Student> GetStudents(string page);
			
		/// <summary>Gets how many Students exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Students/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsCount();
			
		/// <summary>Gets how many pages of data exist for the Students method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Students/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsPageCount();
			
		/// <summary>Gets the Student with the specified primary key.</summary>
		/// <param name="id">The primary key of the Student to return.</param>
		/// <returns>The matching Student, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Student/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Student GetStudentByID(string id);

		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Major/{majorID}/Students/{page}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Student> GetStudentsByMajorID(string majorID, string page);

		/// <summary>Gets how many Students by MajorID exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Major/{majorID}/Students/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsByMajorIDCount(string majorID);

		/// <summary>Gets how many pages of data exist for the Students by MajorID method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Major/{majorID}/Students/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsByMajorIDPageCount(string majorID);

		/// <summary>Maps to the UX_Student_1 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Student/SSN={sSN}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Student GetStudentBySSN(string sSN);
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Teachers/{page}")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Teacher> GetTeachers(string page);
			
		/// <summary>Gets how many Teachers exist.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Teachers/Count")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetTeachersCount();
			
		/// <summary>Gets how many pages of data exist for the Teachers method.<summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Teachers/PageCount")]
       	[WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		int GetTeachersPageCount();
			
		/// <summary>Gets the Teacher with the specified primary key.</summary>
		/// <param name="id">The primary key of the Teacher to return.</param>
		/// <returns>The matching Teacher, if one exists, or null.</returns>
		[OperationContract]
		[WebGet (UriTemplate = "/Teacher/{id}")]
        [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Teacher GetTeacherByID(string id);

		/// <summary>Maps to the UX_Teacher_1 foreign key in the database.</summary>
		[OperationContract]
		[WebGet (UriTemplate = "/Teacher/SSN={sSN}")]
  
	    [WebDispatchFormatter]
		[FaultContract(typeof(ServiceFault))]
		Teacher GetTeacherBySSN(string sSN);
	}
}