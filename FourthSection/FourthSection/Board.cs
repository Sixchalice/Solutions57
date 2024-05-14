using System;
namespace FourthSection
{
	public class Board
	{
		public int[,] Data { get; protected set; } = new int[4, 4];
		public int points {get; private set; } = 0;
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

				// Data.SetValue(2, row, col+2);
				// Data.SetValue(2, row+1, col+2);
				// Data.SetValue(4, row + 3, col+ 2);

				// Data.SetValue(2, row, col);
				// Data.SetValue(2, row, col + 1);
				// Data.SetValue(4, row, col + 3);
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
					MergeRight();
					break;

				case Direction.Left:
					MergeLeft();
					break;

				case Direction.Up:
					MergeUp();
					break;

				case Direction.Down:
					MergeDown();
					break;
			}
			GenerateNumberAfterTurn();
		}

		private void MergeRight() {
			MoveRight();

			for(int row = 0; row < 4; row++) {
				for(int col = 3; col > 0; col--) {
					int nextCol = col - 1; // Next column from right to left
					if(Data[row, col] == Data[row, nextCol]) {
						Data[row,col] = Data[row, col] * 2;
						Data[row,nextCol] = 0;
						AddPoints(Data[row,col]);
					}
				}
			}

			MoveRight();
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
					if(lastIndex != -1) {
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

			for(int row = 0; row < 4; row++) {
				for(int col = 0; col < 3; col++) {
					int nextCol = col + 1; // Next column from left to right
					if(Data[row,col] == Data[row,nextCol]) {
						Data[row,col] = Data[row,col] * 2;
						Data[row,nextCol] = 0;
						AddPoints(Data[row,col]);
					}
				}
			}

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
			for(int row = 0; row < 3; row++) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row + 1; // Next from top to bottom
					if(Data[row,col] == Data[nextRow, col]) {
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow,col] = 0;
						AddPoints(Data[row,col]);
					}
				}
			}
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
			for(int row = 3; row > 0; row--) {
				for(int col = 0; col < 4; col++) {
					int nextRow = row - 1; // Next from bottom to top
					if(Data[row, col] == Data[nextRow, col]) {
						Data[row,col] = Data[row,col] * 2;
						Data[nextRow, col] = 0;
						AddPoints(Data[row,col]);
					}
				}
			}
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

