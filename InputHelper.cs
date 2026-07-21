using System;

public static class InputHelper
{
	public static int GetValidInt(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			if (int.TryParse(input, out int value))
			{
				return value;
			}


			Console.WriteLine("Please enter a valid number. ");
		}
	}

	public static string GetValidString(string prompt)
	{
		while (true)
		{
			Console.Write(prompt);
			string? input = Console.ReadLine();

			if (!string.IsNullOrWhiteSpace(input))
				return input;

			Console.WriteLine("Input cannot be empty");
		}
	}

    public static string GetUniqueStudentId(List<Student> students, string prompt = "\nEnter the student ID: ")
    {
        while (true)
        {
            string id = GetValidString(prompt);

            bool exists = false;
            foreach (Student student in students)
            {
                if (id == student.StudentId)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                return id;
            }

            Console.Write("ID already exists, please choose alternative: ");
        }
    }
    public static double GetValidDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double value))
            {
                return value;
            }

            Console.WriteLine("Please enter a valid number.");
        }
    }

    public static string GetExistingStudentId(List<Student> students, string prompt = "Enter the student ID: ")
    {
        while (true)
        {
            string id = GetValidString(prompt);

            bool exists = false;
            foreach (Student student in students)
            {
                if (id == student.StudentId)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                return id;
            }

            Console.WriteLine("Student ID not found. Please try again.");
        }
    }
}
