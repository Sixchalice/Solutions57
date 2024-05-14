using FourthSection;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ConsoleGame cg = new ConsoleGame();
            cg.StartGame();
        }

        public static void Print(int[,] board) {
            for(int row = 0; row < 4; row++) {
                for(int col = 0; col < 4; col++) {
                    int val = board[row, col];
                    if(val < 10)
                        System.Console.Write(val + "    | ");
                    else if(val < 100) 
                        System.Console.Write(val + "   | ");
                    else if (val < 1000)
                        System.Console.Write(val + "  | ");
                    else {
                        System.Console.Write(val + " | ");
                    }
                }
                System.Console.WriteLine("\n_________________________________");
            }
        }
    }
}