using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;
using QuantumConcepts.CodeGenerator.Sample.Common;
using QuantumConcepts.CodeGenerator.Sample.DataAccess.Cache;

[assembly: EdmSchemaAttribute()]

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess
{
	/// <summary>Exposes all functionality to interact with the database.</summary>
	public partial class SampleObjectContext : ObjectContext
    {
        /// <summary>Initializes a new SampleObjectContext object using the connection string found in the application configuration file.</summary>
        public SampleObjectContext()
        	: base("name=Default", "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>Initialize a new SampleObjectContext object.</summary>
        public SampleObjectContext(string connectionString)
        	: base(connectionString, "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>Initialize a new SampleObjectContext object.</summary>
        public SampleObjectContext(EntityConnection connection)
        	: base(connection, "Default")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
        
        partial void OnContextCreated();
		
		private ObjectSet<Course> _Courses;
        
        public ObjectSet<Course> Courses
        {
            get
            {
                if (_Courses == null)
                    _Courses = base.CreateObjectSet<Course>("Courses");
				
                return _Courses;
            }
        }
		
		private ObjectSet<Enrollment> _Enrollments;
        
        public ObjectSet<Enrollment> Enrollments
        {
            get
            {
                if (_Enrollments == null)
                    _Enrollments = base.CreateObjectSet<Enrollment>("Enrollments");
				
                return _Enrollments;
            }
        }
		
		private ObjectSet<Major> _Majors;
        
        public ObjectSet<Major> Majors
        {
            get
            {
                if (_Majors == null)
                    _Majors = base.CreateObjectSet<Major>("Majors");
				
                return _Majors;
            }
        }
		
		private ObjectSet<Semester> _Semesters;
        
        public ObjectSet<Semester> Semesters
        {
            get
            {
                if (_Semesters == null)
                    _Semesters = base.CreateObjectSet<Semester>("Semesters");
				
                return _Semesters;
            }
        }
		
		private ObjectSet<Student> _Students;
        
        public ObjectSet<Student> Students
        {
            get
            {
                if (_Students == null)
                    _Students = base.CreateObjectSet<Student>("Students");
				
                return _Students;
            }
        }
		
		private ObjectSet<Teacher> _Teachers;
        
        public ObjectSet<Teacher> Teachers
        {
            get
            {
                if (_Teachers == null)
                    _Teachers = base.CreateObjectSet<Teacher>("Teachers");
				
                return _Teachers;
            }
        }
	}
		/// <summary>Maps to the Course table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Course")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Course : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected int _SemesterID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int SemesterID
        {
            get { return _SemesterID; }
            set
            {
                if (_SemesterID != value)
                {
                    OnSemesterIDChanging(value);
                    ReportPropertyChanging("SemesterID");
                    _SemesterID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("SemesterID");
                    OnSemesterIDChanged();
                }
            }
        }
        
        partial void OnSemesterIDChanging(int value);
        partial void OnSemesterIDChanged();
        
       	protected int _TeacherID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int TeacherID
        {
            get { return _TeacherID; }
            set
            {
                if (_TeacherID != value)
                {
                    OnTeacherIDChanging(value);
                    ReportPropertyChanging("TeacherID");
                    _TeacherID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TeacherID");
                    OnTeacherIDChanged();
                }
            }
        }
        
        partial void OnTeacherIDChanging(int value);
        partial void OnTeacherIDChanged();
        
       	protected string _Number;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string Number
        {
            get { return _Number; }
            set
            {
                if (_Number != value)
                {
                    OnNumberChanging(value);
                    ReportPropertyChanging("Number");
                    _Number = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Number");
                    OnNumberChanged();
                }
            }
        }
        
        partial void OnNumberChanging(string value);
        partial void OnNumberChanged();
        
       	protected string _Name;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        
       	protected CourseStatus _Status;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public CourseStatus Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    OnStatusChanging(value);
                    ReportPropertyChanging("Status");
                    _Status = value;
                    ReportPropertyChanged("Status");
                    OnStatusChanged();
                }
            }
        }
        
        partial void OnStatusChanging(CourseStatus value);
        partial void OnStatusChanged();

		/// <summary>Maps to the FK_Course_Semester foreign key in the database.</summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Course_Semester", "Semester")]
        public Semester Semester
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Semester>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Semester").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Semester>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Semester").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Semester> SemesterReference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Semester>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Semester"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Semester>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Semester", value);
            }
        }
				
		/// <summary>Maps to the FK_Course_Teacher foreign key in the database.</summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Course_Teacher", "Teacher")]
        public Teacher Teacher
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Teacher>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Teacher").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Teacher>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Teacher").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Teacher> TeacherReference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Teacher>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Teacher"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Teacher>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Teacher", value);
            }
        }
				
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Enrollment_Course", "Course")]
        public EntityCollection<Enrollment> Enrollments
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Enrollment>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Enrollment"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Enrollment>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Enrollment", value);
            }
        }
				
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Courses in the database.</summary>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetAll(SampleObjectContext context)
		{
			return context.Courses;
		}

		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static Course GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Course with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Course to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Course, or null if it does not exist.</returns>
		public static Course GetByID(SampleObjectContext context, int ID)
		{
			return context.Courses.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(int iD)
		{
            return GetBySemesterID(new SampleObjectContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetBySemesterID(SampleObjectContext context, int iD)
		{
				var source = context.Courses;
			return (from o in source where o.SemesterID == iD select o);
		}
		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(int iD)
		{
            return GetByTeacherID(new SampleObjectContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
		public static IEnumerable<Course> GetByTeacherID(SampleObjectContext context, int iD)
		{
				var source = context.Courses;
			return (from o in source where o.TeacherID == iD select o);
		}
		
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static Course GetBySemesterIDAndNumber(int semesterID, string number)
		{
			return GetBySemesterIDAndNumber(new SampleObjectContext(), semesterID, number);
		}
		
		public static Course GetBySemesterIDAndNumber(SampleObjectContext context, int semesterID, string number)
		{
			return context.Courses.FirstOrDefault(o => o.SemesterID == semesterID && o.Number == number);
		}
		
		/// <summary>Gets the Course matching the unique index using the passed-in values.</summary>
		public static Course GetBySemesterIDAndName(int semesterID, string name)
		{
			return GetBySemesterIDAndName(new SampleObjectContext(), semesterID, name);
		}
		
		public static Course GetBySemesterIDAndName(SampleObjectContext context, int semesterID, string name)
		{
			return context.Courses.FirstOrDefault(o => o.SemesterID == semesterID && o.Name == name);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
		/// <summary>Maps to the Enrollment table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Enrollment")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Enrollment : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected int _StudentID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int StudentID
        {
            get { return _StudentID; }
            set
            {
                if (_StudentID != value)
                {
                    OnStudentIDChanging(value);
                    ReportPropertyChanging("StudentID");
                    _StudentID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("StudentID");
                    OnStudentIDChanged();
                }
            }
        }
        
        partial void OnStudentIDChanging(int value);
        partial void OnStudentIDChanged();
        
       	protected int _CourseID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int CourseID
        {
            get { return _CourseID; }
            set
            {
                if (_CourseID != value)
                {
                    OnCourseIDChanging(value);
                    ReportPropertyChanging("CourseID");
                    _CourseID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CourseID");
                    OnCourseIDChanged();
                }
            }
        }
        
        partial void OnCourseIDChanging(int value);
        partial void OnCourseIDChanged();

		/// <summary>Maps to the FK_Enrollment_Student foreign key in the database.</summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Enrollment_Student", "Student")]
        public Student Student
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Student").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Student").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Student> StudentReference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Student"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Student", value);
            }
        }
				
		/// <summary>Maps to the FK_Enrollment_Course foreign key in the database.</summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Enrollment_Course", "Course")]
        public Course Course
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Course").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Course").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Course> CourseReference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Course"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Course", "Course", value);
            }
        }
				
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Enrollments in the database.</summary>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetAll(SampleObjectContext context)
		{
			return context.Enrollments;
		}

		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static Enrollment GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Enrollment with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Enrollment to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Enrollment, or null if it does not exist.</returns>
		public static Enrollment GetByID(SampleObjectContext context, int ID)
		{
			return context.Enrollments.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(int iD)
		{
            return GetByStudentID(new SampleObjectContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByStudentID(SampleObjectContext context, int iD)
		{
				var source = context.Enrollments;
			return (from o in source where o.StudentID == iD select o);
		}
		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(int iD)
		{
            return GetByCourseID(new SampleObjectContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Course table via the ID column.</summary>
		/// <param name="courseID">The ID of the Course for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
		public static IEnumerable<Enrollment> GetByCourseID(SampleObjectContext context, int iD)
		{
				var source = context.Enrollments;
			return (from o in source where o.CourseID == iD select o);
		}
		
		/// <summary>Gets the Enrollment matching the unique index using the passed-in values.</summary>
		public static Enrollment GetByStudentIDAndCourseID(int studentID, int courseID)
		{
			return GetByStudentIDAndCourseID(new SampleObjectContext(), studentID, courseID);
		}
		
		public static Enrollment GetByStudentIDAndCourseID(SampleObjectContext context, int studentID, int courseID)
		{
			return context.Enrollments.FirstOrDefault(o => o.StudentID == studentID && o.CourseID == courseID);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
		/// <summary>Maps to the Major table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Major")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Major : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected string _Name;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        
        partial void OnNameChanging(string value);
        partial void OnNameChanged();

		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Student_Major", "Major")]
        public EntityCollection<Student> Students
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Student"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Student>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Student", value);
            }
        }
				
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Majors in the database.</summary>
		/// <returns>An IEnumerable of Majors.</returns>
		public static IEnumerable<Major> GetAll(SampleObjectContext context)
		{
			return context.Majors;
		}

		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static Major GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Major with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Major to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Major, or null if it does not exist.</returns>
		public static Major GetByID(SampleObjectContext context, int ID)
		{
			return context.Majors.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Major matching the unique index using the passed-in values.</summary>
		public static Major GetByName(string name)
		{
			return GetByName(new SampleObjectContext(), name);
		}
		
		public static Major GetByName(SampleObjectContext context, string name)
		{
			return context.Majors.FirstOrDefault(o => o.Name == name);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
		/// <summary>Maps to the Semester table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Semester")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Semester : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected DateTime _Begin;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public DateTime Begin
        {
            get { return _Begin; }
            set
            {
                if (_Begin != value)
                {
                    OnBeginChanging(value);
                    ReportPropertyChanging("Begin");
                    _Begin = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Begin");
                    OnBeginChanged();
                }
            }
        }
        
        partial void OnBeginChanging(DateTime value);
        partial void OnBeginChanged();
        
       	protected DateTime _End;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public DateTime End
        {
            get { return _End; }
            set
            {
                if (_End != value)
                {
                    OnEndChanging(value);
                    ReportPropertyChanging("End");
                    _End = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("End");
                    OnEndChanged();
                }
            }
        }
        
        partial void OnEndChanging(DateTime value);
        partial void OnEndChanged();
        
       	protected string _Name;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        
        partial void OnNameChanging(string value);
        partial void OnNameChanged();

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Semester table via the ID column.</summary>
		/// <param name="semesterID">The ID of the Semester for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Course_Semester", "Semester")]
        public EntityCollection<Course> Courses
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Course"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Semester", "Course", value);
            }
        }
				
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Semesters in the database.</summary>
		/// <returns>An IEnumerable of Semesters.</returns>
		public static IEnumerable<Semester> GetAll(SampleObjectContext context)
		{
			return context.Semesters;
		}

		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static Semester GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Semester with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Semester to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Semester, or null if it does not exist.</returns>
		public static Semester GetByID(SampleObjectContext context, int ID)
		{
			return context.Semesters.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static Semester GetByBeginAndEnd(DateTime begin, DateTime end)
		{
			return GetByBeginAndEnd(new SampleObjectContext(), begin, end);
		}
		
		public static Semester GetByBeginAndEnd(SampleObjectContext context, DateTime begin, DateTime end)
		{
			return context.Semesters.FirstOrDefault(o => o.Begin == begin && o.End == end);
		}
		
		/// <summary>Gets the Semester matching the unique index using the passed-in values.</summary>
		public static Semester GetByName(string name)
		{
			return GetByName(new SampleObjectContext(), name);
		}
		
		public static Semester GetByName(SampleObjectContext context, string name)
		{
			return context.Semesters.FirstOrDefault(o => o.Name == name);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
		/// <summary>Maps to the Student table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Student")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Student : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected int _MajorID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MajorID
        {
            get { return _MajorID; }
            set
            {
                if (_MajorID != value)
                {
                    OnMajorIDChanging(value);
                    ReportPropertyChanging("MajorID");
                    _MajorID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("MajorID");
                    OnMajorIDChanged();
                }
            }
        }
        
        partial void OnMajorIDChanging(int value);
        partial void OnMajorIDChanged();
        
       	protected string _SSN;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SSN
        {
            get { return _SSN; }
            set
            {
                if (_SSN != value)
                {
                    OnSSNChanging(value);
                    ReportPropertyChanging("SSN");
                    _SSN = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("SSN");
                    OnSSNChanged();
                }
            }
        }
        
        partial void OnSSNChanging(string value);
        partial void OnSSNChanged();
        
       	protected string _FirstName;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    OnFirstNameChanging(value);
                    ReportPropertyChanging("FirstName");
                    _FirstName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("FirstName");
                    OnFirstNameChanged();
                }
            }
        }
        
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        
       	protected string _LastName;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    OnLastNameChanging(value);
                    ReportPropertyChanging("LastName");
                    _LastName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("LastName");
                    OnLastNameChanged();
                }
            }
        }
        
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        
       	protected bool _Active;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public bool Active
        {
            get { return _Active; }
            set
            {
                if (_Active != value)
                {
                    OnActiveChanging(value);
                    ReportPropertyChanging("Active");
                    _Active = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Active");
                    OnActiveChanged();
                }
            }
        }
        
        partial void OnActiveChanging(bool value);
        partial void OnActiveChanged();

		/// <summary>Maps to the FK_Student_Major foreign key in the database.</summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Student_Major", "Major")]
        public Major Major
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Major>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Major").Value; }
            set { ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Major>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Major").Value = value; }
        }
        
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Major> MajorReference
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Major>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Major"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Major>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Student_Major", "Major", value);
            }
        }
				
		/// <summary>Gets a list of all of the Enrollments in the database which are associated with the Student table via the ID column.</summary>
		/// <param name="studentID">The ID of the Student for which to retrieve the child Enrollments.</param>
		/// <returns>An IEnumerable of Enrollments.</returns>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Enrollment_Student", "Student")]
        public EntityCollection<Enrollment> Enrollments
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Enrollment>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Enrollment"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Enrollment>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Enrollment_Student", "Enrollment", value);
            }
        }
				
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Students in the database.</summary>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetAll(SampleObjectContext context)
		{
			return context.Students;
		}

		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static Student GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Student with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Student to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Student, or null if it does not exist.</returns>
		public static Student GetByID(SampleObjectContext context, int ID)
		{
			return context.Students.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(int iD)
		{
            return GetByMajorID(new SampleObjectContext(), iD);
		}

		
		/// <summary>Gets a list of all of the Students in the database which are associated with the Major table via the ID column.</summary>
		/// <param name="majorID">The ID of the Major for which to retrieve the child Students.</param>
		/// <returns>An IEnumerable of Students.</returns>
		public static IEnumerable<Student> GetByMajorID(SampleObjectContext context, int iD)
		{
				var source = context.Students;
			return (from o in source where o.MajorID == iD select o);
		}
		
		/// <summary>Gets the Student matching the unique index using the passed-in values.</summary>
		public static Student GetBySSN(string sSN)
		{
			return GetBySSN(new SampleObjectContext(), sSN);
		}
		
		public static Student GetBySSN(SampleObjectContext context, string sSN)
		{
			return context.Students.FirstOrDefault(o => o.SSN == sSN);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
		/// <summary>Maps to the Teacher table in the database.</summary>
    [EdmEntityTypeAttribute(NamespaceName="QuantumConcepts.CodeGenerator.Sample.DataAccess", Name="Teacher")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Teacher : EntityObject
	{
		
        /// <summary>This event indicates that the current cache is invalid or stale and should be refreshed.</summary>
        public static event ParameterlessDelegate CacheNeedsRefresh;
        
       	protected int _ID;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        
       	protected string _SSN;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SSN
        {
            get { return _SSN; }
            set
            {
                if (_SSN != value)
                {
                    OnSSNChanging(value);
                    ReportPropertyChanging("SSN");
                    _SSN = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("SSN");
                    OnSSNChanged();
                }
            }
        }
        
        partial void OnSSNChanging(string value);
        partial void OnSSNChanged();
        
       	protected string _FirstName;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    OnFirstNameChanging(value);
                    ReportPropertyChanging("FirstName");
                    _FirstName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("FirstName");
                    OnFirstNameChanged();
                }
            }
        }
        
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        
       	protected string _LastName;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    OnLastNameChanging(value);
                    ReportPropertyChanging("LastName");
                    _LastName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("LastName");
                    OnLastNameChanged();
                }
            }
        }
        
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        
       	protected bool _Active;
			
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public bool Active
        {
            get { return _Active; }
            set
            {
                if (_Active != value)
                {
                    OnActiveChanging(value);
                    ReportPropertyChanging("Active");
                    _Active = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Active");
                    OnActiveChanged();
                }
            }
        }
        
        partial void OnActiveChanging(bool value);
        partial void OnActiveChanged();

		/// <summary>Gets a list of all of the Courses in the database which are associated with the Teacher table via the ID column.</summary>
		/// <param name="teacherID">The ID of the Teacher for which to retrieve the child Courses.</param>
		/// <returns>An IEnumerable of Courses.</returns>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("QuantumConcepts.CodeGenerator.Sample.DataAccess", "FK_Course_Teacher", "Teacher")]
        public EntityCollection<Course> Courses
        {
            get { return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Course"); }
            set
            {
                if (value != null)
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Course>("QuantumConcepts.CodeGenerator.Sample.DataAccess.FK_Course_Teacher", "Course", value);
            }
        }
				
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll()
		{
			return GetAll(new SampleObjectContext());
		}
			
		/// <summary>Gets a list of all of the Teachers in the database.</summary>
		/// <returns>An IEnumerable of Teachers.</returns>
		public static IEnumerable<Teacher> GetAll(SampleObjectContext context)
		{
			return context.Teachers;
		}

		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static Teacher GetByID(int ID)
		{
			return GetByID(new SampleObjectContext(), ID);
		}
		
		/// <summary>Returns the Teacher with the provided primary key value.</summary>
		/// <param name="id">The primary key of the Teacher to fetch.</param>
		/// <param name="context">The data context to use.</param>
		/// <returns>A single Teacher, or null if it does not exist.</returns>
		public static Teacher GetByID(SampleObjectContext context, int ID)
		{
			return context.Teachers.SingleOrDefault(o => o.ID == ID);
		}
			
		/// <summary>Gets the Teacher matching the unique index using the passed-in values.</summary>
		public static Teacher GetBySSN(string sSN)
		{
			return GetBySSN(new SampleObjectContext(), sSN);
		}
		
		public static Teacher GetBySSN(SampleObjectContext context, string sSN)
		{
			return context.Teachers.FirstOrDefault(o => o.SSN == sSN);
		}
		
		
		/// <summary>This should be called whenever some action takes place that may render the cache of this object invalid or stale.</summary>
		public static void OnCacheNeedsRefresh()
		{
			if (CacheNeedsRefresh != null)
				CacheNeedsRefresh();
		}
	}
}