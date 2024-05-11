using System;
using System.Text;
namespace MyApp
{
    class NumericalExpression
    {
        private StringBuilder sentence = new StringBuilder("");
        private long number;

        private string[] units = {"", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ",
            "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
            "Seventeen ", "Eighteen ", "Nineteen ",
        };

        private string[] tens = {"", "Ten", "Twenty ", "Thirty ", "Forty ",
            "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };

        // To add more than Trillions, you can add more strings to the array.
        private string[] magnitude = {"", "Hundred ", "Thousand ", "Million ",
            "Billion ", "Trillion "
        };

        public NumericalExpression(long n)
        {
            number = n;
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
                StringBuilder ss = GroupOfThree(threeDigits, magnitudeCount);
                if (magnitudeCount == 0)
                    magnitudeCount++;

                magnitudeCount++;

                sentence.Insert(0, ss.ToString());
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
                stringBuilder.Append(magnitude[1]);
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
            stringBuilder.Append(magnitude[magnitudeCount]);
            return stringBuilder;
        }

        public long GetAmountOfLetters()
        {
            if (sentence.Length == 0)
            {
                GetSentence();
            }
            return sentence.ToString().Replace(" ", "").Length;
        }
        public static long SumLetters(long n)
        {
            long sumOfLetters = 0;
            for (long i = 1; i <= n; i++)
            {
                NumericalExpression NumEx = new NumericalExpression(i);
                sumOfLetters += NumEx.GetAmountOfLetters();
            }
            return sumOfLetters;
        }
        // This is overloading. Overloading is when you have 2 methods with the same name,
        // but different parameters. Ex: long n for the first method, and for the second an NumericalExpression object.
        public static long SumLetters(NumericalExpression NumEx)
        {
            long sumOfLetters = 0;
            for (long i = 1; i <= NumEx.GetValue(); i++)
            {
                NumericalExpression temp = new NumericalExpression(i);
                sumOfLetters += temp.GetAmountOfLetters();
            }
            return sumOfLetters;
        }



        public override string ToString()
        {
            return GetSentence();
        }
    }
}