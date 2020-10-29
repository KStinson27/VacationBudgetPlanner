using System;

namespace VacationBudgetPlanner
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Vacation Budget Planner!");

            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine($"Hi {name}! Where would you like to travel: Portugal or Brazil?");
            string travelLocation = Console.ReadLine();

            Console.ReadLine();
        }
    }
}
