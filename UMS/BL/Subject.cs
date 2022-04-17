using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFee;

        public Subject (string code , string type , int creditHours , int subjectFee)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFee = subjectFee;
        }


    }
}
