using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLabb5;

namespace UnitTestLabb5
{
    public class Run
    {
        private readonly Calculator _calculator = new();

        public void Start()
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("Välj räknesätt (+, -, *, /) eller skriv 'history' för att se tidigare uträkningar, eller 'exit' för att avsluta:");
                string choice = Console.ReadLine()?.Trim();

                if (choice == "exit")
                {
                    run = false;
                    continue;
                }

                if (choice == "history")
                {
                    Console.WriteLine("Tidigare uträkningar:");
                    foreach (var calc in _calculator.GetHistory())
                    {
                        Console.WriteLine(calc);
                    }
                    Console.WriteLine();
                    continue;
                }

                Console.Write("Ange första talet: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Felaktig inmatning!");
                    continue;
                }

                Console.Write("Ange andra talet: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Felaktig inmatning!");
                    continue;
                }

                try
                {
                    var calculation = _calculator.PerformCalculation(num1, num2, choice);
                    Console.WriteLine($"Resultat: {calculation.Result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}


