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

            if(game.status != GameStatus.Idle) {
                break;
            }
            DoMove(key);
            Console.ReadKey(false);
        }
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
                break;
                
            case ConsoleKey.D:
                game.board.Move(Direction.Right);
                break;
        }
        game.PrintBoard();
    }
}