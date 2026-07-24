Student Management System

A simple console-based Student Management System built with C# (.NET).

Features

- Add Student – Add a new student with unique ID validation
- View Students – Display all students in a formatted table
- Search Student – Find a student by ID
- Update Student – Update student details (with option to skip fields)
- Delete Student – Remove a student by ID
- View Report – Generate a full report using LINQ:
  - Total student count
  - Passed students (Average ≥ 50)
  - Failed students (Average < 50)
  - Class average
  - Highest average student
  - Lowest average student
  - Students ordered by average (descending)
- JSON Persistence – Automatically saves and loads student data from "students.json"

Project Structure

| File | Description |
|------|-------------|
| `Program.cs` | Main menu and application logic |
| `Student.cs` | Student class (model) |
| `InputHelper.cs` | Input validation helpers |
| `ReportService.cs` | LINQ-based reporting |
| `StudentDataServices.cs` | Handles saving and loading students to/from JSON |

How to Run

1. Open the project in Visual Studio, VS Code or any relevant IDE
2. Make sure you have .NET SDK installed
3. Run the project:

```bash
dotnet run
