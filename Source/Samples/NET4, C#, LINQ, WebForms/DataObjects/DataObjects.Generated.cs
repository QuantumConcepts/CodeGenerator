using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Runtime.Serialization;

namespace  QuantumConcepts.CodeGenerator.Sample.DataObjects
{
	/// <summary>Maps to the Course table in the database.</summary>
	[DataContract]
	public partial class Course
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the SemesterID column.</summary>
		protected int _SemesterID;
			
		/// <summary>Maps to the TeacherID column.</summary>
		protected int _TeacherID;
			
		/// <summary>Maps to the Number column.</summary>
		protected string _Number;
			
		/// <summary>Maps to the Name column.</summary>
		protected string _Name;
			
		/// <summary>Maps to the Status column.</summary>
		protected CourseStatus _Status;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The SemesterID Property maps to the SemesterID column in the database.</summary>
		[DataMember]
		public int SemesterID { get { return _SemesterID; } set { _SemesterID = value; } }

		/// <summary>The TeacherID Property maps to the TeacherID column in the database.</summary>
		[DataMember]
		public int TeacherID { get { return _TeacherID; } set { _TeacherID = value; } }

		/// <summary>The Number Property maps to the Number column in the database.</summary>
		[DataMember]
		public string Number { get { return _Number; } set { _Number = value; } }

		/// <summary>The Name Property maps to the Name column in the database.</summary>
		[DataMember]
		public string Name { get { return _Name; } set { _Name = value; } }

		/// <summary>The Status Property maps to the Status column in the database.</summary>
		[DataMember]
		public CourseStatus Status { get { return _Status; } set { _Status = value; } }
	}

	/// <summary>Maps to the Enrollment table in the database.</summary>
	[DataContract]
	public partial class Enrollment
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the StudentID column.</summary>
		protected int _StudentID;
			
		/// <summary>Maps to the CourseID column.</summary>
		protected int _CourseID;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The StudentID Property maps to the StudentID column in the database.</summary>
		[DataMember]
		public int StudentID { get { return _StudentID; } set { _StudentID = value; } }

		/// <summary>The CourseID Property maps to the CourseID column in the database.</summary>
		[DataMember]
		public int CourseID { get { return _CourseID; } set { _CourseID = value; } }
	}

	/// <summary>Maps to the Major table in the database.</summary>
	[DataContract]
	public partial class Major
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the Name column.</summary>
		protected string _Name;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The Name Property maps to the Name column in the database.</summary>
		[DataMember]
		public string Name { get { return _Name; } set { _Name = value; } }
	}

	/// <summary>Maps to the Semester table in the database.</summary>
	[DataContract]
	public partial class Semester
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the Begin column.</summary>
		protected DateTime _Begin;
			
		/// <summary>Maps to the End column.</summary>
		protected DateTime _End;
			
		/// <summary>Maps to the Name column.</summary>
		protected string _Name;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The Begin Property maps to the Begin column in the database.</summary>
		[DataMember]
		public DateTime Begin { get { return _Begin; } set { _Begin = value; } }

		/// <summary>The End Property maps to the End column in the database.</summary>
		[DataMember]
		public DateTime End { get { return _End; } set { _End = value; } }

		/// <summary>The Name Property maps to the Name column in the database.</summary>
		[DataMember]
		public string Name { get { return _Name; } set { _Name = value; } }
	}

	/// <summary>Maps to the Student table in the database.</summary>
	[DataContract]
	public partial class Student
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the MajorID column.</summary>
		protected int _MajorID;
			
		/// <summary>Maps to the SSN column.</summary>
		protected string _SSN;
			
		/// <summary>Maps to the FirstName column.</summary>
		protected string _FirstName;
			
		/// <summary>Maps to the LastName column.</summary>
		protected string _LastName;
			
		/// <summary>Maps to the Active column.</summary>
		protected bool _Active;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The MajorID Property maps to the MajorID column in the database.</summary>
		[DataMember]
		public int MajorID { get { return _MajorID; } set { _MajorID = value; } }

		/// <summary>The SSN Property maps to the SSN column in the database.</summary>
		[DataMember]
		public string SSN { get { return _SSN; } set { _SSN = value; } }

		/// <summary>The FirstName Property maps to the FirstName column in the database.</summary>
		[DataMember]
		public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

		/// <summary>The LastName Property maps to the LastName column in the database.</summary>
		[DataMember]
		public string LastName { get { return _LastName; } set { _LastName = value; } }

		/// <summary>The Active Property maps to the Active column in the database.</summary>
		[DataMember]
		public bool Active { get { return _Active; } set { _Active = value; } }
	}

	/// <summary>Maps to the Teacher table in the database.</summary>
	[DataContract]
	public partial class Teacher
	{
		/// <summary>Maps to the ID column.</summary>
		protected int _ID;
			
		/// <summary>Maps to the SSN column.</summary>
		protected string _SSN;
			
		/// <summary>Maps to the FirstName column.</summary>
		protected string _FirstName;
			
		/// <summary>Maps to the LastName column.</summary>
		protected string _LastName;
			
		/// <summary>Maps to the Active column.</summary>
		protected bool _Active;
			
		/// <summary>The ID Property maps to the ID column in the database.</summary>
		[DataMember]
		public int ID { get { return _ID; } set { _ID = value; } }

		/// <summary>The SSN Property maps to the SSN column in the database.</summary>
		[DataMember]
		public string SSN { get { return _SSN; } set { _SSN = value; } }

		/// <summary>The FirstName Property maps to the FirstName column in the database.</summary>
		[DataMember]
		public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

		/// <summary>The LastName Property maps to the LastName column in the database.</summary>
		[DataMember]
		public string LastName { get { return _LastName; } set { _LastName = value; } }

		/// <summary>The Active Property maps to the Active column in the database.</summary>
		[DataMember]
		public bool Active { get { return _Active; } set { _Active = value; } }
	}
}