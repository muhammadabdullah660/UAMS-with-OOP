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
        public static bool loadIntoFile (string path)
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
                    string[] splittedRecordPref = record.Split(';');
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
            for (int i = 0 ; i < s.preferences.Count ; i++)
            {
                if (i != s.preferences.Count - 1)
                {
                    degreeName += s.preferences[i].degreeTitle + ";";
                }
                else
                {
                    degreeName += s.preferences[i].degreeTitle;
                }
            }
            f.WriteLine(s.name + "," + s.age + "," + s.fscMarks + "," + s.ecatMarks + "," + degreeName);
            f.Flush();
            f.Close();
        }
    }
}
