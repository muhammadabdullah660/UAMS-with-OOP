using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.UI;
using System.IO;
namespace UMS.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgram> degreeProgList = new List<DegreeProgram>();

        public static void addDegreeIntoList (DegreeProgram d)
        {
            degreeProgList.Add(d);
        }
        public static DegreeProgram isDegreeExists (string degreeName)
        {
            foreach (DegreeProgram d in degreeProgList)
            {
                if (d.degreeTitle == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
        public static DegreeProgram addPrefOfStudent (Student s , string degreeName)
        {
            foreach (DegreeProgram item in degreeProgList)
            {
                if (item.degreeTitle == degreeName)
                {
                    return item;
                }
            }
            return null;
        }
        public static bool isSubjectRegistered (Student stu , string code , DegreeProgram regDegree)
        {
            foreach (Subject s in stu.regDegree.subjectsList)
            {
                if (s.code == code && !(stu.regSubject.Contains(s)))
                {
                    stu.regStudentSubject(s);
                    return true;
                }
            }
            return false;
        }
        public static void viewALLOfferedPrograms ()
        {
            Console.WriteLine("Available Programs:");
            foreach (DegreeProgram item in degreeProgList)
            {
                Console.WriteLine(item.degreeTitle);
            }
        }
        public static void storeIntoFile (string path , DegreeProgram d)
        {
            StreamWriter f = new StreamWriter(path , true);
            string subjectName = "";
            for (int i = 0 ; i < d.subjectsList.Count ; i++)
            {
                if (i != d.subjectsList.Count - 1)
                {
                    subjectName += d.subjectsList[i].type + ";";
                }
                else
                {
                    subjectName += d.subjectsList[i].type;
                }
            }
            f.WriteLine(d.degreeTitle + "," + d.degreeDuration + "," + d.seats + "," + subjectName);
            f.Flush();
            f.Close();
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
                    string degreeTitle = splittedRecord[0];
                    double degreeDuration = double.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordSub = record.Split(';');
                    DegreeProgram d = new DegreeProgram(degreeTitle , degreeDuration);
                    d.seats = seats;
                    for (int i = 0 ; i < splittedRecordSub.Length ; i++)
                    {
                        Subject s = SubjectDL.isSubjectExists(splittedRecordSub[i]);
                        if (s != null)
                        {
                            d.addSubject(s);
                        }
                    }
                    addDegreeIntoList(d);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
