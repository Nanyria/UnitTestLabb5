using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLabb5
{
    public class Calculator
    {
        private readonly List<Calculation> _history = new();

        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Division med noll är inte tillåten.");
            return a / b;
        }

        public Calculation PerformCalculation(double a, double b, string op)
        {
            double result = op switch
            {
                "+" => Add(a, b),
                "-" => Subtract(a, b),
                "*" => Multiply(a, b),
                "/" => Divide(a, b),
                _ => throw new ArgumentException("Ogiltigt räknesätt.")
            };

            var calc = new Calculation(a, b, op, result);
            _history.Add(calc);
            return calc;
        }

        public List<Calculation> GetHistory()
        {
            return _history;
        }
    }
}
