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

			var toWrite = "";

			toWrite += String.Format("{0}", span.Minutes) + ":" + String.Format("{00}", span.Seconds) + "|";
			toWrite += "PTS " + String.Format("{0000}", Program.Score) + "|";
			toWrite += "LVL " + String.Format("{00}", Program.Level) + "|";
			toWrite += "HP " + Program.Health;

			Program.WriteString(toWrite, new Vector(0, 33), Program.CurrentScene);
		}
	}
}
