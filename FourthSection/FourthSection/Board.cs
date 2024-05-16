using System;
namespace FourthSection
{
	public class Board
	{
		public int[,] Data { get; protected set; } = new int[4, 4];

		public Board(int[,] arr) {
			this.Data = arr;
		}
		public Board() {}
		
		public int[,] StartGame()
		{
			// Make 2 tiles 2 or 4 for the beginning of the game.
			for (int i = 0; i < 2; i++)
			{
				int row = new Random().Next(0, 4);
				int col = new Random().Next(0, 4);
				int val = new Random().Next(0,2) == 0 ? 2 : 4;

				Data.SetValue(val,row,col);				
			}
			return Data;
		}
		public int Move(Direction direction)
		{
			// Move the tiles in the direction given.
			// If there is a tile with the same value, merge them.
			// Generate a 2 or a 4 in a random available tile. 

			int currPoints = 0;
			switch (direction)
			{
				case Direction.Right:
					currPoints = MergeRight();
					System.Console.WriteLine("MOVED RIGHT");
					break;

				case Direction.Left:
					currPoints = MergeLeft();
					System.Console.WriteLine("MOVED LEFT");
					break;

				case Direction.Up:
					currPoints = MergeUp();
					System.Console.WriteLine("MOVED UP");
					break;

				case Direction.Down:
					currPoints = MergeDown();
					System.Console.WriteLine("MOVED DOWN");
					break;
			}
			return currPoints;
		}

		private int MergeRight() {
			MoveRight();
			// In the game, if all the tiles are on the right side and the player moves to the right, nothing happens.
			// this boolean variable makes sure nothing moved, to make sure that a new number isnt generated onto the board.
			bool happened = false;
			int points = 0;
			for(int row = 0; row < 4; row++) {
				for(int col = 3; col > 0; col--) {
					int nextCol = col - 1; // Next column from right to left
					if(Data[row, col] == Data[row, nextCol]) {
						Data[row,col] = Data[row, col] * 2;
						Data[row,nextCol] = 0;
						points = Data[row,col];
						happened = true;
					}
				}
			}
			MoveRight();
			if(happened)
				GenerateNumberAfterTurn();
			return points;
		}
		private void MoveRight() {
			for(int row = 0; row < 4; row++) {
				int lastIndex = -1;
				for(int col = 3; col >= 0; col--) {
					for(int k = 0; k < 4; k++) {
						if(Data[row,k] == 0) {
							lastIndex = k;
						}
					}
					if(lastIndex == 0) {
						continue;
					}
					if(lastIndex != -1) {
						if(lastIndex > col) {
							if(Data[row,col] != 0) {
								Data[row, lastIndex] = Data[row, col];
								Data[row,col] = 0;
							}
						}
					}
				}
			}
		}

		private int MergeLeft() {
			MoveLeft();
			bool happened = false;
			int points = 0;
			for(int row = 0; row < 4; row++) {
				for(int col = 0; col < 3; col++) {
					int nextCol = col + 1;
					if(Data[row,col] == Data[row,nextCol]) {
						Data[row,col] = Data[row,col] * 2;
						Data[row,nextCol] = 0;
						points = Data[row,col];
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveLeft();
			return points;
		}
		private void MoveLeft()
		{
			for(int row = 0; row < 4; row++) {
				int firstIndex = -1;
				for(int col = 1; col < 4; col++) {
					for(int k = 3; k >= 0; k--) {
						if(Data[row,k] == 0) {
							firstIndex = k;
						}
					}
					if(firstIndex == 3)
						continue;
					if(firstIndex != -1) {
						Data[row, firstIndex] = Data[row,col];
						Data[row,col] = 0;
					}
				}
			}
		}

		private int MergeUp() {
			MoveUp();
			bool happened = false;
			int points = 0;
			for(int row = 0; row < 3; row++) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row + 1; // Next from top to bottom
					if(Data[row,col] == Data[nextRow, col]) {
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow,col] = 0;
						points = Data[row,col];
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveUp();
			return points;
		}
		private void MoveUp()
		{
			for(int row = 0; row < 4; row++) {
				for(int col = 0; col < 4; col++) {
					int firstIndex = -1;
					for(int k = 0; k < 4; k++) {
						if(Data[k,col] == 0) {
							firstIndex = k;
							break;
						}
					}
					if(firstIndex == -1) 
						continue;
					
					if(firstIndex == 3)
						continue;

					if(firstIndex < row) {
						Data[firstIndex, col] = Data[row, col];
						Data[row,col] = 0;
					}
				}
			}
		}

		private int MergeDown() 
		{
			MoveDown();
			bool happened = false;
			int points = 0;
			for(int row = 3; row > 0; row--) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row - 1; // Next from bottom to top
					if(Data[row, col] == Data[nextRow, col]) {
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow, col] = 0;
						points = Data[row,col];
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveDown();
			return points;
		}
		private void MoveDown()
		{
			for(int row = 3; row >= 0; row--) {
				for(int col = 0; col < 4; col++) {
					int lastIndex = -1;
					for(int k = 0; k < 4; k++) {
						if(Data[k,col] == 0) {
							lastIndex = k;
						}
					}
					if(lastIndex == 0) {
						continue;
					}
					if(lastIndex != -1) {
						if(row < lastIndex) {
							Data[lastIndex, col] = Data[row, col];
							Data[row,col] = 0;
						}

					}
				}
			}
		}
		
		private void GenerateNumberAfterTurn()
		{
			Random rnd = new Random();
			int row = rnd.Next(0, 4);
			int col = rnd.Next(0, 4);
			int val = rnd.Next(0, 2) == 0 ? 2 : 4;
			while (Data[row, col] != 0)
			{
				row = rnd.Next(0, 4);
				col = rnd.Next(0, 4);
			}
			Data[row, col] = val;
		}

		public bool CheckLose() {
       		// Copy all the current moves to a new temporary board.
	        Board tempBoard = new Board();
			tempBoard.Data = (int[,])this.Data.Clone();
        
    	    // Call upon all 4 directions, then check if there are any points..
    	    // If there isnt, there arent any more possible moves and the player lost.
			int val = 0;
        	foreach (Direction dir in Enum.GetValues<Direction>())
        	{
            	val += tempBoard.Move(dir);
	        }
    	    if(val == 0) {
        	    return true;
        	}
			return false;
    	}
	}
}

