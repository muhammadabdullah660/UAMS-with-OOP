using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.BL
{
    class DegreeProgram
    {
        public string degreeTitle;
        public double degreeDuration;
        public List<Subject> subjectsList;
        public double merit;
        public int seats;
        public List<Student> regStudentsList;


        public DegreeProgram (string degreeTitle , double degreeDuration)
        {
            this.degreeTitle = degreeTitle;
            this.degreeDuration = degreeDuration;
            subjectsList = new List<Subject>();

        }

        public void addSeatsAndMerit (int seats , double merit)
        {
            this.seats = seats;
            this.merit = merit;
        }
        public int calculateCreditHours ()
        {
            int count = 0;
            for (int i = 0 ; i < subjectsList.Count ; i++)
            {
                count += subjectsList[i].creditHours;
            }
            return count;
        }
        public bool addSubject (Subject s)
        {
            int creditHrs = calculateCreditHours();
            if (creditHrs + s.creditHours <= 20)
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
                if (s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
