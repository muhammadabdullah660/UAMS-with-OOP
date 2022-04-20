using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.UI;
using UMS.DL;

namespace UMS
{
    class Program
    {
        static void Main ()
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            int op = 0;
            DegreeProgram d = new DegreeProgram("CS" , 4);
            Subject sub = new Subject("101" , "OOP" , 3 , 3000);
            d.addSeatsAndMerit(20 , 90);
            d.addSubject(sub);
            SubjectDL.addSubjectIntoList(sub);
            DegreeProgramDL.addDegreeIntoList(d);

            while (op < 8)
            {
                clearScreen();
                op = mainMenu();
                if (op == 1)
                {
                    clearScreen();
                    if (DegreeProgramDL.degreeProgList.Count > 0)
                    {
                        Student s = StudentUI.takeInputStudent();
                        StudentDL.addStudentIntoList(s);
                        StudentDL.storeIntoFile(studentPath , s);

                    }

                }
                else if (op == 2)
                {
                    clearScreen();
                    DegreeProgramDL.addDegreeIntoList(DegreeProgramUI.takeInputDegreeProgram());
                }
                else if (op == 3)
                {
                    clearScreen();
                    StudentUI.showMerit();

                }
                else if (op == 4)
                {
                    clearScreen();
                    StudentUI.showRegStudents();

                }
                else if (op == 5)
                {
                    clearScreen();
                    StudentUI.showRegStudentsSpecificProg();

                }
                else if (op == 6)
                {
                    clearScreen();
                    StudentUI.registerSubject();

                }
                else if (op == 7)
                {
                    clearScreen();
                    StudentUI.showWithFee();

                }
            }

        }
        static int mainMenu ()
        {
            int op;
            Console.WriteLine("******************************");
            Console.WriteLine("             UAMS             ");
            Console.WriteLine("******************************");
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
        static void clearScreen ()
        {
            //Console.WriteLine(StudentDL.registeredStudentsList.Count);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }








    }
}
