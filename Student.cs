using System;

public class Student
{
    // Properties
    public string StudentId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Course { get; set; } = string.Empty;
    public double Average { get; set; }


    // Constructor
    public Student(string StudentId, string FirstName, string LastName, int Age, string Course,double Average)
    {
        this.StudentId = StudentId;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
        this.Course = Course;
        this.Average = Average;

    }	   
	
}
