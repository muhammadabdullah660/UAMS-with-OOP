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
        public RegisteredStudent (Student s , DegreeProgram d)
        {
            this.s = s;
            this.d = d;
        }
    }
}
