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
            if (SubjectDL.loadFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data Loaded Successfully");
            }
            if (DegreeProgramDL.loadFromFile(degreePath))
            {
                Console.WriteLine("DegreeProgram Data Loaded Successfully");
            }
            if (StudentDL.loadFromFile(studentPath))
            {
                Console.WriteLine("Student Data Loaded Successfully");
            }
            //     DegreeProgramDL.viewALLOfferedPrograms();
            int op = 0;
            /*DegreeProgram d = new DegreeProgram("CS" , 4);
            Subject sub = new Subject("101" , "OOP" , 3 , 3000);
            d.addSeatsAndMerit(20 , 90);
            d.addSubject(sub);
            SubjectDL.addSubjectIntoList(sub);
            DegreeProgramDL.addDegreeIntoList(d);
            DegreeProgramDL.storeIntoFile(degreePath , d);*/


            while (op < 8)
            {
                MenuUI.clearScreen();
                op = MenuUI.mainMenu();
                if (op == 1)
                {
                    MenuUI.clearScreen();
                    if (DegreeProgramDL.degreeProgList.Count > 0)
                    {
                        MenuUI.header();
                        Student s = StudentUI.takeInputStudent();
                        StudentDL.addStudentIntoList(s);
                        StudentDL.storeIntoFile(studentPath , s);

                    }

                }
                else if (op == 2)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    DegreeProgram deg = DegreeProgramUI.takeInputDegreeProgram();
                    DegreeProgramDL.addDegreeIntoList(deg);
                    DegreeProgramDL.storeIntoFile(degreePath , deg);

                }
                else if (op == 3)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    StudentUI.showMerit();

                }
                else if (op == 4)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    StudentUI.showRegStudents();

                }
                else if (op == 5)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    StudentUI.showRegStudentsSpecificProg();

                }
                else if (op == 6)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    StudentUI.registerSubject();

                }
                else if (op == 7)
                {
                    MenuUI.clearScreen();
                    MenuUI.header();
                    StudentUI.showWithFee();

                }
            }
        }
    }
}
