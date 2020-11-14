using System;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VacationBudgetPlanner
{
    class Program
    {
        public static decimal GetConversionRates(int a)
        {
            var webRequest = WebRequest.Create("https://api.currencyfreaks.com/latest?apikey=b18b2da76e9a4749b187a39c606468df&symbols=EUR,USD,COP") as HttpWebRequest;


            webRequest.ContentType = "application/json";


            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    string currencyRatesAsJson = sr.ReadToEnd();

                    JObject currencyRates = JObject.Parse(currencyRatesAsJson);

                    decimal eurConversionRate = (decimal)currencyRates["rates"]["EUR"];
                    decimal copConversionRate = (decimal)currencyRates["rates"]["COP"];

                    //Console.WriteLine(currencyRates); - test print of json
                    //Console.WriteLine(eurConversionRate); - test print of rate
                    if (a == 1)
                    {
                        return eurConversionRate;
                    }
                    else
                    {
                        return copConversionRate;
                    }


                }

            }
        }


        static void Main(string[] args)
        {

            //Variables

            int travelLocation;
            string name;
            int tripLength;
            decimal spendingMoney;
            string money;
            double perDiem;
            decimal euroRate = GetConversionRates(1);
            decimal colRate = GetConversionRates(2);
            string perDiemConversion;
            double hours;
            double minutes;
            double inCountryRate;
            TimeSpan expand;

            CultureInfo eu = new CultureInfo("fr-FR");
            CultureInfo co = new CultureInfo("es-CO");


            //Program


            Console.WriteLine("Welcome to the Vacation Budget Planner!");

            //Uncomment line below : Test to make sure rate is being pulled
            //Console.WriteLine($"The current conversion rate is {euroRate}");

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            bool leave = false;

            do
            {
                Console.WriteLine($"Hi {name}! Where would you like to travel? Select a number: (1) Portugal or (2) Colombia. To exit press 3");
                travelLocation = sbyte.Parse(Console.ReadLine());

                switch (travelLocation)
                {
                    case 1:

                        Console.WriteLine("Legal! That means 'Cool' in Portugese! Portugal is a good choice!");

                        Console.WriteLine("**********");

                        Console.WriteLine($"How many days will you spend in Portgual, {name}?");
                        tripLength = sbyte.Parse(Console.ReadLine());

                        Console.WriteLine("How much spending money do you plan to bring?");
                        spendingMoney = Int32.Parse(Console.ReadLine());

                        money = spendingMoney.ToString("C2");

                        expand = TimeSpan.FromDays(tripLength);
                        hours = expand.TotalHours;
                        minutes = expand.TotalMinutes;


                        perDiem = (double)(spendingMoney / tripLength);
                        inCountryRate = (double)(spendingMoney * euroRate) / tripLength;

                        perDiemConversion = inCountryRate.ToString("c", eu);

                        Console.WriteLine($"You will be in Portugal for {tripLength} days, {hours} hours, and {minutes} minutes.");

                        Console.WriteLine($"While there you will have {money} to spend.");

                        Console.WriteLine("Your daily spending limit is {0:C2} or {1:C}", perDiem, perDiemConversion);

                        Console.WriteLine("Enjoy your trip!");
                        break;

                    case 2:

                        Console.WriteLine("Colombia is a great choice! I've heard Cartagena is amazing!");

                        Console.WriteLine("**********");

                        Console.WriteLine($"How many days will you spend in Colombia, {name}?");
                        tripLength = sbyte.Parse(Console.ReadLine());

                        Console.WriteLine("How much spending money do you plan to bring?");
                        spendingMoney = Int32.Parse(Console.ReadLine());

                        money = spendingMoney.ToString("C2");

                        expand = TimeSpan.FromDays(tripLength);
                        hours = expand.TotalHours;
                        minutes = expand.TotalMinutes;

                        perDiem = (double)(spendingMoney / tripLength);
                        inCountryRate = (double)(spendingMoney * colRate) / tripLength;

                        perDiemConversion = inCountryRate.ToString("c", co);

                        Console.WriteLine($"You will be in Colombia for {tripLength} days, {hours} hours, and {minutes} minutes.");

                        Console.WriteLine($"While there you will have {money} to spend.");

                        Console.WriteLine("Your daily spending limit is {0:C2} USD or {1:C2} COL", perDiem, perDiemConversion);

                        Console.WriteLine("Enjoy your trip!");
                        break;

                    case 3:

                        Console.WriteLine("Safe Travels!");
                        leave = true;
                        break;

                    default:

                        Console.WriteLine("At this time you can only select between Portgual or Colombia");
                        break;
                }

            } while (leave != true);
        }

    }
}
