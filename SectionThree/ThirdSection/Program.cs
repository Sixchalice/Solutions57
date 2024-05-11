using System;
using System.Text;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            In order to change the language of the NumericalExpression, 
            You can make a new class that implements the interface IWords and call the method ChangeLanguage.
            */
            NumericalExpression NumEx = new NumericalExpression(123456789123);
            Console.WriteLine(NumEx);
        }
    }
}