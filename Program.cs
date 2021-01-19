using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using KrakenEfCOre.Data;
using KrakenEfCOre.Domain.Models;
using static System.Console;

namespace KrakenEfCOre
{
    class Program
    {
        static KrakenContext context = new KrakenContext();
        static void Main(string[] args)
        {

            Program.Menu();
        }

        static void Menu()
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {


                Clear();

                WriteLine("1.Lägga till mål");
                WriteLine("2.Lista mål");
                WriteLine("3.Attakera mål");
                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);


                switch (keyPressed.Key)
                {

                    case ConsoleKey.D1:

                        AddTarget();

                        break;

                    case ConsoleKey.D2:

                        ListTargets();

                        break;

                    case ConsoleKey.D3:

                        AttackTargets();

                        break;

                    case ConsoleKey.D4:

                        shouldNotExit = false;

                        break;

                }

            }
        }

        private static void AttackTargets()
        {
            Random rnd = new Random();

            int hitOrMiss = rnd.Next(1, 101);

            var targets = context.Target;

            foreach (var target in targets)
            {

                if (target.Date == null)
                {
                    if (hitOrMiss > 0 && hitOrMiss < 50)
                    {
                        target.Hit();
                        

                        context.Target.Update(target);

                    }
                    else if (hitOrMiss > 50 && hitOrMiss < 100)
                    {

                        target.Miss();

                        context.Target.Update(target);

                    }


                    hitOrMiss = rnd.Next(1, 101);


                }

            }
            context.SaveChanges();

        }

        private static void ListTargets()
        {
            List<Target> targetList = context.Target.ToList();

            Clear();

            WriteLine("Name      Description      Date Attacked     Target destroyed?");
            WriteLine("------------------------------------------------------------------");

            foreach (Target target in targetList)
            {

                Write($"{target.Name}    {target.Description}         ");

                if (string.IsNullOrEmpty(target.Date.ToString()))
                {
                    Write("                 Target not yet attacked");
                }
                else if (!string.IsNullOrEmpty(target.Date.ToString()))
                {
                    Write(target.Date);

                }

                if (!string.IsNullOrEmpty(target.Date.ToString()))
                {
                    Write($"    {target.Status}");
                }

                WriteLine();
            }

            ReadKey(true);

        }

        private static void AddTarget()
        {
            Console.WriteLine("Coordinat x: ");
            int coordinateX = Convert.ToInt32(ReadLine());
            Console.WriteLine("Coordinat y: ");
            int coordinateY = Convert.ToInt32(ReadLine());
            Console.WriteLine("Coordinat z: ");
            int coordinateZ = Convert.ToInt32(ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();

            Target target = new Target(coordinateX, coordinateY, coordinateZ, name, description);
            context.Target.Add(target);
            context.SaveChanges();

        }
    }
}
