CREATE TABLE dbo.Course
(
	ID INT IDENTITY,
	SemesterID INT NOT NULL,
	TeacherID INT NOT NULL,
	Number VARCHAR(10) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	[Status] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Course PRIMARY KEY (ID),
	CONSTRAINT FK_Course_Semester FOREIGN KEY (SemesterID) REFERENCES Semester (ID),
	CONSTRAINT FK_Course_Teacher FOREIGN KEY (TeacherID) REFERENCES Teacher (ID),
	CONSTRAINT UX_Course_1 UNIQUE (SemesterID, Number),
	CONSTRAINT UX_Course_2 UNIQUE (SemesterID, Name),
	CONSTRAINT CK_Course_1 CHECK ([Status] IN ('Enrolling', 'Active', 'Inactive'))
);