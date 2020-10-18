using System;
using System.Threading;

namespace P3_LAB2_app
{
    class Program
    {
        static double a;
        static double b;
        static double c;
        static double delta;

        static Wynik nZeroRoots;
        enum Wynik
        {
            JednoMiejsceZerowe,
            DwaMiejscaZerowe,
            BrakMiejscZerowych
        };

        static void Main(string[] args)
        {

            do
            {
                try
                {
                    ReadData();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Podaj poprawne liczby");
                }
                Delta();
                CheckDelta(ref nZeroRoots);
                Roots();
                Console.Write("Nacisnij ESC aby zatrzymać.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            static void CheckDelta(ref Wynik value)
            {
                if (delta < 0)
                {
                    value = Wynik.BrakMiejscZerowych;
                }
                else if (delta == 0)
                {
                    value = Wynik.JednoMiejsceZerowe;
                }
                else if (delta > 0)
                {
                    value = Wynik.DwaMiejscaZerowe;
                }
            }
        }

        static void Roots()
        {
            switch (nZeroRoots)
            {
                case Wynik.JednoMiejsceZerowe:
                    {
                        Console.WriteLine("Jedno miejsce zerowe: ");
                        double xZero = (-b / (2 * a));
                        Console.WriteLine($"X_0 = {xZero}");
                        break;
                    }
                case Wynik.DwaMiejscaZerowe:
                    {
                        Console.WriteLine("Dwa miejsca zerowe: ");
                        double xOne = ((-b + Math.Sqrt(delta)) / (2 * a));
                        double xTwo = ((-b - Math.Sqrt(delta)) / (2 * a));
                        Console.WriteLine($"X_1 = {xOne,3:N3}");
                        Console.WriteLine($"X_2 = {xTwo,3:N3}");
                        break;
                    }
                case Wynik.BrakMiejscZerowych:
                    {
                        Console.WriteLine($"Brak miejsc zerowych delta = {delta}, mniejsza od 0. ");
                        break;
                    }
            }
        }

        static void ReadData()
        {
            Console.Write("Podaj a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Podaj b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Podaj c: ");
            c = double.Parse(Console.ReadLine());
        }

        static void Delta()
        {
            delta = Math.Pow(b, 2) - 4 * a * c;
            Console.WriteLine($"Delta = {delta,3:N3}");
        }
    }
}