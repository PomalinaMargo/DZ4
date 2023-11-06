public interface IGeographicalObject
{
    void Information();
}

class Program
{
    static void Main(string[] args)
    {

        River river = new River
        {
            X = 23.4872,
            Y = 21.849,
            Name = "Сльози студентів",
            Description = "Це уявна річка, яка складається із сліз студентів, яких хочуть вивести на очну сесію",
            Speed = 1000000,
            Length = 132320801
        };

        river.Information();


        Mountain mountain = new Mountain
        {
            X = 197.79230,
            Y = 8372.32070,
            Name = "Дедлайни",
            Description = "Це гора дедлайнів, які потрібно закрити, щоб допустили до сесії",
            Peak = 9749729711
        };

        mountain.Information();

        Console.ReadKey();
    }
}