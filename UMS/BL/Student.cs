using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class Student
    {
        public string name;
        public int age;
        public int fscMarks;
        public int matricMarks;
        public int ecatMarks;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubject;
        public bool gotAdmission;
        public DegreeProgram admPref;
        public static List<Student> studentList = new List<Student>();



        public Student (string name , int age , int fscMarks , int matricMarks , int ecatMarks)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.matricMarks = matricMarks;
            this.ecatMarks = ecatMarks;
            preferences = new List<DegreeProgram>();
            regSubject = new List<Subject>();
            gotAdmission = false;
        }
        public void addPreference (DegreeProgram d)
        {
            preferences.Add(d);
        }
        public int getCreditHours ()
        {
            int ch = 0;
            //    Console.WriteLine(regSubject.Count);
            for (int i = 0 ; i < regSubject.Count ; i++)
            {
                ch += regSubject[i].creditHours;
                //  Console.WriteLine(ch);
                //Console.WriteLine(regSubject[i].creditHours);

            }
            //  Console.WriteLine(ch);

            return ch;
        }
        public int calculateFee ()
        {
            int fee = 0;
            if (gotAdmission)
            {
                foreach (Subject sub in regSubject)
                {
                    fee += sub.subjectFee;
                }
            }
            // int studentFee = getCreditHours() * 3000;
            //   Console.WriteLine(studentFee);
            return fee;
        }
        public double calculateMerit ()
        {
            /* Console.WriteLine(fscMarks);
             Console.WriteLine(ecatMarks);*/
            double merit = (((fscMarks / 1100F) * 0.45F) + ((ecatMarks / 400F) * 0.55F)) * 100F;
            Console.WriteLine(merit);

            return merit;
        }
        public bool regStudentSubject (Subject s)
        {
            int stCH = getCreditHours();
            if (gotAdmission && preferences[0].isSubjectExist(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            return false;
            /* else
             {
                 //  Console.WriteLine("A student cannot have more than 9 subjects or wrong code");

             }*/
        }
        public bool isGotAdmission ()
        {
            double merit = calculateMerit();
            for (int i = 0 ; i < preferences.Count ; i++)
            {
                if (preferences[i].merit <= merit)
                {
                    DegreeProgram temp = preferences[0];
                    preferences[0] = preferences[i];
                    admPref = preferences[0];
                    gotAdmission = true;
                    return true;
                }
            }
            admPref = preferences[0];
            return false;
        }

        public static Student isStudentPresent (string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.name && s.isGotAdmission())
                {
                    return s;
                }
            }
            return null;
        }
        public static void addStudentIntoList (Student s)
        {
            studentList.Add(s);
        }
    }
}
