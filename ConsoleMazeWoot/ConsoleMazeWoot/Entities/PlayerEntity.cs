using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class PlayerEntity : Entity
	{

		public PlayerEntity()
		{
			Display = 'O';
			OnUpdate += PlayerEntity_OnUpdate;
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

			var span = DateTime.Now.Subtract(Program.StartTime);
			if (DateTime.Now.Subtract(Program.StartTime) > TimeSpan.FromMinutes(1))
			{
				Program.Lose();
			}

			Program.WriteString("TIME " + String.Format("{0}", span.Minutes) + ":" + String.Format("{00}", span.Seconds), new Vector(0, 33), Program.CurrentScene);
			Program.WriteString("SCORE " + String.Format("{0000}", Program.Score), new Vector(12,33), Program.CurrentScene);
			Program.WriteString("LEVEL " + String.Format("{00}", Program.Level), new Vector(25, 33), Program.CurrentScene);
		}
	}
}
