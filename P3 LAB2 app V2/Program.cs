using System;
using System.Threading;

namespace P3_LAB2_app
{
    class Program
    {
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
                test1();
                Console.Write("Nacisnij ESC aby zatrzymać.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static void test1()
        {
            Wynik nZeroRoots = 0;
            try
            {
                Tuple<double, double, double> abc = ReadData();
                double a = abc.Item1;
                double b = abc.Item2;
                double c = abc.Item3;
                double delta = Delta(abc);
                CheckDelta(ref nZeroRoots, delta);
                Roots(abc, nZeroRoots, delta);
            }
            catch (FormatException)
            {
                Console.WriteLine("Podaj poprawne liczby");
            }
        }
        static Tuple<double, double, double> ReadData()
        {
            Console.Write("Podaj a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Podaj b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Podaj c: ");
            double c = double.Parse(Console.ReadLine());
            return Tuple.Create(a, b, c);
        }
        static double Delta(Tuple<double, double, double> zmiennaABC)
        {
            double delta;
            delta = Math.Pow(zmiennaABC.Item2, 2) - 4 * zmiennaABC.Item1 * zmiennaABC.Item3;
            Console.WriteLine($"Delta = {delta,3:N3}");
            return delta;
        }
        static void CheckDelta(ref Wynik value, double delta)
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
        static void Roots(Tuple<double, double, double> zmiennaABC, Wynik nZeroRoots, double delta)
        {
            switch (nZeroRoots)
            {
                case Wynik.JednoMiejsceZerowe:
                    {
                        Console.WriteLine("Jedno miejsce zerowe: ");
                        double xZero = (-zmiennaABC.Item2 / (2 * zmiennaABC.Item1));
                        Console.WriteLine($"X_0 = {xZero}");
                        break;
                    }
                case Wynik.DwaMiejscaZerowe:
                    {
                        Console.WriteLine("Dwa miejsca zerowe: ");
                        double xOne = ((-zmiennaABC.Item2 + Math.Sqrt(delta)) / (2 * zmiennaABC.Item1));
                        double xTwo = ((-zmiennaABC.Item2 - Math.Sqrt(delta)) / (2 * zmiennaABC.Item1));
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
    }
}