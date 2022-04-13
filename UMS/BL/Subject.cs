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
        public static List<Subject> subjectsList = new List<Subject>();

        public Subject (string code , string type , int creditHours , int subjectFee)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFee = subjectFee;
        }
        public static void addSubjectIntoList (Subject s)
        {
            subjectsList.Add(s);
        }
        public static bool isSubjectRegistered (Student stu , string code)
        {
            foreach (Subject s in subjectsList)
            {
                if (s.code == code && !(stu.regSubject.Contains(s)))
                {
                    stu.regStudentSubject(s);
                    return true;
                }
            }
            return false;
        }

    }
}
