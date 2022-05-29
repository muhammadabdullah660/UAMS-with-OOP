using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UMS.BL;
using UMS.UI;
namespace UMS.DL
{
    class StudentDL
    {
        private static List<Student> studentList = new List<Student>();
        private static List<Student> sortedStudentList = new List<Student>();
        private static List<Student> registeredStudentsList = new List<Student>();
        public static List<Student> getStudentList ()
        {
            return studentList;
        }
        public static List<Student> getRegisteredStudentsList ()
        {
            return registeredStudentsList;
        }
        public static List<Student> getSortedStudentList ()
        {
            return sortedStudentList;
        }
        public static void sortStudentsByMerit ()
        {
            foreach (Student s in registeredStudentsList)
            {
                s.calculateMerit();
            }
            sortedStudentList = registeredStudentsList.OrderByDescending(o => o.getMerit()).ToList();
        }
        public static Student isStudentPresent (string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.getName() && s.isGotAdmission())
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
        public static bool loadFromFile (string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    int fscMarks = int.Parse(splittedRecord[2]);
                    int ecatMarks = int.Parse(splittedRecord[3]);
                    string[] splittedRecordPref = splittedRecord[4].Split(';');
                    Student s = new Student(name , age , fscMarks , ecatMarks);
                    for (int i = 0 ; i < splittedRecordPref.Length ; i++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordPref[i]);
                        if (d != null)
                        {
                            s.addPreference(d);

                        }

                    }
                    addStudentIntoList(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeIntoFile (string path , Student s)
        {
            StreamWriter f = new StreamWriter(path , true);
            string degreeName = "";
            for (int i = 0 ; i < s.getPreferences().Count ; i++)
            {
                if (i != s.getPreferences().Count - 1)
                {
                    degreeName += s.getPreferences()[i].getDegreeTitle() + ";";
                }
                else
                {
                    degreeName += s.getPreferences()[i].getDegreeTitle();
                }
            }
            /* string subName = "";
             for (int i = 0 ; i < s.getRegSubject().Count ; i++)
             {
                 if (i != s.getRegSubject().Count - 1)
                 {
                     subName += s.getRegSubject()[i].getCode() + ":";
                 }
                 else
                 {
                     subName += s.getRegSubject()[i].getCode();
                 }
             }*/
            f.WriteLine(s.getName() + "," + s.getAge() + "," + s.getFscMarks() + "," + s.getEcatMarks() + "," + degreeName);
            f.Flush();
            f.Close();
        }
        /* public static void storeIntoFileSub (string path , Student s)
         {
             StreamWriter f = new StreamWriter(path , true);
             string subName = "";
             for (int i = 0 ; i < s.getRegSubject().Count ; i++)
             {
                 if (i != s.getRegSubject().Count - 1)
                 {
                     subName += s.getRegSubject()[i].getCode() + ":";
                 }
                 else
                 {
                     subName += s.getRegSubject()[i].getCode();
                 }
             }
             f.WriteLine(s.getName() + "," + s.getAge() + "," + s.getFscMarks() + "," + s.getEcatMarks() + "," + s.isGotAdmission() + "," + degreeName + "," + subName);
             f.Flush();
             f.Close();
         }*/
    }
}
