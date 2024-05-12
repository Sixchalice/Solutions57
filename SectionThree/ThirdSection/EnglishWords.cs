using System.Text;

namespace MyApp {
    class EnglishWords : IWords {
        private string[] magnitudes = {"Hundred ", "Thousand ", "Million ",
            "Billion ", "Trillion "
        };
        private string[] units = {"", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ",
            "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
            "Seventeen ", "Eighteen ", "Nineteen ",
        };
        private string[] tens = {"", "Ten", "Twenty ", "Thirty ", "Forty ",
            "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };
        public string ToWords(long n)
        {
            // To add more than Trillions, you can add more strings to the array.
            StringBuilder sentence = new StringBuilder("");
            int magnitudeCount = 0;
            long num = n;
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
                stringBuilder.Append(magnitudes[0]);
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
                stringBuilder.Append(magnitudes[magnitudeCount]);
            return stringBuilder;
        }
    }
}