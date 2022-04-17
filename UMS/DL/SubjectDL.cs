using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
namespace UMS.DL
{
    class SubjectDL
    {
        public static List<Subject> subjectsList = new List<Subject>();
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
