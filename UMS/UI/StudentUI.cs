using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;
namespace UMS.UI
{
    class StudentUI
    {
        public static Student takeInputStudent ()
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
            DegreeProgramDL.viewALLOfferedPrograms();
            addPref(s);
            return s;
        }
        public static void addPref (Student s)
        {
            Console.WriteLine("Enter How Many Preference to Enter:");
            int prefCount = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < prefCount ; i++)
            {
                Console.WriteLine("Enter Degree Name:");
                string degreeName = (Console.ReadLine());
                DegreeProgram d = DegreeProgramDL.addPrefOfStudent(s , degreeName);
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
        public static void showMerit ()
        {

            foreach (Student item in StudentDL.getStudentList())
            {
                if (item.isGotAdmission())
                {
                    if (!(StudentDL.getRegisteredStudentsList().Contains(item)))
                    {
                        StudentDL.addIntoRegStuList(item);
                    }
                    Console.WriteLine($"{item.getName()} GOT ADMISSION IN {item.getadmPref().getDegreeTitle()}");
                }
                else
                {
                    Console.WriteLine($"{item.getName()} DID NOT GOT ADMISSION IN {item.getadmPref().getDegreeTitle()}");

                }
            }
        }
        public static void showRegStudents ()
        {
            /*foreach (Student item in Student.studentList)
            {
                Console.WriteLine($"{item.getName()} ");
            }*/
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (Student s in StudentDL.getRegisteredStudentsList())
            {
                Console.WriteLine($"{s.getName()}\t{s.getFscMarks()}\t{s.getEcatMarks()}\t{s.getAge()}");
            }
        }
        public static void showRegStudentsSpecificProg ()
        {
            Console.WriteLine("Enter Degree Name");
            string degreeName = Console.ReadLine();
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (Student s in StudentDL.getRegisteredStudentsList())
            {
                if (degreeName == s.getRegDegree().getDegreeTitle())
                {
                    Console.WriteLine($"{s.getName()}\t{s.getFscMarks()}\t{s.getEcatMarks()}\t{s.getAge()}");
                }

            }
        }
        public static void registerSubject ()
        {
            Console.WriteLine("Enter Your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter How Many Subjects You want To Register");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0 ; i < count ; i++)
            {
                Console.WriteLine("Enter Subject Code");
                string code = Console.ReadLine();
                Student stu = StudentDL.isStudentPresent(name);
                if (stu != null)
                {
                    DegreeProgram regDegree = stu.getRegDegree();
                    bool registered = DegreeProgram.isSubjectRegistered(stu , code , regDegree);
                    if (registered)
                    {
                        Console.WriteLine("Subject Registered");
                    }
                    else
                    {
                        Console.WriteLine("A student cannot have more than 9 subjects or wrong code");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine("Enter Valid name");
                    break;
                    i--;
                }

            }

        }
        public static void showWithFee ()
        {
            int fee;
            Console.WriteLine("NAME\tFSC\tECAT\tAGE\tTotal Fee");
            foreach (Student s in StudentDL.getRegisteredStudentsList())
            {
                fee = s.calculateFee();
                Console.WriteLine($"{s.getName()}\t{s.getFscMarks()}\t{s.getEcatMarks()}\t{s.getAge()}\t{fee}");

            }
        }
    }
}
