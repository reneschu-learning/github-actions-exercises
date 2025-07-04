using System;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Sample Application!");
            
            var calculator = new Calculator();
            
            // Demonstrate some basic operations
            Console.WriteLine($"Addition: 5 + 3 = {calculator.Add(5, 3)}");
            Console.WriteLine($"Subtraction: 10 - 4 = {calculator.Subtract(10, 4)}");
            Console.WriteLine($"Multiplication: 6 * 7 = {calculator.Multiply(6, 7)}");
            Console.WriteLine($"Division: 15 / 3 = {calculator.Divide(15, 3)}");
            
            // Handle command line arguments
            if (args.Length > 0)
            {
                Console.WriteLine($"Command line arguments received: {string.Join(", ", args)}");
            }
            
            Console.WriteLine("Application completed successfully!");
        }
    }
}
