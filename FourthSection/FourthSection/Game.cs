using FourthSection;

class Game
{
    public Board board {get; }
    public GameStatus status {get; }
    public int points {get; protected set; }
    
    public Game() {
        board = new Board();
        status = GameStatus.Idle;
        points = 0;
    }

    public void Move(Direction direction) {
        if(status == GameStatus.Lose) {
            return;
        }
        board.Move(direction);
        if(status != GameStatus.Idle) {
            return;
        }
        points = board.points;
    }

    public void PrintBoard() {
        Console.Clear();
        for(int row = 0; row < 4; row++) {
            for(int col = 0; col < 4; col++) {
                int val = board.Data[row, col];
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
            System.Console.WriteLine("_________________________________");
        }
    }
}