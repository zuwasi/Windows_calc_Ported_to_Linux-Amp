using System;

namespace LinuxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   Linux Cross-Platform Calculator       ║");
            Console.WriteLine("║   Ported from Windows Calculator         ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine();

            var calculator = new Calculator();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Calculator Menu ===");
                Console.WriteLine("1. Basic Operations (+, -, *, /)");
                Console.WriteLine("2. Scientific Functions");
                Console.WriteLine("3. Memory Operations");
                Console.WriteLine("4. Expression Evaluator");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect option (1-5): ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            BasicOperations(calculator);
                            break;
                        case "2":
                            ScientificOperations(calculator);
                            break;
                        case "3":
                            MemoryOperations(calculator);
                            break;
                        case "4":
                            ExpressionEvaluator(calculator);
                            break;
                        case "5":
                            running = false;
                            Console.WriteLine("\nThank you for using Linux Calculator!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void BasicOperations(Calculator calc)
        {
            Console.Write("\nEnter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter operation (+, -, *, /): ");
            string op = Console.ReadLine();

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            double result = op switch
            {
                "+" => calc.Add(num1, num2),
                "-" => calc.Subtract(num1, num2),
                "*" => calc.Multiply(num1, num2),
                "/" => calc.Divide(num1, num2),
                _ => throw new ArgumentException("Invalid operation")
            };

            Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");
            calc.SaveToHistory(result);
        }

        static void ScientificOperations(Calculator calc)
        {
            Console.WriteLine("\n=== Scientific Functions ===");
            Console.WriteLine("1. Square Root");
            Console.WriteLine("2. Power (x^y)");
            Console.WriteLine("3. Trigonometry (Sin/Cos/Tan)");
            Console.WriteLine("4. Logarithm (log10)");
            Console.WriteLine("5. Natural Log (ln)");
            Console.WriteLine("6. Factorial");
            Console.Write("\nSelect function (1-6): ");

            string choice = Console.ReadLine();
            double result = 0;

            switch (choice)
            {
                case "1":
                    Console.Write("Enter number: ");
                    double num = double.Parse(Console.ReadLine());
                    result = calc.SquareRoot(num);
                    Console.WriteLine($"\n√{num} = {result}");
                    break;

                case "2":
                    Console.Write("Enter base: ");
                    double baseNum = double.Parse(Console.ReadLine());
                    Console.Write("Enter exponent: ");
                    double exp = double.Parse(Console.ReadLine());
                    result = calc.Power(baseNum, exp);
                    Console.WriteLine($"\n{baseNum}^{exp} = {result}");
                    break;

                case "3":
                    Console.Write("Enter angle (degrees): ");
                    double angle = double.Parse(Console.ReadLine());
                    Console.Write("Function (sin/cos/tan): ");
                    string func = Console.ReadLine().ToLower();
                    result = func switch
                    {
                        "sin" => calc.Sine(angle),
                        "cos" => calc.Cosine(angle),
                        "tan" => calc.Tangent(angle),
                        _ => throw new ArgumentException("Invalid function")
                    };
                    Console.WriteLine($"\n{func}({angle}°) = {result}");
                    break;

                case "4":
                    Console.Write("Enter number: ");
                    double logNum = double.Parse(Console.ReadLine());
                    result = calc.Logarithm(logNum);
                    Console.WriteLine($"\nlog10({logNum}) = {result}");
                    break;

                case "5":
                    Console.Write("Enter number: ");
                    double lnNum = double.Parse(Console.ReadLine());
                    result = calc.NaturalLog(lnNum);
                    Console.WriteLine($"\nln({lnNum}) = {result}");
                    break;

                case "6":
                    Console.Write("Enter positive integer: ");
                    int factNum = int.Parse(Console.ReadLine());
                    result = calc.Factorial(factNum);
                    Console.WriteLine($"\n{factNum}! = {result}");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            calc.SaveToHistory(result);
        }

        static void MemoryOperations(Calculator calc)
        {
            Console.WriteLine("\n=== Memory Operations ===");
            Console.WriteLine("1. Store in Memory (MS)");
            Console.WriteLine("2. Recall Memory (MR)");
            Console.WriteLine("3. Add to Memory (M+)");
            Console.WriteLine("4. Subtract from Memory (M-)");
            Console.WriteLine("5. Clear Memory (MC)");
            Console.Write("\nSelect option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter value to store: ");
                    double value = double.Parse(Console.ReadLine());
                    calc.MemoryStore(value);
                    Console.WriteLine($"Stored {value} in memory");
                    break;

                case "2":
                    double recalled = calc.MemoryRecall();
                    Console.WriteLine($"Memory contains: {recalled}");
                    break;

                case "3":
                    Console.Write("Enter value to add: ");
                    double addVal = double.Parse(Console.ReadLine());
                    calc.MemoryAdd(addVal);
                    Console.WriteLine($"Added {addVal} to memory. New value: {calc.MemoryRecall()}");
                    break;

                case "4":
                    Console.Write("Enter value to subtract: ");
                    double subVal = double.Parse(Console.ReadLine());
                    calc.MemorySubtract(subVal);
                    Console.WriteLine($"Subtracted {subVal} from memory. New value: {calc.MemoryRecall()}");
                    break;

                case "5":
                    calc.MemoryClear();
                    Console.WriteLine("Memory cleared");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ExpressionEvaluator(Calculator calc)
        {
            Console.WriteLine("\n=== Expression Evaluator ===");
            Console.WriteLine("Enter a simple expression (e.g., 5 + 3 * 2)");
            Console.Write("Expression: ");
            string expr = Console.ReadLine();

            try
            {
                var result = EvaluateExpression(expr, calc);
                Console.WriteLine($"\nResult: {expr} = {result}");
                calc.SaveToHistory(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating expression: {ex.Message}");
            }
        }

        static double EvaluateExpression(string expression, Calculator calc)
        {
            var dt = new System.Data.DataTable();
            var result = dt.Compute(expression, "");
            return Convert.ToDouble(result);
        }
    }
}
