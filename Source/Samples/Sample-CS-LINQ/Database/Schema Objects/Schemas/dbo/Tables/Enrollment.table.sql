CREATE TABLE dbo.Enrollment
(
	ID INT IDENTITY,
	StudentID INT NOT NULL,
	CourseID INT NOT NULL,
	CONSTRAINT PK_Enrollment PRIMARY KEY (ID),
	CONSTRAINT FK_Enrollment_Student FOREIGN KEY (StudentID) REFERENCES Student (ID),
	CONSTRAINT FK_Enrollment_Course FOREIGN KEY (CourseID) REFERENCES Course (ID),
	CONSTRAINT UX_Enrollment_1 UNIQUE (StudentID, CourseID)
);