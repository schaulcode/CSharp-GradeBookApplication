using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in orderto properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in orderto properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);  
        }
    }
}
