using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;

namespace UMS
{
    class Program
    {
        static void Main ()
        {
            int op = 0;
            while (op < 8)
            {
                clearScreen();
                op = mainMenu();
                if (op == 1)
                {
                    clearScreen();

                    Student.addStudentIntoList(takInputStudent());

                }
                else if (op == 2)
                {
                    clearScreen();
                    DegreeProgram.addDegreeIntoList(takInputDegreeProgram());
                }
                else if (op == 3)
                {
                    clearScreen();
                    showMerit();

                }
                else if (op == 4)
                {
                    clearScreen();
                    showRegStudents();

                }
                else if (op == 5)
                {
                    clearScreen();
                    showRegStudentsSpecificProg();

                }
                else if (op == 6)
                {
                    clearScreen();
                    registerSubject();

                }
                else if (op == 7)
                {
                    clearScreen();
                    showWithFee();

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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static Student takInputStudent ()
        {
            string name;
            int age;
            int fscMarks;
            int matricMarks;
            int ecatMarks;
            Console.WriteLine("Enter Student Name:");
            name = (Console.ReadLine());
            Console.WriteLine("Enter Student Age:");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter FSC Marks:");
            fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Matric Marks:");
            matricMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ECAT Marks:");
            ecatMarks = int.Parse(Console.ReadLine());
            Student s = new Student(name , age , fscMarks , matricMarks , ecatMarks);
            // Show all programs
            Console.WriteLine("Available Programs:");
            foreach (DegreeProgram item in DegreeProgram.degreeProgList)
            {
                Console.WriteLine(item.degreeTitle);
            }

            addPref(s);
            return s;


        }
        static void addPref (Student s)
        {
            Console.WriteLine("Enter How Many Preference to Enter:");
            int prefCount = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < prefCount ; i++)
            {
                Console.WriteLine("Enter Degree Name:");
                string degreeName = (Console.ReadLine());
                DegreeProgram d = DegreeProgram.addPrefOfStudent(s , degreeName);
                if (d != null)
                {
                    s.addPreference(d);
                    Console.WriteLine("Preference added");
                }
                else
                {
                    Console.WriteLine("Wrong Entry");
                    i--;
                }

            }
        }
        static DegreeProgram takInputDegreeProgram ()
        {
            string degreeTitle;
            double degreeDuration, degreeMerit;
            int degreeSeats, subCount;
            Console.WriteLine("Enter Degree Name:");
            degreeTitle = (Console.ReadLine());
            Console.WriteLine("Enter Degree Duration:");
            degreeDuration = double.Parse(Console.ReadLine());
            // Object
            DegreeProgram d = new DegreeProgram(degreeTitle , degreeDuration);
            // Behaviors
            Console.WriteLine("Enter Seats for degree:");
            degreeSeats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Merit for degree:");
            degreeMerit = double.Parse(Console.ReadLine());
            d.addSeatsAndMerit(degreeSeats , degreeMerit);
            // Subjects
            Console.WriteLine("Enter How many subjects to enter:");
            subCount = int.Parse(Console.ReadLine());
            // Subjects List
            for (int i = 0 ; i < subCount ; i++)
            {
                subjectsInfo(d);
            }
            return d;
        }
        static void subjectsInfo (DegreeProgram d)
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
            Subject.addSubjectIntoList(s);
        }

        static void showMerit ()
        {

            foreach (Student item in Student.studentList)
            {
                if (item.isGotAdmission())
                {
                    RegisteredStudent r = new RegisteredStudent(item , item.admPref);
                    RegisteredStudent.addIntoList(r);
                    Console.WriteLine($"{item.name} GOT ADMISSION IN {item.admPref.degreeTitle}");
                }
                else
                {
                    Console.WriteLine($"{item.name} DID NOT GOT ADMISSION IN {item.admPref.degreeTitle}");

                }
            }
        }
        static void showRegStudents ()
        {
            /*foreach (Student item in Student.studentList)
            {
                Console.WriteLine($"{item.name} ");
            }*/
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (RegisteredStudent item in RegisteredStudent.registeredStudentsList)
            {
                Console.WriteLine($"{item.s.name}\t{item.s.fscMarks}\t{item.s.ecatMarks}\t{item.s.age}");

            }
        }
        static void showRegStudentsSpecificProg ()
        {
            Console.WriteLine("Enter Degree Name");
            string degreeName = Console.ReadLine();
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (RegisteredStudent item in RegisteredStudent.registeredStudentsList)
            {
                if (degreeName == item.d.degreeTitle)
                {
                    Console.WriteLine($"{item.s.name}\t{item.s.fscMarks}\t{item.s.ecatMarks}\t{item.s.age}");
                }

            }
        }
        static void registerSubject ()
        {
            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter How Many Subjects You want To Register");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < count ; i++)
            {
                Console.WriteLine("Enter Subject Code");
                string code = Console.ReadLine();
                Student stu = Student.isStudentPresent(name);
                bool registered = Subject.isSubjectRegistered(stu , code);
                if (registered)
                {
                    Console.WriteLine("Subject Registered");
                }
                else
                {
                    Console.WriteLine("Enter Valid Code");
                    i--;
                }

            }
        }
        static void showWithFee ()
        {
            int fee;
            Console.WriteLine("NAME\tFSC\tECAT\tAGE\tTotal Fee");
            foreach (RegisteredStudent item in RegisteredStudent.registeredStudentsList)
            {
                fee = item.s.calculateFee();
                Console.WriteLine($"{item.s.name}\t{item.s.fscMarks}\t{item.s.ecatMarks}\t{item.s.age}\t{fee}");

            }
        }
    }
}
