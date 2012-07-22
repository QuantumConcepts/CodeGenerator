using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Logic
{
    public static partial class StudentLogic
    {
        static partial void PerformPreDeleteLogic(SampleObjectContext context, Student obj)
        {
            if (obj.Enrollments != null)
                foreach (DataAccess.Enrollment enrollment in obj.Enrollments)
                    EnrollmentLogic.DeleteEnrollment(context, enrollment.ID);
        }
    }
}
