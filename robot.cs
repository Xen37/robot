using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Robot cleaner = new CleaningRobot("Cleaning Robot", new LithiumBattery());
        Robot delivery = new DeliveryRobot("Delivery Robot", new SolarBattery());

        List<Robot> robots = new List<Robot>
        {
            cleaner,
            delivery
        };

        foreach (Robot robot in robots)
        {
            Console.WriteLine($"\nRobot: {robot.Name}");
            Console.WriteLine($"Energy before task: {robot.RemainingEnergy}");

            robot.PerformTask();

            Console.WriteLine($"Energy after task: {robot.RemainingEnergy}");

            robot.Recharge(20);

            Console.WriteLine($"Energy after recharge: {robot.RemainingEnergy}");
        }
    }
}

public abstract class Robot
{
    private IBattery battery;

    public string Name;
    public int RemainingEnergy;

    protected Robot(string name, IBattery battery)
    {
        Name = name;
        this.battery = battery;
        RemainingEnergy = battery.GetRemainingEnergy();
    }

    public void Recharge(int amount)
    {
        battery.Recharge(amount);
        RemainingEnergy = battery.GetRemainingEnergy();
    }

    protected void UseEnergy(int amount)
    {
        battery.Consume(amount);
        RemainingEnergy = battery.GetRemainingEnergy();
    }

    public abstract void PerformTask();
}

class CleaningRobot : Robot
{
    public CleaningRobot(string name, IBattery battery)
        : base(name, battery)
    {
    }

    public override void PerformTask()
    {
        Console.WriteLine($"{Name} is cleaning.");
        UseEnergy(10);
    }
}

class DeliveryRobot : Robot
{
    public DeliveryRobot(string name, IBattery battery)
        : base(name, battery)
    {
    }

    public override void PerformTask()
    {
        Console.WriteLine($"{Name} is delivering an item.");
        UseEnergy(25);
    }
}

public interface IBattery
{
    int GetRemainingEnergy();
    void Consume(int amount);
    void Recharge(int amount);
}

class LithiumBattery : IBattery
{
    private int energy = 100;

    public int GetRemainingEnergy()
    {
        return energy;
    }

    public void Consume(int amount)
    {
        if (amount < 0)
            return;

        energy -= amount;

        if (energy < 0)
            energy = 0;
    }

    public void Recharge(int amount)
    {
        if (amount < 0)
            return;

        energy += amount;

        if (energy > 100)
            energy = 100;
    }
}

class SolarBattery : IBattery
{
    private int energy = 100;

    public int GetRemainingEnergy()
    {
        return energy;
    }

    public void Consume(int amount)
    {
        if (amount < 0)
            return;

        energy -= amount;

        if (energy < 0)
            energy = 0;
    }

    public void Recharge(int amount)
    {
        if (amount < 0)
            return;

        energy += amount;

        if (energy > 100)
            energy = 100;
    }
}


