using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;
using QuantumConcepts.CodeGenerator.Sample.Common;
using QuantumConcepts.CodeGenerator.Sample.Common.Utils;
using DO = QuantumConcepts.CodeGenerator.Sample.DataObjects;
using DA = QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.DataAccess.Cache;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess
{
	/// <summary>Exposes all functionality to interact with the database.</summary>
	[DatabaseAttribute]
	public partial class SampleDataContext : DataContext
	{
		private static MappingSource mappingSource = new AttributeMappingSource();
		
        /// <summary>Creates a new DataContext with which to query and update data.</summary>
        public SampleDataContext()
            : base(SampleConfigUtil.Instance.ConnectionString, mappingSource)
        {
            OnCreated();
        }

		/// <summary>Creates a new DataContext with which to query and update data.</summary>
		/// <param name="connection">The connection string to use.</param>
		public SampleDataContext(string connection)
			 : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Creates a new DataContext with which to query and update data.</summary>
		/// <param name="connection">The connection to use.</param>
		public SampleDataContext(IDbConnection connection)
			 : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Creates a new DataContext with which to query and update data.</summary>
		/// <param name="connection">The connection string to use.</param>
		/// <param name="mappingSource">The mapping source to use.</param>
		public SampleDataContext(string connection, MappingSource mappingSource)
			 : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		/// <summary>Creates a new DataContext with which to query and update data.</summary>
		/// <param name="connection">The connection to use.</param>
		/// <param name="mappingSource">The mapping source to use.</param>
		public SampleDataContext(IDbConnection connection, MappingSource mappingSource)
			 : base(connection, mappingSource)
		{
			OnCreated();
		}
		
		partial void OnCreated();
		partial void InsertCourse(DA.Course instance);
		partial void UpdateCourse(DA.Course instance);
		partial void DeleteCourse(DA.Course instance);
		partial void InsertEnrollment(DA.Enrollment instance);
		partial void UpdateEnrollment(DA.Enrollment instance);
		partial void DeleteEnrollment(DA.Enrollment instance);
		partial void InsertMajor(DA.Major instance);
		partial void UpdateMajor(DA.Major instance);
		partial void DeleteMajor(DA.Major instance);
		partial void InsertSemester(DA.Semester instance);
		partial void UpdateSemester(DA.Semester instance);
		partial void DeleteSemester(DA.Semester instance);
		partial void InsertStudent(DA.Student instance);
		partial void UpdateStudent(DA.Student instance);
		partial void DeleteStudent(DA.Student instance);
		partial void InsertTeacher(DA.Teacher instance);
		partial void UpdateTeacher(DA.Teacher instance);
		partial void DeleteTeacher(DA.Teacher instance);
		/// <summary>Maps to the Course table in the database.</summary>
		public Table<DA.Course> Courses { get { return this.GetTable<DA.Course>(); } }

		/// <summary>Maps to the Enrollment table in the database.</summary>
		public Table<DA.Enrollment> Enrollments { get { return this.GetTable<DA.Enrollment>(); } }

		/// <summary>Maps to the Major table in the database.</summary>
		public Table<DA.Major> Majors { get { return this.GetTable<DA.Major>(); } }

		/// <summary>Maps to the Semester table in the database.</summary>
		public Table<DA.Semester> Semesters { get { return this.GetTable<DA.Semester>(); } }

		/// <summary>Maps to the Student table in the database.</summary>
		public Table<DA.Student> Students { get { return this.GetTable<DA.Student>(); } }

		/// <summary>Maps to the Teacher table in the database.</summary>
		public Table<DA.Teacher> Teachers { get { return this.GetTable<DA.Teacher>(); } }
	}

	/// <summary>Maps to the Course table in the database.</summary>
	[TableAttribute(Name="dbo.Course")]
	public partial class Course : DO.Course, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntitySet<DA.Enrollment> _Enrollments;
		
		private EntityRef<DA.Semester> _Semester;
		private EntityRef<DA.Teacher> _Teacher;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the SemesterID column.</summary>
		[ColumnAttribute(Name="SemesterID", Storage="_SemesterID", DbType="int(10) NULL")]
		public new int SemesterID
		{
			get { return this._SemesterID; }
			set
			{
				if (!object.Equals(value, this._SemesterID))
				{
					if (_Semester.HasLoadedOrAssignedValue && (_Semester.Entity == null || _Semester.Entity.ID != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						
					this.OnSemesterIDChanging(value);
					this.OnPropertyChanging();
					this._SemesterID = value;
					this.OnPropertyChanged("SemesterID");
					this.OnSemesterIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the TeacherID column.</summary>
		[ColumnAttribute(Name="TeacherID", Storage="_TeacherID", DbType="int(10) NULL")]
		public new int TeacherID
		{
			get { return this._TeacherID; }
			set
			{
				if (!object.Equals(value, this._TeacherID))
				{
					if (_Teacher.HasLoadedOrAssignedValue && (_Teacher.Entity == null || _Teacher.Entity.ID != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						
					this.OnTeacherIDChanging(value);
					this.OnPropertyChanging();
					this._TeacherID = value;
					this.OnPropertyChanged("TeacherID");
					this.OnTeacherIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the Number column.</summary>
		[ColumnAttribute(Name="Number", Storage="_Number", DbType="varchar(10) NULL")]
		public new string Number
		{
			get { return this._Number; }
			set
			{
				if (!object.Equals(value, this._Number))
				{
					this.OnNumberChanging(value);
					this.OnPropertyChanging();
					this._Number = value;
					this.OnPropertyChanged("Number");
					this.OnNumberChanged();
				}
			}
		}
		
		/// <summary>Maps to the Name column.</summary>
		[ColumnAttribute(Name="Name", Storage="_Name", DbType="varchar(50) NULL")]
		public new string Name
		{
			get { return this._Name; }
			set
			{
				if (!object.Equals(value, this._Name))
				{
					this.OnNameChanging(value);
					this.OnPropertyChanging();
					this._Name = value;
					this.OnPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the Status column.</summary>
		[ColumnAttribute(Name="Status", Storage="_Status", DbType="varchar(10) NULL")]
		public new DO.CourseStatus Status
		{
			get { return this._Status; }
			set
			{
				if (!object.Equals(value, this._Status))
				{
					this.OnStatusChanging(value);
					this.OnPropertyChanging();
					this._Status = value;
					this.OnPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Enrollment_Course foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Enrollment_Course", Storage="_Enrollments", ThisKey="ID", OtherKey="CourseID")]
		public EntitySet<DA.Enrollment> Enrollments
		{
			get { return _Enrollments; }
			set { _Enrollments.Assign(value); }
		}
		
		/// <summary>Maps to the FK_Course_Semester foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Course_Semester", Storage="_Semester", ThisKey="SemesterID", OtherKey="ID", IsForeignKey=true)]
		public DA.Semester Semester
		{
			
			get { return SemesterCache.Instance.Find(this.SemesterID); }
			set
			{
				Semester previousValue = _Semester.Entity;
				
				if (previousValue != value || !_Semester.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_Semester.Entity = null;
						previousValue.Courses.Remove(this);
					}
				}
				
				_Semester.Entity = value;
				
				if (value != null)
				{
					value.Courses.Add(this);
					this.SemesterID = value.ID;
				}
				else
				{
					_Semester = default(EntityRef<Semester>);
					this.SemesterID = default(int);
				}
				
				this.OnPropertyChanged("Semester");
			}
		}
		
		/// <summary>Maps to the FK_Course_Teacher foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Course_Teacher", Storage="_Teacher", ThisKey="TeacherID", OtherKey="ID", IsForeignKey=true)]
		public DA.Teacher Teacher
		{
			
			get { return _Teacher.Entity; }
							
			set
			{
				Teacher previousValue = _Teacher.Entity;
				
				if (previousValue != value || !_Teacher.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_Teacher.Entity = null;
						previousValue.Courses.Remove(this);
					}
				}
				
				_Teacher.Entity = value;
				
				if (value != null)
				{
					value.Courses.Add(this);
					this.TeacherID = value.ID;
				}
				else
				{
					_Teacher = default(EntityRef<Teacher>);
					this.TeacherID = default(int);
				}
				
				this.OnPropertyChanged("Teacher");
			}
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Course()
		{
			_Enrollments= new EntitySet<DA.Enrollment>(new Action<DA.Enrollment>(this.AttachEnrollments), new Action<DA.Enrollment>(this.DetachEnrollments));
			_Semester = default(EntityRef<DA.Semester>);
			_Teacher = default(EntityRef<DA.Teacher>);
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll(SampleDataContext context)
		{
			return context.Courses;
		}

		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static DA.Course GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static DA.Course GetByID(SampleDataContext context, int ID)
		{
			return context.Courses.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(int iD)
		{
            return GetBySemesterID(new SampleDataContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(SampleDataContext context, int iD)
		{
				var source = context.Courses;
			return (from o in source where o.SemesterID == iD select o);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(int iD)
		{
            return GetByTeacherID(new SampleDataContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(SampleDataContext context, int iD)
		{
				var source = context.Courses;
			return (from o in source where o.TeacherID == iD select o);
		}
		
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static DA.Course GetBySemesterIDAndNumber(int semesterID, string number)
		{
			return GetBySemesterIDAndNumber(new SampleDataContext(), semesterID, number);
		}
		
		public static Course GetBySemesterIDAndNumber(SampleDataContext context, int semesterID, string number)
		{
			return context.Courses.FirstOrDefault(o => o.SemesterID == semesterID && o.Number == number);
		}
		
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static DA.Course GetBySemesterIDAndName(int semesterID, string name)
		{
			return GetBySemesterIDAndName(new SampleDataContext(), semesterID, name);
		}
		
		public static Course GetBySemesterIDAndName(SampleDataContext context, int semesterID, string name)
		{
			return context.Courses.FirstOrDefault(o => o.SemesterID == semesterID && o.Name == name);
		}
		
		private void AttachEnrollments(Enrollment entity)
		{
			this.OnPropertyChanging();
			entity.Course = this;
		}

		private void DetachEnrollments(Enrollment entity)
		{
			this.OnPropertyChanging();
			entity.Course = null;
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Course ToBaseDataObject()
	    {
	        return new DO.Course()
	        {
					ID = this.ID, 
					SemesterID = this.SemesterID, 
					TeacherID = this.TeacherID, 
					Number = this.Number, 
					Name = this.Name, 
					Status = this.Status
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnSemesterIDChanging(int value);
		partial void OnSemesterIDChanged();
		partial void OnTeacherIDChanging(int value);
		partial void OnTeacherIDChanged();
		partial void OnNumberChanging(string value);
		partial void OnNumberChanged();
		partial void OnNameChanging(string value);
		partial void OnNameChanged();
		partial void OnStatusChanging(DO.CourseStatus value);
		partial void OnStatusChanged();
		
        public override string ToString()
        {
        	return this.FullName;
        }
	}

	/// <summary>Maps to the Enrollment table in the database.</summary>
	[TableAttribute(Name="dbo.Enrollment")]
	public partial class Enrollment : DO.Enrollment, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntityRef<DA.Student> _Student;
		private EntityRef<DA.Course> _Course;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the StudentID column.</summary>
		[ColumnAttribute(Name="StudentID", Storage="_StudentID", DbType="int(10) NULL")]
		public new int StudentID
		{
			get { return this._StudentID; }
			set
			{
				if (!object.Equals(value, this._StudentID))
				{
					if (_Student.HasLoadedOrAssignedValue && (_Student.Entity == null || _Student.Entity.ID != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						
					this.OnStudentIDChanging(value);
					this.OnPropertyChanging();
					this._StudentID = value;
					this.OnPropertyChanged("StudentID");
					this.OnStudentIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the CourseID column.</summary>
		[ColumnAttribute(Name="CourseID", Storage="_CourseID", DbType="int(10) NULL")]
		public new int CourseID
		{
			get { return this._CourseID; }
			set
			{
				if (!object.Equals(value, this._CourseID))
				{
					if (_Course.HasLoadedOrAssignedValue && (_Course.Entity == null || _Course.Entity.ID != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						
					this.OnCourseIDChanging(value);
					this.OnPropertyChanging();
					this._CourseID = value;
					this.OnPropertyChanged("CourseID");
					this.OnCourseIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Enrollment_Student foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Enrollment_Student", Storage="_Student", ThisKey="StudentID", OtherKey="ID", IsForeignKey=true)]
		public DA.Student Student
		{
			
			get { return _Student.Entity; }
							
			set
			{
				Student previousValue = _Student.Entity;
				
				if (previousValue != value || !_Student.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_Student.Entity = null;
						previousValue.Enrollments.Remove(this);
					}
				}
				
				_Student.Entity = value;
				
				if (value != null)
				{
					value.Enrollments.Add(this);
					this.StudentID = value.ID;
				}
				else
				{
					_Student = default(EntityRef<Student>);
					this.StudentID = default(int);
				}
				
				this.OnPropertyChanged("Student");
			}
		}
		
		/// <summary>Maps to the FK_Enrollment_Course foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Enrollment_Course", Storage="_Course", ThisKey="CourseID", OtherKey="ID", IsForeignKey=true)]
		public DA.Course Course
		{
			
			get { return _Course.Entity; }
							
			set
			{
				Course previousValue = _Course.Entity;
				
				if (previousValue != value || !_Course.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_Course.Entity = null;
						previousValue.Enrollments.Remove(this);
					}
				}
				
				_Course.Entity = value;
				
				if (value != null)
				{
					value.Enrollments.Add(this);
					this.CourseID = value.ID;
				}
				else
				{
					_Course = default(EntityRef<Course>);
					this.CourseID = default(int);
				}
				
				this.OnPropertyChanged("Course");
			}
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Enrollment()
		{
			_Student = default(EntityRef<DA.Student>);
			_Course = default(EntityRef<DA.Course>);
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll(SampleDataContext context)
		{
			return context.Enrollments;
		}

		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static DA.Enrollment GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static DA.Enrollment GetByID(SampleDataContext context, int ID)
		{
			return context.Enrollments.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(int iD)
		{
            return GetByStudentID(new SampleDataContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(SampleDataContext context, int iD)
		{
				var source = context.Enrollments;
			return (from o in source where o.StudentID == iD select o);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(int iD)
		{
            return GetByCourseID(new SampleDataContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(SampleDataContext context, int iD)
		{
				var source = context.Enrollments;
			return (from o in source where o.CourseID == iD select o);
		}
		
		/// <summary>Gets the Enrollment matching the unique index using the passed-in values.</summary>
		public static DA.Enrollment GetByStudentIDAndCourseID(int studentID, int courseID)
		{
			return GetByStudentIDAndCourseID(new SampleDataContext(), studentID, courseID);
		}
		
		public static Enrollment GetByStudentIDAndCourseID(SampleDataContext context, int studentID, int courseID)
		{
			return context.Enrollments.FirstOrDefault(o => o.StudentID == studentID && o.CourseID == courseID);
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Enrollment ToBaseDataObject()
	    {
	        return new DO.Enrollment()
	        {
					ID = this.ID, 
					StudentID = this.StudentID, 
					CourseID = this.CourseID
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnStudentIDChanging(int value);
		partial void OnStudentIDChanged();
		partial void OnCourseIDChanging(int value);
		partial void OnCourseIDChanged();
	}

	/// <summary>Maps to the Major table in the database.</summary>
	[TableAttribute(Name="dbo.Major")]
	public partial class Major : DO.Major, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntitySet<DA.Student> _Students;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the Name column.</summary>
		[ColumnAttribute(Name="Name", Storage="_Name", DbType="varchar(50) NULL")]
		public new string Name
		{
			get { return this._Name; }
			set
			{
				if (!object.Equals(value, this._Name))
				{
					this.OnNameChanging(value);
					this.OnPropertyChanging();
					this._Name = value;
					this.OnPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Student_Major foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Student_Major", Storage="_Students", ThisKey="ID", OtherKey="MajorID")]
		public EntitySet<DA.Student> Students
		{
			get { return _Students; }
			set { _Students.Assign(value); }
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Major()
		{
			_Students= new EntitySet<DA.Student>(new Action<DA.Student>(this.AttachStudents), new Action<DA.Student>(this.DetachStudents));
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll(SampleDataContext context)
		{
			return context.Majors;
		}

		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static DA.Major GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static DA.Major GetByID(SampleDataContext context, int ID)
		{
			return context.Majors.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Major matching the unique index using the passed-in values.</summary>
		public static DA.Major GetByName(string name)
		{
			return GetByName(new SampleDataContext(), name);
		}
		
		public static Major GetByName(SampleDataContext context, string name)
		{
			return context.Majors.FirstOrDefault(o => o.Name == name);
		}
		
		private void AttachStudents(Student entity)
		{
			this.OnPropertyChanging();
			entity.Major = this;
		}

		private void DetachStudents(Student entity)
		{
			this.OnPropertyChanging();
			entity.Major = null;
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Major ToBaseDataObject()
	    {
	        return new DO.Major()
	        {
					ID = this.ID, 
					Name = this.Name
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnNameChanging(string value);
		partial void OnNameChanged();
		
        public override string ToString()
        {
        	return this.Name;
        }
	}

	/// <summary>Maps to the Semester table in the database.</summary>
	[TableAttribute(Name="dbo.Semester")]
	public partial class Semester : DO.Semester, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntitySet<DA.Course> _Courses;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the Begin column.</summary>
		[ColumnAttribute(Name="Begin", Storage="_Begin", DbType="smalldatetime(16) NULL")]
		public new DateTime Begin
		{
			get { return this._Begin; }
			set
			{
				if (!object.Equals(value, this._Begin))
				{
					this.OnBeginChanging(value);
					this.OnPropertyChanging();
					this._Begin = value;
					this.OnPropertyChanged("Begin");
					this.OnBeginChanged();
				}
			}
		}
		
		/// <summary>Maps to the End column.</summary>
		[ColumnAttribute(Name="End", Storage="_End", DbType="smalldatetime(16) NULL")]
		public new DateTime End
		{
			get { return this._End; }
			set
			{
				if (!object.Equals(value, this._End))
				{
					this.OnEndChanging(value);
					this.OnPropertyChanging();
					this._End = value;
					this.OnPropertyChanged("End");
					this.OnEndChanged();
				}
			}
		}
		
		/// <summary>Maps to the Name column.</summary>
		[ColumnAttribute(Name="Name", Storage="_Name", DbType="varchar(25) NULL")]
		public new string Name
		{
			get { return this._Name; }
			set
			{
				if (!object.Equals(value, this._Name))
				{
					this.OnNameChanging(value);
					this.OnPropertyChanging();
					this._Name = value;
					this.OnPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Course_Semester foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Course_Semester", Storage="_Courses", ThisKey="ID", OtherKey="SemesterID")]
		public EntitySet<DA.Course> Courses
		{
			get { return _Courses; }
			set { _Courses.Assign(value); }
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Semester()
		{
			_Courses= new EntitySet<DA.Course>(new Action<DA.Course>(this.AttachCourses), new Action<DA.Course>(this.DetachCourses));
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll(SampleDataContext context)
		{
			return context.Semesters;
		}

		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static DA.Semester GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static DA.Semester GetByID(SampleDataContext context, int ID)
		{
			return context.Semesters.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static DA.Semester GetByBeginAndEnd(DateTime begin, DateTime end)
		{
			return GetByBeginAndEnd(new SampleDataContext(), begin, end);
		}
		
		public static Semester GetByBeginAndEnd(SampleDataContext context, DateTime begin, DateTime end)
		{
			return context.Semesters.FirstOrDefault(o => o.Begin == begin && o.End == end);
		}
		
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static DA.Semester GetByName(string name)
		{
			return GetByName(new SampleDataContext(), name);
		}
		
		public static Semester GetByName(SampleDataContext context, string name)
		{
			return context.Semesters.FirstOrDefault(o => o.Name == name);
		}
		
		private void AttachCourses(Course entity)
		{
			this.OnPropertyChanging();
			entity.Semester = this;
		}

		private void DetachCourses(Course entity)
		{
			this.OnPropertyChanging();
			entity.Semester = null;
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Semester ToBaseDataObject()
	    {
	        return new DO.Semester()
	        {
					ID = this.ID, 
					Begin = this.Begin, 
					End = this.End, 
					Name = this.Name
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnBeginChanging(DateTime value);
		partial void OnBeginChanged();
		partial void OnEndChanging(DateTime value);
		partial void OnEndChanged();
		partial void OnNameChanging(string value);
		partial void OnNameChanged();
		
        public override string ToString()
        {
        	return this.Name;
        }
	}

	/// <summary>Maps to the Student table in the database.</summary>
	[TableAttribute(Name="dbo.Student")]
	public partial class Student : DO.Student, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntitySet<DA.Enrollment> _Enrollments;
		
		private EntityRef<DA.Major> _Major;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the MajorID column.</summary>
		[ColumnAttribute(Name="MajorID", Storage="_MajorID", DbType="int(10) NULL")]
		public new int MajorID
		{
			get { return this._MajorID; }
			set
			{
				if (!object.Equals(value, this._MajorID))
				{
					if (_Major.HasLoadedOrAssignedValue && (_Major.Entity == null || _Major.Entity.ID != value))
						throw new ForeignKeyReferenceAlreadyHasValueException();
						
					this.OnMajorIDChanging(value);
					this.OnPropertyChanging();
					this._MajorID = value;
					this.OnPropertyChanged("MajorID");
					this.OnMajorIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the SSN column.</summary>
		[ColumnAttribute(Name="SSN", Storage="_SSN", DbType="varchar(11) NULL")]
		public new string SSN
		{
			get { return this._SSN; }
			set
			{
				if (!object.Equals(value, this._SSN))
				{
					this.OnSSNChanging(value);
					this.OnPropertyChanging();
					this._SSN = value;
					this.OnPropertyChanged("SSN");
					this.OnSSNChanged();
				}
			}
		}
		
		/// <summary>Maps to the FirstName column.</summary>
		[ColumnAttribute(Name="FirstName", Storage="_FirstName", DbType="varchar(25) NULL")]
		public new string FirstName
		{
			get { return this._FirstName; }
			set
			{
				if (!object.Equals(value, this._FirstName))
				{
					this.OnFirstNameChanging(value);
					this.OnPropertyChanging();
					this._FirstName = value;
					this.OnPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the LastName column.</summary>
		[ColumnAttribute(Name="LastName", Storage="_LastName", DbType="varchar(25) NULL")]
		public new string LastName
		{
			get { return this._LastName; }
			set
			{
				if (!object.Equals(value, this._LastName))
				{
					this.OnLastNameChanging(value);
					this.OnPropertyChanging();
					this._LastName = value;
					this.OnPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the Active column.</summary>
		[ColumnAttribute(Name="Active", Storage="_Active", DbType="bit(1) NULL")]
		public new bool Active
		{
			get { return this._Active; }
			set
			{
				if (!object.Equals(value, this._Active))
				{
					this.OnActiveChanging(value);
					this.OnPropertyChanging();
					this._Active = value;
					this.OnPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Enrollment_Student foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Enrollment_Student", Storage="_Enrollments", ThisKey="ID", OtherKey="StudentID")]
		public EntitySet<DA.Enrollment> Enrollments
		{
			get { return _Enrollments; }
			set { _Enrollments.Assign(value); }
		}
		
		/// <summary>Maps to the FK_Student_Major foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Student_Major", Storage="_Major", ThisKey="MajorID", OtherKey="ID", IsForeignKey=true)]
		public DA.Major Major
		{
			
			get { return MajorCache.Instance.Find(this.MajorID); }
			set
			{
				Major previousValue = _Major.Entity;
				
				if (previousValue != value || !_Major.HasLoadedOrAssignedValue)
				{
					this.OnPropertyChanging();
					
					if (previousValue != null)
					{
						_Major.Entity = null;
						previousValue.Students.Remove(this);
					}
				}
				
				_Major.Entity = value;
				
				if (value != null)
				{
					value.Students.Add(this);
					this.MajorID = value.ID;
				}
				else
				{
					_Major = default(EntityRef<Major>);
					this.MajorID = default(int);
				}
				
				this.OnPropertyChanged("Major");
			}
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Student()
		{
			_Enrollments= new EntitySet<DA.Enrollment>(new Action<DA.Enrollment>(this.AttachEnrollments), new Action<DA.Enrollment>(this.DetachEnrollments));
			_Major = default(EntityRef<DA.Major>);
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll(SampleDataContext context)
		{
			return context.Students;
		}

		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static DA.Student GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static DA.Student GetByID(SampleDataContext context, int ID)
		{
			return context.Students.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(int iD)
		{
            return GetByMajorID(new SampleDataContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(SampleDataContext context, int iD)
		{
				var source = context.Students;
			return (from o in source where o.MajorID == iD select o);
		}
		
		/// <summary>Gets the Student matching the unique index using the passed-in values.</summary>
		public static DA.Student GetBySSN(string sSN)
		{
			return GetBySSN(new SampleDataContext(), sSN);
		}
		
		public static Student GetBySSN(SampleDataContext context, string sSN)
		{
			return context.Students.FirstOrDefault(o => o.SSN == sSN);
		}
		
		private void AttachEnrollments(Enrollment entity)
		{
			this.OnPropertyChanging();
			entity.Student = this;
		}

		private void DetachEnrollments(Enrollment entity)
		{
			this.OnPropertyChanging();
			entity.Student = null;
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Student ToBaseDataObject()
	    {
	        return new DO.Student()
	        {
					ID = this.ID, 
					MajorID = this.MajorID, 
					SSN = this.SSN, 
					FirstName = this.FirstName, 
					LastName = this.LastName, 
					Active = this.Active
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnMajorIDChanging(int value);
		partial void OnMajorIDChanged();
		partial void OnSSNChanging(string value);
		partial void OnSSNChanged();
		partial void OnFirstNameChanging(string value);
		partial void OnFirstNameChanged();
		partial void OnLastNameChanging(string value);
		partial void OnLastNameChanged();
		partial void OnActiveChanging(bool value);
		partial void OnActiveChanged();
		
        public override string ToString()
        {
        	return this.FullName;
        }
	}

	/// <summary>Maps to the Teacher table in the database.</summary>
	[TableAttribute(Name="dbo.Teacher")]
	public partial class Teacher : DO.Teacher, INotifyPropertyChanging, INotifyPropertyChanged
	{
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;

		/// <summary>This event is raised just before a property is changed.</summary>
		public event PropertyChangingEventHandler PropertyChanging;
		
		/// <summary>This event is raised when a property has changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		
		private EntitySet<DA.Course> _Courses;
		
		/// <summary>Maps to the ID column.</summary>
		[ColumnAttribute(Name="ID", Storage="_ID", DbType="int(10) NULL IDENTITY", AutoSync=AutoSync.OnInsert, IsPrimaryKey=true, IsDbGenerated=true)]
		public new int ID
		{
			get { return this._ID; }
			set
			{
				if (!object.Equals(value, this._ID))
				{
					this.OnIDChanging(value);
					this.OnPropertyChanging();
					this._ID = value;
					this.OnPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		/// <summary>Maps to the SSN column.</summary>
		[ColumnAttribute(Name="SSN", Storage="_SSN", DbType="varchar(11) NULL")]
		public new string SSN
		{
			get { return this._SSN; }
			set
			{
				if (!object.Equals(value, this._SSN))
				{
					this.OnSSNChanging(value);
					this.OnPropertyChanging();
					this._SSN = value;
					this.OnPropertyChanged("SSN");
					this.OnSSNChanged();
				}
			}
		}
		
		/// <summary>Maps to the FirstName column.</summary>
		[ColumnAttribute(Name="FirstName", Storage="_FirstName", DbType="varchar(25) NULL")]
		public new string FirstName
		{
			get { return this._FirstName; }
			set
			{
				if (!object.Equals(value, this._FirstName))
				{
					this.OnFirstNameChanging(value);
					this.OnPropertyChanging();
					this._FirstName = value;
					this.OnPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the LastName column.</summary>
		[ColumnAttribute(Name="LastName", Storage="_LastName", DbType="varchar(25) NULL")]
		public new string LastName
		{
			get { return this._LastName; }
			set
			{
				if (!object.Equals(value, this._LastName))
				{
					this.OnLastNameChanging(value);
					this.OnPropertyChanging();
					this._LastName = value;
					this.OnPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		/// <summary>Maps to the Active column.</summary>
		[ColumnAttribute(Name="Active", Storage="_Active", DbType="bit(1) NULL")]
		public new bool Active
		{
			get { return this._Active; }
			set
			{
				if (!object.Equals(value, this._Active))
				{
					this.OnActiveChanging(value);
					this.OnPropertyChanging();
					this._Active = value;
					this.OnPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		/// <summary>Maps to the FK_Course_Teacher foreign key in the database.</summary>
		[AssociationAttribute(Name="FK_Course_Teacher", Storage="_Courses", ThisKey="ID", OtherKey="TeacherID")]
		public EntitySet<DA.Course> Courses
		{
			get { return _Courses; }
			set { _Courses.Assign(value); }
		}
		
		/// <summary>Creates a new instance of the class.</summary>
		public Teacher()
		{
			_Courses= new EntitySet<DA.Course>(new Action<DA.Course>(this.AttachCourses), new Action<DA.Course>(this.DetachCourses));
		
			OnCreated();
		}
		
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll()
		{
			return GetAll(new SampleDataContext());
		}
			
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll(SampleDataContext context)
		{
			return context.Teachers;
		}

		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static DA.Teacher GetByID(int ID)
		{
			return GetByID(new SampleDataContext(), ID);
		}
		
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static DA.Teacher GetByID(SampleDataContext context, int ID)
		{
			return context.Teachers.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Teacher matching the unique index using the passed-in values.</summary>
		public static DA.Teacher GetBySSN(string sSN)
		{
			return GetBySSN(new SampleDataContext(), sSN);
		}
		
		public static Teacher GetBySSN(SampleDataContext context, string sSN)
		{
			return context.Teachers.FirstOrDefault(o => o.SSN == sSN);
		}
		
		private void AttachCourses(Course entity)
		{
			this.OnPropertyChanging();
			entity.Teacher = this;
		}

		private void DetachCourses(Course entity)
		{
			this.OnPropertyChanging();
			entity.Teacher = null;
		}
		
	    /// <summary>
	    ///     Creates a deep copy of this instance as its base DataObject. This is
	    ///     useful when the object needs to be passed across a boundary where
	    ///     the DataAccess layer should not - or cannot - be exposed.
	    /// </summary>
	    /// <returns>A deep copy of this instance as its base DataObject.</returns>
	    public DO.Teacher ToBaseDataObject()
	    {
	        return new DO.Teacher()
	        {
					ID = this.ID, 
					SSN = this.SSN, 
					FirstName = this.FirstName, 
					LastName = this.LastName, 
					Active = this.Active
	        };
	    }
        
		/// <summary>Raises the PropertyChanging event (as applicable).</summary>
		protected virtual void OnPropertyChanging()
		{
			if (this.PropertyChanging != null)
				this.PropertyChanging(this, emptyChangingEventArgs);
		}
		
		/// <summary>Raises the PropertyChanged event (as applicable).</summary>
		/// <param name="propertyName">The name of the property which changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
		
		partial void OnLoaded();
		partial void OnValidate(ChangeAction action);
		partial void OnCreated();
		partial void OnIDChanging(int value);
		partial void OnIDChanged();
		partial void OnSSNChanging(string value);
		partial void OnSSNChanged();
		partial void OnFirstNameChanging(string value);
		partial void OnFirstNameChanged();
		partial void OnLastNameChanging(string value);
		partial void OnLastNameChanged();
		partial void OnActiveChanging(bool value);
		partial void OnActiveChanged();
		
        public override string ToString()
        {
        	return this.FullName;
        }
	}
}