using FourthSection;

class ConsoleGame
{
    private Game game;

    public ConsoleGame() {
        game = new Game();
    }
    public void StartGame() {
        ConsoleKey key = Console.ReadKey().Key;
        while(true) {
            System.Console.WriteLine("Game Status: " + game.status);
            System.Console.WriteLine("Points: " + game.points);
            if(game.status != GameStatus.Idle) {
                break;
            }
            DoMove(key);
            Console.ReadKey(false);
        }
        
        // game.PrintBoard();
        // game.Move(Direction.Down);
        // game.PrintBoard();
        // game.Move(Direction.Left);
        // game.PrintBoard();
        // game.Move(Direction.Right);
        // game.PrintBoard();
        // game.Move(Direction.Up);
        // game.PrintBoard();
    }
    private void DoMove(ConsoleKey key) 
    {
        switch (key)
        {
            case ConsoleKey.W:
                game.board.Move(Direction.Up);
                break;
                
            case ConsoleKey.A:
                game.board.Move(Direction.Left);
                break;

            case ConsoleKey.S:
                game.board.Move(Direction.Down);
                System.Console.WriteLine("MOVED DOWN");
                break;
                
            case ConsoleKey.D:
                game.board.Move(Direction.Right);
                break;
        }
        game.PrintBoard();
    }
}