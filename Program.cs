using System;
using System.Globalization;

namespace VacationBudgetPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables

            string travelLocation;
            string name;
            int tripLength;
            decimal spendingMoney;
            string money;
            double perDiem;
            double euroRate = 0.86;
            string perDiemEuro;
            double inEuro;
            CultureInfo eu = new CultureInfo("fr-FR");

            //Program

            Console.WriteLine("Welcome to the Vacation Budget Planner!");

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            Console.WriteLine($"Hi {name}! Where would you like to travel: Portugal or Brazil?");
             travelLocation = Console.ReadLine().ToLower();

            if (travelLocation == "portugal")
            {
                Console.WriteLine("Portugal is a good choice! ");

                Console.WriteLine($"How many days will you spend in Portgual, {name}?");
                tripLength = Int32.Parse(Console.ReadLine());

                Console.WriteLine("How much spending money do you plan to bring?");
                spendingMoney = Int32.Parse(Console.ReadLine());

                money = spendingMoney.ToString("C2");

                perDiem = (double)(spendingMoney / tripLength);
                inEuro = (double) spendingMoney * euroRate;

                perDiemEuro = inEuro.ToString("c", eu);

                Console.WriteLine($"You're going to Portugal for {tripLength} days and will have {money} to spend.");

                Console.WriteLine("Your daily spending limit is {0:C2} or {1:C}",perDiem, perDiemEuro);
            }
            else
            {
                Console.WriteLine("To Be Continued");
            }
        }
    }
}
