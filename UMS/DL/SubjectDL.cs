using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using System.IO;
namespace UMS.DL
{
    class SubjectDL
    {
        private static List<Subject> subjectsList = new List<Subject>();
        public static List<Subject> getSubjectsList ()
        {
            return subjectsList;
        }
        public static void addSubjectIntoList (Subject s)
        {
            subjectsList.Add(s);
        }
        public static Subject isSubjectExists (string type)
        {
            foreach (Subject s in subjectsList)
            {
                if (s.getType() == type)
                {
                    return s;
                }
            }
            return null;
        }
        public static void storeIntoFile (string path , Subject s)
        {
            StreamWriter f = new StreamWriter(path , true);
            f.WriteLine(s.getCode() + "," + s.getType() + "," + s.getCreditHours() + "," + s.getSubjectFee());
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
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFee = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code , type , creditHours , subjectFee);
                    addSubjectIntoList(s);
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
