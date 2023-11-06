using System;
using System.Collections.Generic;
using System.Linq;

abstract class Worker
{
    public string Name { get; }
    public string Position { get; }
    public int WorkDay { get; }
    public Worker(string name, string position, int workDay)
    {
        Name = name;
        Position = position;
        WorkDay = workDay;
    }
    public void Call()
    {
        Console.WriteLine($"{Position} На сазвонах");
    }
    public void WriteCode()
    {
        Console.WriteLine($"{Position} кодить");
    }
    public void Relax()
    {
        Console.WriteLine($"{Position} Ларіса АБЕД");
    }
    abstract public void FillWorkDay();
}

class Developer : Worker
{
    public Developer(string name, int workDay) : base(name, "розробник", workDay) { }
    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

class Manager : Worker
{
    private Random random = new Random();
    public Manager(string name, int workDay) : base(name, "менеджер", workDay) { }
    public override void FillWorkDay()
    {
        Console.WriteLine($"{Position} день");
        int firstTime = random.Next(1, 11);
        for (int i = 0; i < firstTime; i++)
        {
            Call();
        }
        Relax();
        int secondTime = random.Next(1, 6);
        for (int i = 0; i < secondTime; i++)
        {
            Call();
        }
    }
}

class Team
{
    public string NameOfTeam { get; }
    private List<Worker> workers = new List<Worker>();

    public Team(string nameOfTeam)
    {
        NameOfTeam = nameOfTeam;
    }
    public bool ExistenceСheck(Worker worker)
    {
        return workers.Any(existingWorker =>
            existingWorker.Name == worker.Name && existingWorker.Position == worker.Position && existingWorker.WorkDay == worker.WorkDay);
    }
    public int NumberOfWorking()
    {
        return workers.Sum(worker => worker.WorkDay);
    }


    public void AddWorker(Worker worker)
    {
        
        if (!ExistenceСheck(worker) && NumberOfWorking() + worker.WorkDay <= 24)
        {
            workers.Add(worker);
        }
        else if (ExistenceСheck(worker))
        {
            Console.WriteLine("Інформація про працівника вже існує.");
        }
        else
        {
            Console.WriteLine("Працівник не може працювати більше 24 год на день.");
        }
    }

    public void PrintTeamInfo()
    {
        Console.WriteLine($"Team: {NameOfTeam}");
        Console.WriteLine("Employees:");
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name}");
        }
    }

    public void PrintDetailedTeamInfo()
    {
        Console.WriteLine($"Команда: {NameOfTeam}");
        Console.WriteLine("Детальна інформація:");

        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name}  {worker.Position}, працює {worker.WorkDay} годин");
        }
    }

  
}

public class Program
{
    private static void Main()
    {
        List<Team> teams = new List<Team>();

        bool add = true;

        while (add)
        {
            Console.Write("Введіть назву команди: ");
            string teamName = Console.ReadLine();
            Team team = new Team(teamName);
            teams.Add(team);

            bool addWorker = true;

            while (addWorker)
            {
                Console.Write("Бажаєте додати співробітника? Напишіть так або ні: ");
                string answer = Console.ReadLine();

                if (answer == "так")
                {
                    Console.Write("Введіть ім'я вашого робітника: ");
                    string name = Console.ReadLine();

                    Console.Write("Яку посаду він займає? Напишіть менеджер чи розробник: ");
                    string position = Console.ReadLine();

                    Console.Write("Напишіть кількість робочих годин: ");
                    int workDay = int.Parse(Console.ReadLine());

                    if (position.ToLower() == "розробник")
                    {
                        Developer developer = new Developer(name, workDay);
                        team.AddWorker(developer);
                    }
                    else if (position.ToLower() == "менеджер")
                    {
                        Manager manager = new Manager(name, workDay);
                        team.AddWorker(manager);
                    }
                    else
                    {
                        Console.WriteLine("Введена некоректна інформація");
                    }
                }
                else if (answer == "ні")
                {
                    addWorker = false;
                }

                Console.Write("Бажаєте додати ще співробітника в цій команді? Якщо так, то введіть введіть так або ні: ");
                string answer3 = Console.ReadLine();
                if (answer3 != "так")
                {
                    addWorker = false;
                }
            }

            Console.Write("Бажаєте додати ще команду? Якщо так, то введіть так або ні  : ");
            string answer4 = Console.ReadLine();
            if (answer4 != "так")
            {
                add = false;
            }
        }

        Console.Write("Бажаєте отримати детальну інформацію? Напишіть так або ні: ");
        string answer2 = Console.ReadLine();
        if (answer2 == "так")
        {
            foreach (var team in teams)
            {
                team.PrintDetailedTeamInfo();
            }
        }
    }
}

