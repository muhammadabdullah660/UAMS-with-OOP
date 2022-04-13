using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class RegisteredStudent
    {
        public Student s;
        public DegreeProgram d;
        public static List<RegisteredStudent> registeredStudentsList = new List<RegisteredStudent>();

        public RegisteredStudent (Student s , DegreeProgram d)
        {
            this.s = s;
            this.d = d;
        }

        public static void addIntoList (RegisteredStudent s)
        {
            registeredStudentsList.Add(s);
        }
    }
}
