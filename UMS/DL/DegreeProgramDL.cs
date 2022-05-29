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
        private static List<DegreeProgram> degreeProgList = new List<DegreeProgram>();
        public static List<DegreeProgram> getDegreeProgList ()
        {
            return degreeProgList;
        }
        public static void addDegreeIntoList (DegreeProgram d)
        {
            degreeProgList.Add(d);
        }
        public static DegreeProgram isDegreeExists (string degreeName)
        {
            foreach (DegreeProgram d in degreeProgList)
            {
                if (d.getDegreeTitle() == degreeName)
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
                if (item.getDegreeTitle() == degreeName)
                {
                    return item;
                }
            }
            return null;
        }

        public static void viewALLOfferedPrograms ()
        {
            Console.WriteLine("Available Programs:");
            foreach (DegreeProgram item in degreeProgList)
            {
                Console.WriteLine(item.getDegreeTitle());
            }
        }
        public static void storeIntoFile (string path , DegreeProgram d)
        {
            StreamWriter f = new StreamWriter(path , true);
            string subjectName = "";
            for (int i = 0 ; i < d.getSubjectsList().Count ; i++)
            {
                if (i != d.getSubjectsList().Count - 1)
                {
                    subjectName += d.getSubjectsList()[i].getType() + ";";
                }
                else
                {
                    subjectName += d.getSubjectsList()[i].getType();
                }
            }
            f.WriteLine(d.getDegreeTitle() + "," + d.getDegreeDuration() + "," + d.getSeats() + "," + subjectName);
            f.Flush();
            f.Close();
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
                    string degreeTitle = splittedRecord[0];
                    double degreeDuration = double.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordSub = splittedRecord[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeTitle , degreeDuration);
                    d.setSeats(seats);
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
