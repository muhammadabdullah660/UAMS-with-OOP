using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.BL;
using UMS.DL;
using UMS.UI;
namespace UMS.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgram takeInputDegreeProgram ()
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
                Subject s = SubjectUI.subjectsInfo();
                if (d.addSubject(s))
                {
                    // These are done here because we did not add a separate option to add only the Subjects.
                    if (!(SubjectDL.subjectsList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeIntoFile("subject.txt" , s);
                    }

                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    i--;
                }
            }
            return d;
        }
    }
}
