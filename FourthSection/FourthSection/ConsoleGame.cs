using FourthSection;

class ConsoleGame
{
    private Game game;

    public ConsoleGame() {
        game = new Game();
    }
    public void StartGame() {
        ConsoleKeyInfo keyInfo;
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
            }
            game.PrintBoard();
            // Console.ReadKey(false);
        }
        if(game.status == GameStatus.Lose) {
            Console.Clear();
            System.Console.WriteLine("YOU LOSE!!!");
        }
    }
}