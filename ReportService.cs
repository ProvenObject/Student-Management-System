using System;
using System.Linq;

public class ReportService
{
    public static void GenerateFullReport(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found in the system.");
            return; //Exits method early so rest of code does not run
        }
   
        Console.WriteLine("========== STUDENT REPORT ==========");

        //Student Count
        Console.WriteLine("\n----- Student Count -----");
        int StudentCount = students.Count();
        Console.WriteLine($"Students: {StudentCount}");

        //Passed Students
        Console.WriteLine("\nPassed Students");

        var PassedStudents = students.Where (s => s.Average >= 50).ToList();
        PrintStudentTable(PassedStudents);

        //Failed Students
        Console.WriteLine("\nFailed Students");

        var FailedStudents = students.Where (s => s.Average < 50).ToList();
        PrintStudentTable(FailedStudents);

        Console.WriteLine("\n----- Class Average -----");
        double classAverage = students.Average(s => s.Average);
        Console.WriteLine($"Class Average: {classAverage:F2}");

        // Highest student (single student)
        Console.WriteLine("\n----- Highest Average Student -----");
        var topStudent = students.OrderByDescending(s => s.Average).First();
        PrintStudentTable(new List<Student> { topStudent });   // put the one student into a list

        // Lowest student
        Console.WriteLine("\n----- Lowest Average Student -----");
        var bottomStudent = students.OrderBy(s => s.Average).First();
        PrintStudentTable(new List<Student> { bottomStudent });

        //Students Ordered By Averages
        Console.WriteLine("\n----- Students in descending order based on Averages -----");
        var DescendingAverage = students.OrderByDescending(s => s.Average).ToList();
        PrintStudentTable(DescendingAverage);

    }
    private static void PrintStudentTable(List<Student> studentsToPrint)
    {
        if (studentsToPrint == null || studentsToPrint.Count == 0)
        {
            Console.WriteLine("No students to display.");
            return;
        }

        string headers = "";
        headers += "STUDENT ID".PadRight(12) + "| ";
        headers += "FIRST NAME".PadRight(15) + "| ";
        headers += "LAST NAME".PadRight(15) + "| ";
        headers += "AGE".PadRight(6) + "| ";
        headers += "COURSE".PadRight(20) + "| ";
        headers += "AVERAGE";

        Console.WriteLine(headers);
        Console.WriteLine(new string('-', headers.Length + 6));

        foreach (Student student in studentsToPrint )
        {
            string row = "";
            row += student.StudentId.PadRight(12) + "| ";
            row += student.FirstName.PadRight(15) + "| ";
            row += student.LastName.PadRight(15) + "| ";
            row += student.Age.ToString().PadRight(6) + "| ";
            row += student.Course.PadRight(20) + "| ";
            row += student.Average.ToString().PadRight(6);

            Console.WriteLine(row);
        }
    }
}
