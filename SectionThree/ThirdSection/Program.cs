using System;
using System.Text;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            NumericalExpression NumEx = new NumericalExpression(4, new EnglishWords().ToWords);
            Console.WriteLine(NumericalExpression.SumLetters(NumEx));
            // To Change language create a new class that implements IWords.
            // NumericalExpression SpanishNumEx = new NumericalExpression(4, new SpanishWords().ToWords);
        }
    }
}