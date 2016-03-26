using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Logic
{
    public partial class CourseLogic
    {
        static partial void PerformPreDeleteLogic(SampleDataContext context, Course obj)
        {
            if (obj.Enrollments != null)
                foreach (DataAccess.Enrollment enrollment in obj.Enrollments)
                    EnrollmentLogic.DeleteEnrollment(context, enrollment.ID);
        }

        public static List<Course> FindCourseAPI(SampleDataContext context, string keyword)
        {
            return (from c in context.Courses
                    where
                        c.Name.Contains(keyword)
                        || c.Teacher.FirstName.Contains(keyword)
                        || c.Teacher.LastName.Contains(keyword)
                    select c).ToList();
        }
    }
}
