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
				Data.SetValue(4, row, col);
				Data.SetValue(2, row + 1, col);
				Data.SetValue(2, row + 3, col);
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
					MoveUp();
					break;

				case Direction.Down:
					MoveDown();
					break;
			}
			// GenerateNumberAfterTurn();
		}

		private void MergeRight() {
			MoveRight();
			for(int i = 0; i < 4; i++) {
				for(int j = 3; j > 0; j--) {
					if(Data[i,j] != 0) {
						int k = j - 1; // The next column (right to left)
						if(Data[i,j] == Data[i,k]) {
							Data[i,j] = Data[i,k] * 2;
							Data[i,k] = 0;
						}
					}
				}
			}
			MoveRight();
		}
		private void MoveRight()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (Data[i, j] != 0)
					{
						for (int k = j + 1; k < 4; k++)
						{
							if (Data[i, k] == 0)
							{
								Data[i, k] = Data[i, j];
								Data[i, j] = 0;
							}
						}
					}
				}
			}
		}

		private void MergeLeft() {
			MoveLeft();
			for(int i = 0; i < 4; i++) {
				for(int j = 0; j < 3; j++) {
					if(Data[i,j] != 0) {
						int k = j + 1; // The next column (left to right)
						if(Data[i,j] == Data[i,k]) {
							Data[i,j] = Data[i,k] * 2;
							Data[i,k] = 0;
						}
					}
				}
			}
			MoveLeft();
		}
		private void MoveLeft()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (Data[i, j] != 0)
					{
						for (int k = 3 - j; k < 4; k++)
						{
							if (Data[i, k] == 0)
							{
								Data[i, k] = Data[i, j];
								Data[i, j] = 0;
							}
						}
					}
				}
			}
		}

		private void MergeUp() {
			MoveUp();
			for(int i = 0; i < 3; i++) {
				for(int j = 0; j < 4; j++) {
					if(Data[i,j] != 0) {
						int k = i + 1;
						if(Data[i,j] == Data[k,j]) {
							Data[i,j] = Data[k,j] * 2;
							Data[k,j] = 0;
						}
					}
				}
			}
			MoveUp();
		}
		private void MoveUp()
		{
			for (int i = 3; i > 0; i--)
			{
				for (int j = 0; j < 4; j++)
				{
					if (Data[i, j] != 0)
					{
						for (int k = i - 1; k < 4; k++)
						{
							if (Data[k, j] == 0)
							{
								Data[k, j] = Data[i, j];
								Data[i, j] = 0;
							}
						}
					}
				}
			}
		}

		private void MergeDown() {

		}
		private void MoveDown()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (Data[i, j] != 0)
					{
						int k = i + 1;
						if (Data[k, j] == 0)
						{
							Data[k, j] = Data[i, j];
							Data[i, j] = 0;
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
	}
}

