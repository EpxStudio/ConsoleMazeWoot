using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class PlayerEntity : Entity
	{
		public int Score { get; set; }

		public int Level { get; set; }

		public PlayerEntity()
		{
			Display = 'O';
			OnUpdate += PlayerEntity_OnUpdate;

			Score = 0;
			Level = 0;
		}

		private void PlayerEntity_OnUpdate(UpdateEventArgs e)
		{
			switch (e.Key)
			{
				case ConsoleKey.W:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.S:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.A:
					ParentScene.Terrain.Move(this, new Vector(Position.X - 1, Position.Y));
					break;

				case ConsoleKey.D:
					ParentScene.Terrain.Move(this, new Vector(Position.X + 1, Position.Y));
					break;
			}

			Program.WriteString("SCORE " + String.Format("{0000}", Score), new Vector(12,33), Program.CurrentScene);
			Program.WriteString("LEVEL " + String.Format("{00}", Level), new Vector(25, 33), Program.CurrentScene);
		}
	}
}
