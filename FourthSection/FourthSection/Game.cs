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
        if(status != GameStatus.Idle) {
            return;
        }

        points += board.Move(direction);


        CheckWin();
        // bool lost = board.CheckLose();
        // if(lost) {
        //     status = GameStatus.Lose;
        // }
    }

    private void CheckWin() { 
        // Go over the board, check if there is a tile with the number 2048. If so, the player won.               
        for(int row = 0; row < 4; row++) {
            for(int col = 0; col < 4; col++) {
                int val = this.board.Data[row,col];
                if(val == 2048)
                    this.status = GameStatus.Win;
            }
        }
    }

    public void PrintBoard() {
        Console.Clear();
            for(int row = 0; row < 4; row++) {
                for(int col = 0; col < 4; col++) {
                    int val = this.board.Data[row, col];
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if(val < 10) {
                        if(val == 0) {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        System.Console.Write(val + "    | ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
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