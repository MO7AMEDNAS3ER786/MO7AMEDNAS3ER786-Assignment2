using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Simple Console Calculator ===");

            bool keepGoing = true;
            while (keepGoing)
            {
                double num1 = ReadNumber("Enter the first number: ");
                double num2 = ReadNumber("Enter the second number: ");
                char op = ReadOperator();

                double? result = Calculate(num1, num2, op);

                if (result.HasValue)
                {
                    Console.WriteLine($"Result: {num1} {op} {num2} = {result.Value}");
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }

                Console.Write("Do you want to perform another calculation? (y/n): ");
                string answer = Console.ReadLine()?.Trim().ToLower();
                keepGoing = answer == "y" || answer == "yes";
                Console.WriteLine();
            }

            Console.WriteLine("Goodbye!");
        }

        static double ReadNumber(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static char ReadOperator()
        {
            while (true)
            {
                Console.Write("Choose operation (+, -, *, /): ");
                string input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(input) && "+-*/".Contains(input[0]) && input.Length == 1)
                {
                    return input[0];
                }
                Console.WriteLine("Invalid operator. Please enter one of + - * /");
            }
        }

        static double? Calculate(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/':
                    if (b == 0) return null;
                    return a / b;
                default: throw new InvalidOperationException("Unknown operator");
            }
        }
    }
}
