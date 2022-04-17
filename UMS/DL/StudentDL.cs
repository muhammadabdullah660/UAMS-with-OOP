using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.UI;
namespace UMS.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        public static List<Student> sortedStudentList = new List<Student>();
        public static List<Student> registeredStudentsList = new List<Student>();
        public static void sortStudentsByMerit ()
        {
            foreach (Student s in registeredStudentsList)
            {
                s.calculateMerit();
            }
            sortedStudentList = registeredStudentsList.OrderByDescending(o => o.merit).ToList();
        }
        public static Student isStudentPresent (string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.name && s.isGotAdmission())
                {
                    return s;
                }
            }
            return null;
        }
        public static void addStudentIntoList (Student s)
        {
            studentList.Add(s);
        }
        public static void addIntoRegStuList (Student s)
        {
            registeredStudentsList.Add(s);
        }
    }
}
