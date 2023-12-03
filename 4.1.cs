using System;
using System.Collections.Generic;

// Базовий клас "Живий організм"
public class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }

    public LivingOrganism(int energy, int age, int size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}

// Інтерфейс "Можливість розмноження"
public interface IReproducible
{
    void Reproduce();
}

// Інтерфейс "Можливість полювання"
public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

// Клас "Тварина"
public class Animal : LivingOrganism, IReproducible, IPredator
{
    public int Speed { get; set; }

    public Animal(int energy, int age, int size, int speed)
        : base(energy, age, size)
    {
        Speed = speed;
    }

    public void Reproduce()
    {
        Console.WriteLine("Animal is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine("Animal is hunting.");
    }
}

// Клас "Рослина"
public class Plant : LivingOrganism, IReproducible
{
    public int SunlightNeeded { get; set; }

    public Plant(int energy, int age, int size, int sunlightNeeded)
        : base(energy, age, size)
    {
        SunlightNeeded = sunlightNeeded;
    }

    public void Reproduce()
    {
        Console.WriteLine("Plant is producing seeds.");
    }
}

// Клас "Мікроорганізм"
public class Microorganism : LivingOrganism, IReproducible
{
    public double DivisionRate { get; set; }

    public Microorganism(int energy, int age, int size, double divisionRate)
        : base(energy, age, size)
    {
        DivisionRate = divisionRate;
    }

    public void Reproduce()
    {
        Console.WriteLine("Microorganism is dividing.");
    }
}

// Клас "Екосистема"
public class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem(List<LivingOrganism> organisms)
    {
        this.organisms = organisms;
    }

    public void SimulateInteraction()
    {
        Random random = new Random();

        foreach (var organism in organisms)
        {
            var otherOrganism = organisms[random.Next(organisms.Count)];
            if (organism != otherOrganism)
            {
                if (organism is IReproducible && organism.Energy > 50)
                {
                    (organism as IReproducible).Reproduce();
                }
                else if (organism is IPredator && organism.Energy > 30)
                {
                    (organism as IPredator).Hunt(otherOrganism);
                }
                else
                {
                    Console.WriteLine($"{organism.GetType().Name} is resting.");
                }
            }
        }
    }
}

// Приклад використання:

class Program
{
    static void Main()
    {
        Animal lion = new Animal(70, 5, 3, 20);
        Plant tree = new Plant(50, 10, 2, 30);
        Microorganism bacteria = new Microorganism(30, 1, 1, 0.5);

        List<LivingOrganism> organisms = new List<LivingOrganism> { lion, tree, bacteria };
        Ecosystem ecosystem = new Ecosystem(organisms);
        ecosystem.SimulateInteraction();
    }
}
