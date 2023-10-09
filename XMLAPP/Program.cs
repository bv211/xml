using System.Xml.Serialization;

string path = "students.xml";

#region SingleSerialize 
{
    var type = typeof(Student);
    XmlSerializer serializer = new(type);

    // write
    using (FileStream fStream = new(path, FileMode.Create))
    {
        Student student = new(name: "Petya", phone: "+7(950)123-45-67");
        serializer.Serialize(fStream, student);
    }

    // read
    using (FileStream fStream = new(path, FileMode.Open))
    {
        Student? student = serializer.Deserialize(fStream) as Student;

        Console.WriteLine(student?.Name);
        Console.WriteLine(student?.Phone);
    }
}
#endregion

#region ArraySerialize 
{
    var type = typeof(Student[]);
    XmlSerializer serializer = new(type);

    // write
    using (FileStream fStream = new(path, FileMode.Create))
    {
        Student[] students = new Student[]
        {
            new(name: "Petya", phone: "+7(950)123-45-67"),
            new(name: "Vasya", phone: "+7(950)123-45-67"),
            new(name: "Ivan", phone: "+7(950)123-45-67"),
            new(name: "Galya", phone: "+7(950)123-45-67"),
            new(name: "Olya", phone: "+7(950)123-45-67"),
        };

        serializer.Serialize(fStream, students);
    }

    // read
    using (FileStream fStream = new(path, FileMode.Open))
    {
        if (serializer.Deserialize(fStream) is not Student[] students) return;

        foreach (var student in students)
        {
            Console.WriteLine(student.Name);
            Console.WriteLine(student.Phone);
        }
    }
}
#endregion