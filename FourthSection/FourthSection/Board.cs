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

		private void MergeRight() {
			MoveRight();

			for(int row = 0; row < 4; row++) {
				for(int col = 0; col < 3; col++) {
					if(Data[row,col] != 0) {
						int nextCol = col + 1;
						if(Data[row, col] == Data[row,nextCol]) {
							Data[row,nextCol] = Data[row,nextCol] * 2;
							Data[row,col] = 0;
						}
					}
				}
			}
			// for(int i = 0; i < 4; i++) {
			// 	for(int j = 3; j > 0; j--) {
			// 		if(Data[i,j] != 0) {
			// 			int k = j - 1; // The next column (right to left)
			// 			if(Data[i,j] == Data[i,k]) {
			// 				Data[i,j] = Data[i,k] * 2;
			// 				Data[i,k] = 0;
			// 			}
			// 		}
			// 	}
			// }
			MoveRight();
		}

		private void MoveRight() {
			for(int row = 0; row < 4; row++) {
				for(int col = 2; col >= 0; col--) {
					if(Data[row,col + 1] == 0) {
						Data[row,col + 1] = Data[row,col];
						Data[row,col] = 0;
					}
				}
			}
		}

		private void MoveLeft()
		{
			for(int row = 0; row < 4; row++) {
				for(int col = 1; col < 4; col++) {
					if(Data[row, col - 1] == 0) {
						Data[row, col - 1] = Data[row,col];
						Data[row,col] = 0;
					}
				}
			}
		}

		// private void MergeLeft() {
		// 	MoveLeft();
		// 	for(int i = 0; i < 4; i++) {
		// 		for(int j = 0; j < 3; j++) {
		// 			if(Data[i,j] != 0) {
		// 				int k = j + 1; // The next column (left to right)
		// 				if(Data[i,j] == Data[i,k]) {
		// 					Data[i,j] = Data[i,k] * 2;
		// 					Data[i,k] = 0;
		// 				}
		// 			}
		// 		}
		// 	}
		// 	MoveLeft();
		// }

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
			
		}

		private void MergeDown() {

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

