using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Sample.Service.Utils
{
	public partial class RESTUrlUtil
	{
        public static string Url { get { return "~/"; } }

        public static partial class Service
        {
            public static string Url { get { return string.Format("{0}/Service/", RESTUrlUtil.Url); } }

            public static partial class RESTSvc
            {
                public static string Url { get { return string.Format("{0}/REST.svc", Service.Url); } }

				public static string GetCourses(int page) { return string.Format("{0}/Courses/{1}", RESTSvc.Url, page); }
				public static string GetCoursesCount() { return string.Format("{0}/Courses/Count", RESTSvc.Url); }
				public static string GetCoursesPageCount() { return string.Format("{0}/Courses/PageCount", RESTSvc.Url); }
				public static string GetCourseByID(int id) { return string.Format("{0}/Course/{1}",RESTSvc.Url, id); }
				public static string GetCoursesBySemesterID(int semesterID, int page) { return string.Format("{0}/Semester/{1}/Courses/{2}",RESTSvc.Url, semesterID, page); }
				public static string GetCoursesBySemesterIDCount(int semesterID) { return string.Format("{0}/Semester/{1}/Courses/Count",RESTSvc.Url, semesterID); }
				public static string GetCoursesBySemesterIDPageCount(int semesterID) { return string.Format("{0}/Semester/{1}/Courses/PageCount",RESTSvc.Url, semesterID); }
				public static string GetCoursesByTeacherID(int teacherID, int page) { return string.Format("{0}/Teacher/{1}/Courses/{2}",RESTSvc.Url, teacherID, page); }
				public static string GetCoursesByTeacherIDCount(int teacherID) { return string.Format("{0}/Teacher/{1}/Courses/Count",RESTSvc.Url, teacherID); }
				public static string GetCoursesByTeacherIDPageCount(int teacherID) { return string.Format("{0}/Teacher/{1}/Courses/PageCount",RESTSvc.Url, teacherID); }
				public static string GetCourseBySemesterIDAndNumber(int semesterID, string number) { return string.Format("{0}/Course?SemesterID={{semesterID}}&Number={{number}}",RESTSvc.Url, semesterID, number); }
				public static string GetCourseBySemesterIDAndName(int semesterID, string name) { return string.Format("{0}/Course?SemesterID={{semesterID}}&Name={{name}}",RESTSvc.Url, semesterID, name); }
				public static string GetEnrollments(int page) { return string.Format("{0}/Enrollments/{1}", RESTSvc.Url, page); }
				public static string GetEnrollmentsCount() { return string.Format("{0}/Enrollments/Count", RESTSvc.Url); }
				public static string GetEnrollmentsPageCount() { return string.Format("{0}/Enrollments/PageCount", RESTSvc.Url); }
				public static string GetEnrollmentByID(int id) { return string.Format("{0}/Enrollment/{1}",RESTSvc.Url, id); }
				public static string GetEnrollmentsByStudentID(int studentID, int page) { return string.Format("{0}/Student/{1}/Enrollments/{2}",RESTSvc.Url, studentID, page); }
				public static string GetEnrollmentsByStudentIDCount(int studentID) { return string.Format("{0}/Student/{1}/Enrollments/Count",RESTSvc.Url, studentID); }
				public static string GetEnrollmentsByStudentIDPageCount(int studentID) { return string.Format("{0}/Student/{1}/Enrollments/PageCount",RESTSvc.Url, studentID); }
				public static string GetEnrollmentsByCourseID(int courseID, int page) { return string.Format("{0}/Course/{1}/Enrollments/{2}",RESTSvc.Url, courseID, page); }
				public static string GetEnrollmentsByCourseIDCount(int courseID) { return string.Format("{0}/Course/{1}/Enrollments/Count",RESTSvc.Url, courseID); }
				public static string GetEnrollmentsByCourseIDPageCount(int courseID) { return string.Format("{0}/Course/{1}/Enrollments/PageCount",RESTSvc.Url, courseID); }
				public static string GetEnrollmentByStudentIDAndCourseID(int studentID, int courseID) { return string.Format("{0}/Enrollment?StudentID={{studentID}}&CourseID={{courseID}}",RESTSvc.Url, studentID, courseID); }
				public static string GetMajors(int page) { return string.Format("{0}/Majors/{1}", RESTSvc.Url, page); }
				public static string GetMajorsCount() { return string.Format("{0}/Majors/Count", RESTSvc.Url); }
				public static string GetMajorsPageCount() { return string.Format("{0}/Majors/PageCount", RESTSvc.Url); }
				public static string GetMajorByID(int id) { return string.Format("{0}/Major/{1}",RESTSvc.Url, id); }
				public static string GetMajorByName(string name) { return string.Format("{0}/Major?Name={{name}}",RESTSvc.Url, name); }
				public static string GetSemesters(int page) { return string.Format("{0}/Semesters/{1}", RESTSvc.Url, page); }
				public static string GetSemestersCount() { return string.Format("{0}/Semesters/Count", RESTSvc.Url); }
				public static string GetSemestersPageCount() { return string.Format("{0}/Semesters/PageCount", RESTSvc.Url); }
				public static string GetSemesterByID(int id) { return string.Format("{0}/Semester/{1}",RESTSvc.Url, id); }
				public static string GetSemesterByBeginAndEnd(DateTime begin, DateTime end) { return string.Format("{0}/Semester?Begin={{begin}}&End={{end}}",RESTSvc.Url, begin, end); }
				public static string GetSemesterByName(string name) { return string.Format("{0}/Semester?Name={{name}}",RESTSvc.Url, name); }
				public static string GetStudents(int page) { return string.Format("{0}/Students/{1}", RESTSvc.Url, page); }
				public static string GetStudentsCount() { return string.Format("{0}/Students/Count", RESTSvc.Url); }
				public static string GetStudentsPageCount() { return string.Format("{0}/Students/PageCount", RESTSvc.Url); }
				public static string GetStudentByID(int id) { return string.Format("{0}/Student/{1}",RESTSvc.Url, id); }
				public static string GetStudentsByMajorID(int majorID, int page) { return string.Format("{0}/Major/{1}/Students/{2}",RESTSvc.Url, majorID, page); }
				public static string GetStudentsByMajorIDCount(int majorID) { return string.Format("{0}/Major/{1}/Students/Count",RESTSvc.Url, majorID); }
				public static string GetStudentsByMajorIDPageCount(int majorID) { return string.Format("{0}/Major/{1}/Students/PageCount",RESTSvc.Url, majorID); }
				public static string GetStudentBySSN(string sSN) { return string.Format("{0}/Student?SSN={{sSN}}",RESTSvc.Url, sSN); }
				public static string GetTeachers(int page) { return string.Format("{0}/Teachers/{1}", RESTSvc.Url, page); }
				public static string GetTeachersCount() { return string.Format("{0}/Teachers/Count", RESTSvc.Url); }
				public static string GetTeachersPageCount() { return string.Format("{0}/Teachers/PageCount", RESTSvc.Url); }
				public static string GetTeacherByID(int id) { return string.Format("{0}/Teacher/{1}",RESTSvc.Url, id); }
				public static string GetTeacherBySSN(string sSN) { return string.Format("{0}/Teacher?SSN={{sSN}}",RESTSvc.Url, sSN); }
			}
		}
	}
}