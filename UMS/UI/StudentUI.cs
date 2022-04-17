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

            foreach (Student item in StudentDL.studentList)
            {
                if (item.isGotAdmission())
                {
                    if (!(StudentDL.registeredStudentsList.Contains(item)))
                    {
                        StudentDL.addIntoRegStuList(item);
                    }
                    Console.WriteLine($"{item.name} GOT ADMISSION IN {item.admPref.degreeTitle}");
                }
                else
                {
                    Console.WriteLine($"{item.name} DID NOT GOT ADMISSION IN {item.admPref.degreeTitle}");

                }
            }
        }
        public static void showRegStudents ()
        {
            /*foreach (Student item in Student.studentList)
            {
                Console.WriteLine($"{item.name} ");
            }*/
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (Student s in StudentDL.registeredStudentsList)
            {
                Console.WriteLine($"{s.name}\t{s.fscMarks}\t{s.ecatMarks}\t{s.age}");
            }
        }
        public static void showRegStudentsSpecificProg ()
        {
            Console.WriteLine("Enter Degree Name");
            string degreeName = Console.ReadLine();
            Console.WriteLine("NAME\tFSC\tECAT\tAGE");
            foreach (Student s in StudentDL.registeredStudentsList)
            {
                if (degreeName == s.regDegree.degreeTitle)
                {
                    Console.WriteLine($"{s.name}\t{s.fscMarks}\t{s.ecatMarks}\t{s.age}");
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
                bool registered = SubjectDL.isSubjectRegistered(stu , code);
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
        public static void showWithFee ()
        {
            int fee;
            Console.WriteLine("NAME\tFSC\tECAT\tAGE\tTotal Fee");
            foreach (Student s in StudentDL.registeredStudentsList)
            {
                fee = s.calculateFee();
                Console.WriteLine($"{s.name}\t{s.fscMarks}\t{s.ecatMarks}\t{s.age}\t{fee}");

            }
        }
    }
}
