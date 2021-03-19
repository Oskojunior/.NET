using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fizz();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Fizz()
        {
            int number;
            Console.WriteLine("Write a number:");
            Console.WriteLine("\n");
            if (!(int.TryParse(Console.ReadLine(), out number)))
            {
                throw new Exception("The data is invalid!");
            }
            if (number % 3 == 0 && number % 5 == 0)
                Console.WriteLine("fizzbuzz");
            else if (number % 3 == 0)
                Console.Write("fizz");
            else if (number % 5 == 0)
                Console.Write("buzz");
            else
                Console.WriteLine(number);
        }
    }
}
