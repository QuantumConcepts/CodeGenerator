using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Sample.Logic
{
    public static partial class MajorLogic
    {
        static partial void PerformPreDeleteLogic(DataAccess.SampleObjectContext context, DataAccess.Major obj)
        {
            if (obj.Students != null)
                foreach (DataAccess.Student student in obj.Students)
                    StudentLogic.DeleteStudent(context, student.ID);
        }
    }
}
