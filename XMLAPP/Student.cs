public class Student
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Student() : this(string.Empty, string.Empty) { }

    public Student(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
}