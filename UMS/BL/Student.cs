using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class Student
    {
        private string name;
        private int age;
        private int fscMarks;
        private int matricMarks;
        private int ecatMarks;
        private double merit;
        private List<DegreeProgram> preferences;
        private List<Subject> regSubject;
        private DegreeProgram admPref;
        private DegreeProgram regDegree;
        public Student (string name , int age , int fscMarks , int matricMarks , int ecatMarks)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.matricMarks = matricMarks;
            this.ecatMarks = ecatMarks;
            preferences = new List<DegreeProgram>();
            regSubject = new List<Subject>();
            regDegree = null;
        }
        public Student (string name , int age , int fscMarks , int ecatMarks)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            preferences = new List<DegreeProgram>();
            regSubject = new List<Subject>();
            regDegree = null;
        }
        public string getName ()
        {
            return name;
        }
        public int getAge ()
        {
            return age;
        }
        public int getFscMarks ()
        {
            return fscMarks;
        }
        public int getMatricMarks ()
        {
            return matricMarks;
        }
        public int getEcatMarks ()
        {
            return ecatMarks;
        }
        public double getMerit ()
        {
            return merit;
        }
        public List<DegreeProgram> getPreferences ()
        {
            return preferences;
        }
        public List<Subject> getRegSubject ()
        {
            return regSubject;
        }
        public DegreeProgram getadmPref ()
        {
            return admPref;
        }
        public DegreeProgram getRegDegree ()
        {
            return regDegree;
        }
        public void setName (string name)
        {
            this.name = name;
        }
        public void setAge (int age)
        {
            this.age = age;
        }
        public void setFscMarks (int fscMarks)
        {
            this.fscMarks = fscMarks;
        }
        public void setMatricMarks (int matricMarks)
        {
            this.matricMarks = matricMarks;
        }
        public void setEcatMarks (int ecatMarks)
        {
            this.ecatMarks = ecatMarks;
        }

        public void setMerit (double merit)
        {
            this.merit = merit;
        }
        public void setPreferences (List<DegreeProgram> preferences)
        {
            this.preferences = preferences;
        }
        public void setRegSubject (List<Subject> regSubject)
        {
            this.regSubject = regSubject;
        }
        public void setadmPref (DegreeProgram admPref)
        {
            this.admPref = admPref;
        }
        public void setRegDegree (DegreeProgram regDegree)
        {
            this.regDegree = regDegree;
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
                ch += regSubject[i].getCreditHours();
                //  Console.WriteLine(ch);
                //Console.WriteLine(regSubject[i].creditHours);

            }
            //  Console.WriteLine(ch);

            return ch;
        }
        public int calculateFee ()
        {
            int fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regSubject)
                {
                    fee += sub.getSubjectFee();
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
            merit = (((fscMarks / 1100F) * 0.45F) + ((ecatMarks / 400F) * 0.55F)) * 100F;
            //            Console.WriteLine(merit);

            return merit;
        }

        public bool regStudentSubject (Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && preferences[0].isSubjectExist(s) && stCH + s.getCreditHours() <= 9)
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
                if (preferences[i].getMerit() <= merit)
                {
                    DegreeProgram temp = preferences[0];
                    preferences[0] = preferences[i];
                    admPref = preferences[0];
                    regDegree = preferences[0];
                    int seats = preferences[0].getSeats();
                    seats--;
                    preferences[0].setSeats(seats);
                    return true;
                }
            }
            admPref = preferences[0];
            return false;
        }


    }
}
