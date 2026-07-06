using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Student
{
    // Properties
    public int StudentId { get; set; }
    public String FirstName { get; set; } = string.Empty;
    public String LastName { get; set; }
    public int Age { get; set; }
    public String Course { get; set; } = string.Empty;
    public int Average { get; set; }


    // Constructor
    public Student(int StudentId, String FirstName, String LastName, int Age, String Course,int Average)
    {
        this.StudentId = StudentId;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
        this.Course = Course;
        this.Average = Average;

    }	   
	
}
