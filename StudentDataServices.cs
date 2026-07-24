using System;
using System.Text.Json;

public class StudentDataService
{
    // Save
    public static void SaveStudents(List<Student> students)
    {
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students.json", json);
    }

    // Load
    public static List<Student> LoadStudents()
    {
        if (!File.Exists("students.json"))
            return new List<Student>();

        string json = File.ReadAllText("students.json");
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }
}
