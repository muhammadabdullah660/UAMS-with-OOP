using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;
namespace UMS.UI
{
    class SubjectUI
    {
        public static void subjectsInfo (DegreeProgram d)
        {
            Console.WriteLine("Enter Subject Code:");
            string code = (Console.ReadLine());
            Console.WriteLine("Enter Subject Type:");
            string type = (Console.ReadLine());
            Console.WriteLine("Enter Credit Hours:");
            int ch = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fee:");
            int fee = int.Parse(Console.ReadLine());
            Subject s = new Subject(code , type , ch , fee);
            d.addSubject(s);
            SubjectDL.addSubjectIntoList(s);
        }
    }
}
