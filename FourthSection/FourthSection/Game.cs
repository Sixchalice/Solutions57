using FourthSection;

class Game
{
    public Board board {get; }
    public GameStatus status {get; protected set; }
    public int points {get; protected set; }
    
    public Game() {
        board = new Board();
        board.StartGame();
        status = GameStatus.Idle;
        points = 0;
    }

    public void Move(Direction direction) {
        if(status == GameStatus.Lose) {
            return;
        }
        board.Move(direction);
        // if(prevBoardData == board.Data) {

        // }
        if(status != GameStatus.Idle) {
            return;
        }
        // CheckWin();
        // CheckLose();
    }

    private void CheckWin() {                
        if(this.points == board.points - 2048) {
            points = board.points;
            this.status = GameStatus.Win;
        }
    }
    private void CheckLose() {
        // Copy all the current moves to a new temporary board.
        int[,] prevBoardData = new int[4,4];
        prevBoardData = board.Data;
        Board tempBoard = new Board(prevBoardData);
        
        // Call upon all 4 directions, then check if the temp board is different.
        // If it isn't, the player lost.
        foreach (Direction dir in Enum.GetValues<Direction>())
        {
            tempBoard.Move(dir);
        }
        if(tempBoard.Data == board.Data) {
            this.status = GameStatus.Lose;
        }
    }

    public void PrintBoard() {
        Console.Clear();
        for(int i = 0; i < 4; i++) {
            for(int j = 0; j < 4; j++) {
                System.Console.Write(board.Data[i,j] + " ");
            }
            System.Console.WriteLine();

        // for(int row = 0; row < 4; row++) {
        //     for(int col = 0; col < 4; col++) {
        //         int val = this.board.Data[row, col];
        //         if(val < 10)
        //             System.Console.Write(val + "    | ");
        //         else if(val < 100) 
        //             System.Console.Write(val + "   | ");
        //         else if (val < 1000)
        //             System.Console.Write(val + "  | ");
        //         else {
        //             System.Console.Write(val + " | ");
        //         }
        //     }
        //     System.Console.WriteLine("\n____________________________");
        }
    }
}