using System;
using System.Collections.Generic;

namespace LinuxCalculator
{
    public class Calculator
    {
        private double _memory = 0;
        private Stack<double> _history = new Stack<double>();

        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return a / b;
        }

        public double Power(double baseNum, double exponent) => Math.Pow(baseNum, exponent);
        public double SquareRoot(double num)
        {
            if (num < 0)
                throw new ArgumentException("Cannot calculate square root of negative number");
            return Math.Sqrt(num);
        }

        public double Sine(double angle) => Math.Sin(angle * Math.PI / 180);
        public double Cosine(double angle) => Math.Cos(angle * Math.PI / 180);
        public double Tangent(double angle) => Math.Tan(angle * Math.PI / 180);

        public double Logarithm(double num)
        {
            if (num <= 0)
                throw new ArgumentException("Logarithm undefined for non-positive numbers");
            return Math.Log10(num);
        }

        public double NaturalLog(double num)
        {
            if (num <= 0)
                throw new ArgumentException("Natural logarithm undefined for non-positive numbers");
            return Math.Log(num);
        }

        public double Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Factorial undefined for negative numbers");
            if (n == 0 || n == 1)
                return 1;
            
            double result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        public void MemoryStore(double value) => _memory = value;
        public void MemoryAdd(double value) => _memory += value;
        public void MemorySubtract(double value) => _memory -= value;
        public double MemoryRecall() => _memory;
        public void MemoryClear() => _memory = 0;

        public void SaveToHistory(double value) => _history.Push(value);
        public double GetLastHistory() => _history.Count > 0 ? _history.Peek() : 0;
        public void ClearHistory() => _history.Clear();
    }
}
