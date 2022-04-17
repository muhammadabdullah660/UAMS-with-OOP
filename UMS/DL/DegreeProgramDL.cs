using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.UI;
namespace UMS.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgram> degreeProgList = new List<DegreeProgram>();

        public static void addDegreeIntoList (DegreeProgram d)
        {
            degreeProgList.Add(d);
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
        public static void viewALLOfferedPrograms ()
        {
            Console.WriteLine("Available Programs:");
            foreach (DegreeProgram item in DegreeProgramDL.degreeProgList)
            {
                Console.WriteLine(item.degreeTitle);
            }
        }
    }
}
