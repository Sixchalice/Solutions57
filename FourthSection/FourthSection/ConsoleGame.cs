using FourthSection;

class ConsoleGame
{
    private Game game;

    public ConsoleGame() {
        game = new Game();
    }
    public void StartGame() {
        ConsoleKeyInfo keyInfo;
        System.Console.WriteLine("Welcome, Press they keys W A S and D in order to move.");
        while(game.status == GameStatus.Idle) {

            keyInfo = Console.ReadKey();
            Console.Clear();
            System.Console.WriteLine("Game Status: " + game.status);
            System.Console.WriteLine("Points: " + game.points);
            System.Console.WriteLine();
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    game.Move(Direction.Up);
                    break;

                case ConsoleKey.A:
                    game.Move(Direction.Left);
                    break;

                case ConsoleKey.S:
                    game.Move(Direction.Down);
                    break;
                
                case ConsoleKey.D:
                    game.Move(Direction.Right);
                    break;
                
                default:
                    System.Console.WriteLine("Wrong input. W A S and D only!");
                    break;
            }
            game.PrintBoard();
        }
        if(game.status == GameStatus.Lose) {
            Console.Clear();
            System.Console.WriteLine("YOU LOSE!!!");
            System.Console.WriteLine("Points: " + game.points);
        }
        else if(game.status == GameStatus.Win) {
            Console.Clear();
            System.Console.WriteLine("YOU WIN!!!!");
            System.Console.WriteLine("Points: " + game.points);
        }
    }
}