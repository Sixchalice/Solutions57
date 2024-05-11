namespace MyApp {
    class EnglishWords : IWords {
        
        private string[] units = {"One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ",
        "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ",
        "Seventeen ", "Eighteen ", "Nineteen ",
        };

        private string[] tens = {"Ten", "Twenty ", "Thirty ", "Forty ",
            "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety "
        };

        // To add more than Trillions, you can add more strings to the array.
        private string[] magnitudes = {"Hundred ", "Thousand ", "Million ",
            "Billion ", "Trillion "
        };

        public string[] getUnits()
        {   
            return units;
        }
        public string[] getTens()
        {
            return tens;
        }
        public string[] getMagnitudes()
        {
            return magnitudes;
        }
    }
}