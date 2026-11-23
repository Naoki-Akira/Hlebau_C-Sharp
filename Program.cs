using System;
using System.Globalization;

class Program {
    public static void Main(string[] args) {
        double num;
        while (true)
        {
            try
            {
                Console.Write("Please, enter a number: ");
                num = Convert.ToDouble(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number: ");
            }
        }
        if (num > 7)
            Console.WriteLine("Hello");
        else
            Console.WriteLine($"The number {num} is not greater than 7.");
        Console.Write("Please, enter your name: ");
        string? name = Console.ReadLine();
        if (name?.ToLower() == "john")
            Console.WriteLine("Hello, John");
        else
            Console.WriteLine("There is no such name.");
        while (true)
        {
            Console.Write("Please, enter a numeric array separated by spaces or commas: ");
            var arrStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(arrStr))
            {
                Console.WriteLine("The array is empty");
                continue;
            }
            try
            {
                    var multiples = arrStr.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                          .Select(s => double.Parse(s, CultureInfo.InvariantCulture))
                                          .Where(n => double.IsFinite(n) && n % 3 == 0)
                                          .ToArray();
                    if (multiples.Length == 0)
                    {
                        Console.WriteLine("None of given numbers is a multiple of 3.");
                        break;
                    }
                    Console.WriteLine("These given numbers are multiples of 3.");
                    Console.WriteLine(string.Join(" ", multiples));
                    break; 
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format. Make sure every entry is a number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("One of the numbers is too large for a double.");
            }
        }
    } 
}