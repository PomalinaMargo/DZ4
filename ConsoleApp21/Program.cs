using System;
public abstract class GeographicalObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    public virtual void Information()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Координати: ({X}, {Y})");
    }
}


public class River : GeographicalObject
{
    public double Speed { get; set; }
    public double Length { get; set; }

    public override void Information()
    {
        base.Information();

        Console.WriteLine($"Швидкість течії: {Speed} см/с");
        Console.WriteLine($"Загальна довжина: {Length} ");

    }
}

public class Mountain : GeographicalObject
{
    public double Peak { get; set; }

    public override void Information()
    {
        base.Information();
        Console.WriteLine($"Найвища точка: {Peak}");
    }
}
