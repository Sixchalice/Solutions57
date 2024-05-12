using System;
using System.Text;
namespace MyApp
{
    class NumericalExpression
    {
        private StringBuilder sentence = new StringBuilder("");
        private long number;

        // This is the default language
        private IWords language = new EnglishWords();
        
        private string[] units;
        private string[] tens;
        private string[] magnitude;
        public NumericalExpression(long n)
        {
            this.number = n;
            units = language.getUnits();
            tens = language.getTens();
            magnitude = language.getMagnitudes();
        }
        public NumericalExpression(long n, IWords language)
        {
            this.number = n;
            this.language = language;
            units = language.getUnits();
            tens = language.getTens();
            magnitude = language.getMagnitudes();
        }
        public void ChangeLanguage(IWords language)
        {
            this.language = language;
            units = language.getUnits();
            tens = language.getTens();
            magnitude = language.getMagnitudes();
        }

        public long GetValue()
        {
            return number;
        }

        public string GetSentence()
        {
            int magnitudeCount = 0;
            long num = number;
            while (num > 0)
            {
                int threeDigits = (int)(num % 1000);
                StringBuilder currentThree = GroupOfThree(threeDigits, magnitudeCount);
                magnitudeCount++;

                sentence.Insert(0, currentThree.ToString());
                num = num / 1000;
            }
            return sentence.ToString();
        }

        private StringBuilder GroupOfThree(int n, int magnitudeCount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int ones = n % 10;
            int ten = n / 10 % 10;
            int hund = n / 100;


            if(hund > 0)
            {
                stringBuilder.Append(units[hund]);
                stringBuilder.Append(magnitude[0]);
            }

            if (ten == 1)
            {
                string ten_one = ten.ToString() + ones.ToString();
                stringBuilder.Append(units[Int32.Parse(ten_one)]);
            }
            else if (ten == 0)
            {
                stringBuilder.Append(units[ones]);
            }
            else
            {
                stringBuilder.Append(tens[ten]);
                stringBuilder.Append(units[ones]);

            }
            if(magnitudeCount > 0)
                stringBuilder.Append(magnitude[magnitudeCount]);
            return stringBuilder;

            // int onesIndex = ones - 1;
            // int tenIndex = ten - 1;
            // int hundIndex = hund - 1;
            // if(hund > 0)
            // {
            //     stringBuilder.Append(units[hundIndex]);
            //     stringBuilder.Append(magnitude[0]);
            // }

            // if (ten == 1)
            // {
            //     string tenPlusOne = ten.ToString() + ones.ToString();
            //     int tenPlusOneIndex = Int32.Parse(tenPlusOne) - 1;
            //     stringBuilder.Append(units[tenPlusOneIndex]);
            // }
            // else if (ten == 0)
            // {
            //     stringBuilder.Append(units[onesIndex]);
            // }
            // else
            // {
            //     stringBuilder.Append(tens[tenIndex]);
            //     stringBuilder.Append(units[onesIndex]);
            // }
            // if(magnitudeCount > 0){
            //     stringBuilder.Append(magnitude[magnitudeCount]);
            // }
            // return stringBuilder;
        }

        public long GetAmountOfLetters()
        {
            if (sentence.Length == 0)
            {
                GetSentence();
            }
            return sentence.ToString().Replace(" ", "").Length;
        }
        public static long SumLetters(long n, IWords language)
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
                NumericalExpression temp = new NumericalExpression(i, NumEx.GetLanguage());
                sumOfLetters += temp.GetAmountOfLetters();
            }
            return sumOfLetters;
        }

        private IWords GetLanguage()
        {
            return language;
        }

        public override string ToString()
        {
            return GetSentence();
        }
    }
}