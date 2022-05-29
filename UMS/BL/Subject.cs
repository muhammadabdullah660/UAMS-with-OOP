using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class Subject
    {
        private string code;
        private string type;
        private int creditHours;
        private int subjectFee;

        public Subject (string code , string type , int creditHours , int subjectFee)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFee = subjectFee;
        }
        public string getCode ()
        {
            return code;
        }
        public string getType ()
        {
            return type;
        }
        public int getCreditHours ()
        {
            return creditHours;
        }
        public int getSubjectFee ()
        {
            return subjectFee;
        }
        public void setCode (string code)
        {
            this.code = code;
        }
        public void setType (string type)
        {
            this.type = type;
        }

        public void setSubjectFee (int subjectFee)
        {
            this.subjectFee = subjectFee;
        }
        public void setCreditHours (int creditHours)
        {
            this.creditHours = creditHours;
        }
    }
}
