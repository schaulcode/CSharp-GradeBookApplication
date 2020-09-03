using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5) throw new InvalidOperationException();

            List<double> averageGrades = new List<double>();
            foreach (Student student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }

            int numberStudentsPerRanking = (Students.Count * 20) / 100;

            int gradeRank = averageGrades.IndexOf(averageGrade);

            if (gradeRank < numberStudentsPerRanking)
                return 'A';
            else if (gradeRank < numberStudentsPerRanking * 2)
                return 'B';
            else if (gradeRank < numberStudentsPerRanking * 3)
                return 'C';
            else if (gradeRank < numberStudentsPerRanking * 4)
                return 'D';
            else
                return 'F';
            
        }
    }
}
