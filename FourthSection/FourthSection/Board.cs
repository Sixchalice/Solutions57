using System;
namespace FourthSection
{
	public class Board
	{
		public int[,] Data { get; protected set; } = new int[4, 4];

		public Board()
		{
		}

		public int[,] StartGame()
		{
			// Make 2 tiles 2 or 4 for the beginning of the game.
			for (int i = 0; i < 2; i++)
			{
				// int row = new Random().Next(0, 4);
				// int col = new Random().Next(0, 4);
				// int val = new Random().Next(0,2) == 0 ? 2 : 4;
				int row = 0;
				int col = 0;
				Data.SetValue(2, row + 1, col);
				Data.SetValue(2, row+1, col+1);
				Data.SetValue(4, row+1, col+ 2);
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
					MoveRight();
					break;

				case Direction.Left:
					MoveLeft();
					break;

				case Direction.Up:
					MoveUp();
					break;

				case Direction.Down:
					MoveDown();
					break;
			}
			// GenerateNumberAfterTurn();
		}

		private void MoveRight() {
			for(int row = 0; row < 4; row++) {
				int lastIndex = -1;
				for(int col = 2; col >= 0; col--) {
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
		private void MoveUp()
		{

		}
		private void MoveDown()
		{

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

