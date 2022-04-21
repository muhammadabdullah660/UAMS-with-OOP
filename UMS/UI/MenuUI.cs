using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.UI
{
    class MenuUI
    {
        public static int mainMenu ()
        {
            int op;
            header();
            Console.WriteLine("1- Add Student");
            Console.WriteLine("2- Add Degree Program");
            Console.WriteLine("3- Generate Merit");
            Console.WriteLine("4- View Registered Students");
            Console.WriteLine("5- View Students of a Specific Program");
            Console.WriteLine("6- Register Subjects for a Specific Student");
            Console.WriteLine("7- Calculate fee for all Registered Students");
            Console.WriteLine("8- Exit");
            op = int.Parse(Console.ReadLine());
            return op;

        }
        public static void header ()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("             UAMS             ");
            Console.WriteLine("******************************");
        }
        public static void clearScreen ()
        {
            //Console.WriteLine(StudentDL.registeredStudentsList.Count);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
