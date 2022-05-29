using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class DegreeProgram
    {
        private string degreeTitle;
        private double degreeDuration;
        private double merit;
        private int seats;
        private List<Subject> subjectsList;
        private List<Student> regStudentsList;


        public DegreeProgram (string degreeTitle , double degreeDuration)
        {
            this.degreeTitle = degreeTitle;
            this.degreeDuration = degreeDuration;
            subjectsList = new List<Subject>();

        }
        //GETTERS
        public string getDegreeTitle ()
        {
            return degreeTitle;
        }
        public double getDegreeDuration ()
        {
            return degreeDuration;
        }
        public double getMerit ()
        {
            return merit;
        }
        public int getSeats ()
        {
            return seats;
        }
        public List<Subject> getSubjectsList ()
        {
            return subjectsList;
        }
        public List<Student> getRegStudentsList ()
        {
            return regStudentsList;
        }

        //SETTERS
        public void setDegreeTitle (string degreeTitle)
        {
            this.degreeTitle = degreeTitle;
        }

        public void getSubjectsList (List<Subject> subjectsList)
        {
            this.subjectsList = subjectsList;
        }
        public void getRegStudentsList (List<Student> regStudentsList)
        {
            this.regStudentsList = regStudentsList;
        }
        public void setSeats (int seats)
        {
            this.seats = seats;
        }
        public void setMerit (double merit)
        {
            this.merit = merit;
        }
        public void setDegreeDuration (double degreeDuration)
        {
            this.degreeDuration = degreeDuration;
        }
        //Behaviours
        public int calculateCreditHours ()
        {
            int count = 0;
            for (int i = 0 ; i < subjectsList.Count ; i++)
            {
                count += subjectsList[i].getCreditHours();
            }
            return count;
        }
        public bool addSubject (Subject s)
        {
            int creditHrs = calculateCreditHours();
            if (creditHrs + s.getCreditHours() <= 20)
            {
                subjectsList.Add(s);
                return true;
            }
            else
            {
                //  Console.WriteLine("Limit Exceeded");
                return false;
            }
        }
        public bool isSubjectExist (Subject s)
        {
            foreach (Subject sub in subjectsList)
            {
                if (s.getCode() == sub.getCode())
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isSubjectRegistered (Student stu , string code , DegreeProgram regDegree)
        {
            foreach (Subject s in stu.getRegDegree().subjectsList)
            {
                if (s.getCode() == code && !(stu.getRegSubject().Contains(s)))
                {
                    stu.regStudentSubject(s);
                    return true;
                }
            }
            return false;
        }
    }
}
