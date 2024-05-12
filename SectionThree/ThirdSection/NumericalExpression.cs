using System;
using System.Text;
namespace MyApp
{
    class NumericalExpression
    {
        private long number;
        private Func<long, string> ToWords;
        public NumericalExpression(long n)
        {
            this.number = n;
            // If the language is not declared, defaults to english
            this.ToWords = new EnglishWords().ToWords;
        }
        public NumericalExpression(long n, Func<long, string> func)
        {
            this.number = n;
            this.ToWords = func;
        }
        public void ChangeLanguage(Func<long, string> newLanguageFunc)
        {
            ToWords = newLanguageFunc;
        }

        public long GetValue()
        {
            return number;
        }
        public long GetAmountOfLetters()
        {
            return ToWords(number).Length;
        }
        public static long SumLetters(long n, Func<long, string> language)
        {
            long sumOfLetters = 0;
            for (long i = 1; i <= n; i++)
            {
                NumericalExpression NumEx = new NumericalExpression(i, language);
                sumOfLetters += NumEx.GetAmountOfLetters();
            }
            return sumOfLetters;
        }
        /*
        This is overloading. Overloading is when you have 2 methods with the same name / return the same result, but have different parameters.
        Ex: long n for the first method, and for the second a NumericalExpression object.
        */
        public static long SumLetters(NumericalExpression NumEx)
        {
            long sumOfLetters = 0;
            long n = NumEx.GetValue();
            for (long i = 1; i <= n; i++)
            {
                NumericalExpression temp = new NumericalExpression(i, NumEx.GetToWords());
                sumOfLetters += temp.GetAmountOfLetters();
            }
            return sumOfLetters;
        }
        public Func<long, string> GetToWords()
        {
            return ToWords;
        }
        public override string ToString()
        {
            return ToWords(number);
        }
    }
}