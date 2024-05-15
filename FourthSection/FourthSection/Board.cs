using System;
namespace FourthSection
{
	public class Board
	{
		public int[,] Data { get; protected set; } = new int[4, 4];
		public int points {get; private set; } = 0;

		public Board(int[,] arr) {
			this.Data = arr;
		}
		public Board() {}
		
		public int[,] StartGame()
		{
			// Make 2 tiles 2 or 4 for the beginning of the game.
			for (int i = 0; i < 2; i++)
			{
				// int row = new Random().Next(0, 4);
				// int col = new Random().Next(0, 4);
				// int val = new Random().Next(0,2) == 0 ? 2 : 4;

				// Data.SetValue(val,row,col);


				// Data.SetValue(2, 0, 0);
				// Data.SetValue(4, 1, 0);

				// Data.SetValue(4, 0, 1);
				// Data.SetValue(2, 1, 1);
				// Data.SetValue(4, 2, 1);
				// Data.SetValue(16,3, 1);

				// Data.SetValue(8,0, 2);
				// Data.SetValue(4,1, 2);
				// Data.SetValue(8,2, 2);
				// Data.SetValue(2,3, 2);

				// Data.SetValue(2,3, 3);
				// Data.SetValue(8,3, 3);
				// Data.SetValue(2,3, 3);
				// Data.SetValue(4,3, 3);


				Data.SetValue(2,3,0);
				Data.SetValue(2,2,0);
				Data.SetValue(4,1,0);
				Data.SetValue(2,0,0);


				// Data.SetValue(2,0,1);
				// Data.SetValue(2,1,1);
				// Data.SetValue(2,2,1);
				// Data.SetValue(4,3,1);

			}
			return Data;
		}
		public void Move(Direction direction)
		{
			// Move the tiles in the direction given.
			// If there is a tile with the same value, merge them.
			// Generate a 2 or a 4 in a random available tile. 

			switch (direction)
			{
				case Direction.Right:
					// doesnt work.
					// test case:
						// Data.SetValue(2,0,3);
						// Data.SetValue(2,0,2);
						// Data.SetValue(4,0,1);
						// Data.SetValue(2,0,0);
					MergeRight();
					break;

				case Direction.Left:
					//Everything seems to work.
					MergeLeft();
					break;

				case Direction.Up:
					// Does not work.
					// Test case: 
						// Data.SetValue(2,0,2);
						// Data.SetValue(2,1,2);
						// Data.SetValue(4,2,2);
						// Data.SetValue(2,3,2);
					MergeUp();
					// MoveUp();
					break;

				case Direction.Down:
					//Everything seems to work.
					MergeDown();
					// MoveDown();
					break;
			}
		}

		private void MergeRight() {
			MoveRight();
			bool happened = false;
			for(int row = 0; row < 4; row++) {
				for(int col = 3; col > 0; col--) {
					int nextCol = col - 1; // Next column from right to left
					if(Data[row, col] == Data[row, nextCol]) {
						Data[row,col] = Data[row, col] * 2;
						Data[row,nextCol] = 0;
						AddPoints(Data[row,col]);
						happened = true;
					}
				}
			}
			MoveRight();
			if(happened)
				GenerateNumberAfterTurn();
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
						return;
					}
					if(lastIndex != -1) {
						System.Console.WriteLine("Changed: (" + row + ", " + col +") with (" + row + ", " + lastIndex + ")" );
						if(Data[row,col] != 0) {
							Data[row, lastIndex] = Data[row, col];
							Data[row,col] = 0;
						}
					}
				}
			}
		}

		private void MergeLeft() {
			MoveLeft();
			bool happened = false;
			for(int row = 0; row < 4; row++) {
				for(int col = 0; col < 3; col++) {
					int nextCol = col + 1; // Next column from left to right
					if(Data[row,col] == Data[row,nextCol]) {
						Data[row,col] = Data[row,col] * 2;
						Data[row,nextCol] = 0;
						AddPoints(Data[row,col]);
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveLeft();
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
					if(firstIndex != -1) {
						Data[row, firstIndex] = Data[row,col];
						Data[row,col] = 0;
					}
				}
			}
		}

		private void MergeUp() {
			MoveUp();
			bool happened = false;
			for(int row = 0; row < 3; row++) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row + 1; // Next from top to bottom
					if(Data[row,col] == Data[nextRow, col]) {
						System.Console.WriteLine("ON: (" + row + ", " + col +")");
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow,col] = 0;
						AddPoints(Data[row,col]);
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveUp();
		}
		private void MoveUp()
		{

			for(int row = 0; row < 4; row++) {
				int firstIndex = -1;
				for(int col = 0; col < 4; col++) {
					for(int k = 3; k >= 0; k--) {
						if(Data[k,col] == 0) {
							firstIndex = k;
						}
					}
					if(firstIndex == 3) {
						return;
					}
					if(firstIndex > -1) {
						if(row > firstIndex) {
							Data[firstIndex, col] = Data[row, col];
							Data[row,col] = 0;
						}
					}
				}
			}
		}

		private void MergeDown() 
		{
			MoveDown();
			bool happened = false;
			for(int row = 3; row > 0; row--) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row - 1; // Next from bottom to top
					if(Data[row, col] == Data[nextRow, col]) {
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow, col] = 0;
						AddPoints(Data[row,col]);
						happened = true;
					}
				}
			}
			if(happened)
				GenerateNumberAfterTurn();
			MoveDown();
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
					if(lastIndex != -1) {
						if(row < lastIndex) {
							Data[lastIndex, col] = Data[row, col];
							Data[row,col] = 0;
						}

					}
				}
			}
		}
		
		private void AddPoints(int n) {
			this.points += n;
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
	}
}

