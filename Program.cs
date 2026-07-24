using System.Text.Json;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = StudentDataService.LoadStudents();

            while (true)
            {

                int option;

                Console.WriteLine("\nWelcome to the Student Management System");
                Console.WriteLine("-----------------------------------------");

                Console.WriteLine("Menu");

                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Students");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. View Report");
                Console.WriteLine("7. Exit");

                Console.Write("Enter an option from the menu: ");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid entry. Please try again");
                    Console.Write("Enter an option from the menu: ");

                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nYou chose to Add a student");
                        Console.WriteLine("---------------------------\n");
                        AddStudent(studentList);
                        break;
                    case 2:
                        Console.WriteLine("\nYou chose to View Students");
                        Console.WriteLine("---------------------------\n");
                        ViewStudents(studentList);
                        break;
                    case 3:
                        Console.WriteLine("\nYou chose to Search Students");
                        Console.WriteLine("------------------------------\n");
                        SearchStudents(studentList);
                        break;
                    case 4:
                        Console.WriteLine("\nYou chose to Update a Student");
                        Console.WriteLine("------------------------------\n");
                        UpdateStudent(studentList);
                        break;
                    case 5:
                        Console.WriteLine("\nYou chose to Delete a student");
                        Console.WriteLine("-------------------------------\n");
                        DeleteStudent(studentList);
                        break;
                    case 6:
                        Console.WriteLine("\nYou chose to view report");
                        Console.WriteLine("-------------------------------\n");
                        ReportService.GenerateFullReport(studentList);
                        break;
                    case 7:
                        Console.WriteLine("You chose to exit");
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                }



                Console.ReadKey();
            }
        }


        //Add a student
        static void AddStudent(List<Student> students)
        {
            Console.WriteLine("----Add New Student----");

            string StudentId = InputHelper.GetUniqueStudentId(students);

            string FirstName = InputHelper.GetValidString("Enter the First Name of the New Student: ");

            string LastName = InputHelper.GetValidString("Enter the Last Name of the New Student: ");

            int Age = InputHelper.GetValidInt("Enter the Age of the New Student: ");

            string Course = InputHelper.GetValidString("Enter the Course of the New Student: ");
            
            double Average;
            Console.Write("Enter the Average of the New Student: ");
            while (double.TryParse(Console.ReadLine(), out Average) == false)
            {
                Console.Write("Invalid input. Please enter a valid number for Average: ");
            }

            // Student Object via constructor
            Student newStudent = new Student(StudentId, FirstName, LastName, Age, Course, Average);
            students.Add(newStudent);
            StudentDataService.SaveStudents(students);

            Console.WriteLine("\nNew Student Successfully Added!");

            Console.WriteLine("\nPress any key to return to menu...");

        }

        //View Students
        static void ViewStudents(List<Student> students)
        {
            //Checks if list has students
            if(students.Count == 0)
            {
                Console.WriteLine("No students found in the system.");
                return; //Exits method early so rest of code does not run
            }


            //Heading
            string headers = "";
            headers += "STUDENT ID".PadRight(12) + "| ";
            headers += "FIRST NAME".PadRight(15) + "| ";
            headers += "LAST NAME".PadRight(15) + "| ";
            headers += "AGE".PadRight(6) + "| ";
            headers += "COURSE".PadRight(20) + "| ";
            headers += "AVERAGE";

            Console.WriteLine(headers);

            Console.WriteLine(new string('-', headers.Length + 6));

            for (int i = 0; i < students.Count; i++)
            {
                Student AvailStudent = students[i];
                string row = "";

                // Add each property, padded to a fixed width, followed by the separator
                row += AvailStudent.StudentId.ToString().PadRight(12) + "| ";
                row += AvailStudent.FirstName.PadRight(15) + "| ";
                row += AvailStudent.LastName.PadRight(15) + "| ";
                row += AvailStudent.Age.ToString().PadRight(6) + "| ";
                row += AvailStudent.Course.PadRight(20) + "| ";
                row += AvailStudent.Average.ToString().PadRight(6);

                Console.WriteLine(row);
            }

            Console.WriteLine("\nPress any key to return to menu...");
        }

        //Search For a Student
        static void SearchStudents(List<Student> students)
        {
            Console.WriteLine("----Search for a Student----");

            string search = InputHelper.GetExistingStudentId(students);
            bool found = false;

            foreach (Student student in students)
            {
                if (search == student.StudentId)
                {
                    found = true;
                    Console.WriteLine($"\nID: {student.StudentId} | Name: {student.FirstName} {student.LastName}" +
                        $" | Age: {student.Age} | Course: {student.Course} | Average: {student.Average}");
                    break;
                }
            }
            if(found == false)
            {
                Console.WriteLine("Student Not Found!");
            }

            Console.WriteLine("\nPress any key to return to menu...");

        }

        //Update a Student's Details
        static void UpdateStudent(List<Student> students)
        {
            Console.WriteLine("----Update the details of a Student----");

            string search = InputHelper.GetExistingStudentId(students);

            bool found = true;

            foreach (Student student in students)
            {
                if (search == student.StudentId)
                {
                    found = true;
                    Console.WriteLine($"\n Current Details: \nID: {student.StudentId} | Name: {student.FirstName} {student.LastName} " +
                        $"| Age: {student.Age} | Course: {student.Course} | Average: {student.Average}");

                    // First Name
                    Console.Write("\nEnter new First Name (or press Enter to skip): ");
                    string inputFirstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputFirstName))
                        student.FirstName = inputFirstName;

                    // Last Name
                    Console.Write("\nEnter new Last Name (or press Enter to skip): ");
                    string inputLastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputLastName))
                        student.LastName = inputLastName;

                    // Age
                    Console.Write("\nEnter new Age (or press Enter to skip): ");
                    string inputAge = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputAge))
                    {
                        student.Age = InputHelper.GetValidInt("\nEnter new Age: ");
                    }

                    // Course
                    Console.Write("\nEnter new Course Name (or press Enter to skip): ");
                    string inputCourse = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputCourse))
                        student.Course = inputCourse;

                    // Average
                    Console.Write("\nEnter new Average Mark (or press Enter to skip): ");
                    string inputAverage = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputAverage))
                    {
                        student.Average = InputHelper.GetValidDouble("\nEnter new Average: ");
                    }

                    Console.WriteLine($"\n New Details: \nID: {student.StudentId} | Name: {student.FirstName} {student.LastName} " +
                        $"| Age: {student.Age} | Course: {student.Course} | Average: {student.Average}");
                    StudentDataService.SaveStudents(students);

                    Console.WriteLine("Details Updated Successfully!");

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student Not Found!");
            }

            Console.WriteLine("\nPress any key to return to menu...");
        }

        //Delete a student
        static void DeleteStudent(List<Student> students)
        {
            Console.WriteLine("----Delete a Student----");

            string search = InputHelper.GetExistingStudentId(students);

            Student studentToDelete = null;

            foreach(Student student in students)
            {
                if(search == student.StudentId)
                {
                    studentToDelete = student;
                    break;
                }
            }

            if(studentToDelete != null)
            {
                students.Remove(studentToDelete);
                StudentDataService.SaveStudents(students);
                Console.WriteLine("Student record successfully deleted.");
            }
            else
            {
                Console.WriteLine("Student not found. No deletions made.");
            }

            Console.WriteLine("\nPress any key to return to menu...");
        }
    }
}