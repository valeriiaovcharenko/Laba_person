using System;

class Person
{
    private string name;
    private DateTime birthYear;

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public Person()
    {
    }

    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        Console.Write("Введiть iм'я: ");
        name = Console.ReadLine();
        Console.Write("Введiть рiк народження: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Введiть мiсяць народження: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Введiть день народження: ");
        int day = int.Parse(Console.ReadLine());
        birthYear = new DateTime(year, month, day);
    }

    public void ChangeName()
    {
        Console.Write("Введiть нове iм'я: ");
        name = Console.ReadLine();
    }

    public override string ToString()
    {
        return $"Iм'я: {name}, Рiк народження: {birthYear.Year}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        return person1.name == person2.name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return person1.name != person2.name;
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[6];

        for (int i = 0; i < 6; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }

        foreach (var person in people)
        {
            int age = person.Age();
            Console.WriteLine($"Iм'я: {person.Name}, Вiк: {(age < 16 ? "Very Young" : age.ToString())}");
        }

        Console.WriteLine("\nIнформація про всiх осiб:");
        foreach (var person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nОсоби з однаковими iменами:");
        for (int i = 0; i < people.Length - 1; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine($"{people[i].Name} та {people[j].Name} мають однакове iм'я.");
                }
            }
        }
    }
}