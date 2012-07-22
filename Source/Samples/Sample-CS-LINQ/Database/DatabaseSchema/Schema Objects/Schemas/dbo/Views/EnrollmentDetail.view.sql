CREATE VIEW dbo.EnrollmentDetails
AS
	SELECT
		Course.ID AS CourseID,
		Course.Number AS CourseNumber,
		Course.Name AS CourseName,
		Course.[Status] AS CourseStatus,
		Semester.ID AS SemesterID,
		Semester.[Begin] AS SemesterBegin,
		Semester.[End] AS SemesterEnd,
		Semester.Name AS SemesterName,
		Teacher.ID AS TeacherID,
		Teacher.FirstName AS TeacherFirstName,
		Teacher.LastName AS TeacherLastName,
		Teacher.Active AS TeacherActive,
		Student.ID AS StudentID,
		Student.FirstName AS StudentFirstName,
		Student.LastName AS StudentLastName,
		Student.Active AS StudentActive
	FROM
		dbo.Enrollment
		JOIN dbo.Course ON Course.ID = Enrollment.CourseID
		JOIN dbo.Semester Semester ON Semester.ID = Course.SemesterID
		JOIN dbo.Teacher Teacher ON Teacher.ID = Course.TeacherID
		JOIN dbo.Student Student ON Student.ID = Enrollment.StudentID;