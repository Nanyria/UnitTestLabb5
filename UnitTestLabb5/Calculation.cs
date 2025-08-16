using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLabb5
{
    public class Calculation
    {
        public double Number1 { get; }
        public double Number2 { get; }
        public string Operator { get; }
        public double Result { get; }

        public Calculation(double number1, double number2, string op, double result)
        {
            Number1 = number1;
            Number2 = number2;
            Operator = op;
            Result = result;
        }

        public override string ToString()
        {
            return $"{Number1} {Operator} {Number2} = {Result}";
        }
    }
  }
