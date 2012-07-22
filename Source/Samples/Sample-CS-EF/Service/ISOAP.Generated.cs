using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Linq.Expressions;
using QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.SOAP;
using QuantumConcepts.CodeGenerator.Sample.Service.Utils;

namespace QuantumConcepts.CodeGenerator.Sample.Service
{
	/// <summary>Exposes functionality through one or more service end points.</summary>
    [ServiceContract]
	public partial interface ISOAP
	{
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCourses(int page);
			
		/// <summary>Gets how many Courses exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesCount();
			
		/// <summary>Gets how many pages of data exist for the GetCourses method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesPageCount();
			
		/// <summary>Gets the Course with the specified primary key.</summary>
		/// <param name="id">The primary key of the Course to return.</param>
		/// <returns>The matching Course, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseByID(int id);

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCoursesBySemesterID(int semesterID, int page);
		
		/// <summary>Gets how many Courses by SemesterID exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesBySemesterIDCount(int semesterID);

		/// <summary>Gets how many pages of data exist for Courses by SemesterID method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesBySemesterIDPageCount(int semesterID);
			

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Course> GetCoursesByTeacherID(int teacherID, int page);
		
		/// <summary>Gets how many Courses by TeacherID exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesByTeacherIDCount(int teacherID);

		/// <summary>Gets how many pages of data exist for Courses by TeacherID method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetCoursesByTeacherIDPageCount(int teacherID);
			

		/// <summary>Maps to the UX_Course_1 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseBySemesterIDAndNumber(int semesterID, string number);
	

		/// <summary>Maps to the UX_Course_2 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Course GetCourseBySemesterIDAndName(int semesterID, string name);
	
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollments(int page);
			
		/// <summary>Gets how many Enrollments exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsCount();
			
		/// <summary>Gets how many pages of data exist for the GetEnrollments method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsPageCount();
			
		/// <summary>Gets the Enrollment with the specified primary key.</summary>
		/// <param name="id">The primary key of the Enrollment to return.</param>
		/// <returns>The matching Enrollment, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Enrollment GetEnrollmentByID(int id);

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollmentsByStudentID(int studentID, int page);
		
		/// <summary>Gets how many Enrollments by StudentID exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByStudentIDCount(int studentID);

		/// <summary>Gets how many pages of data exist for Enrollments by StudentID method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByStudentIDPageCount(int studentID);
			

		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Enrollment> GetEnrollmentsByCourseID(int courseID, int page);
		
		/// <summary>Gets how many Enrollments by CourseID exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByCourseIDCount(int courseID);

		/// <summary>Gets how many pages of data exist for Enrollments by CourseID method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetEnrollmentsByCourseIDPageCount(int courseID);
			

		/// <summary>Maps to the UX_Enrollment_1 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Enrollment GetEnrollmentByStudentIDAndCourseID(int studentID, int courseID);
	
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Major> GetMajors(int page);
			
		/// <summary>Gets how many Majors exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetMajorsCount();
			
		/// <summary>Gets how many pages of data exist for the GetMajors method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetMajorsPageCount();
			
		/// <summary>Gets the Major with the specified primary key.</summary>
		/// <param name="id">The primary key of the Major to return.</param>
		/// <returns>The matching Major, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Major GetMajorByID(int id);

		/// <summary>Maps to the UX_Major foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Major GetMajorByName(string name);
	
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Semester> GetSemesters(int page);
			
		/// <summary>Gets how many Semesters exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetSemestersCount();
			
		/// <summary>Gets how many pages of data exist for the GetSemesters method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetSemestersPageCount();
			
		/// <summary>Gets the Semester with the specified primary key.</summary>
		/// <param name="id">The primary key of the Semester to return.</param>
		/// <returns>The matching Semester, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByID(int id);

		/// <summary>Maps to the UX_Semester_1 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByBeginAndEnd(DateTime begin, DateTime end);
	

		/// <summary>Maps to the UX_Semester_2 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Semester GetSemesterByName(string name);
	
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Student> GetStudents(int page);
			
		/// <summary>Gets how many Students exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsCount();
			
		/// <summary>Gets how many pages of data exist for the GetStudents method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsPageCount();
			
		/// <summary>Gets the Student with the specified primary key.</summary>
		/// <param name="id">The primary key of the Student to return.</param>
		/// <returns>The matching Student, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Student GetStudentByID(int id);

		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Student> GetStudentsByMajorID(int majorID, int page);
		
		/// <summary>Gets how many Students by MajorID exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsByMajorIDCount(int majorID);

		/// <summary>Gets how many pages of data exist for Students by MajorID method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetStudentsByMajorIDPageCount(int majorID);
			

		/// <summary>Maps to the UX_Student_1 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Student GetStudentBySSN(string sSN);
	
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		IEnumerable<Teacher> GetTeachers(int page);
			
		/// <summary>Gets how many Teachers exist.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetTeachersCount();
			
		/// <summary>Gets how many pages of data exist for the GetTeachers method.<summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		int GetTeachersPageCount();
			
		/// <summary>Gets the Teacher with the specified primary key.</summary>
		/// <param name="id">The primary key of the Teacher to return.</param>
		/// <returns>The matching Teacher, if one exists, or null.</returns>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Teacher GetTeacherByID(int id);

		/// <summary>Maps to the UX_Teacher_1 foreign key in the database.</summary>
		[OperationContract]
		[FaultContract(typeof(ServiceFault))]
		Teacher GetTeacherBySSN(string sSN);
	
	}
}