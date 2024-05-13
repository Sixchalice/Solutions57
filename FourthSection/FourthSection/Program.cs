using FourthSection;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.StartGame();
            System.Console.WriteLine("Initial Board: ");
            
            Print(board.Data);

            System.Console.WriteLine("After moving Down: ");
            board.Move(Direction.Down);

            Print(board.Data);

            System.Console.WriteLine("After moving Up: ");
            board.Move(Direction.Up);

            Print(board.Data);

            System.Console.WriteLine("After moving Up: ");
            board.Move(Direction.Up);

            Print(board.Data);
        }

        public static void Print(int[,] arr) {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    System.Console.Write(arr[i, j] + " ");
                }
                System.Console.WriteLine();
            }
        }
    }
}