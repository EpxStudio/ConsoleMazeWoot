using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class PlayerEntity : Entity
	{
		public PlayerEntity(char toDisplay)
		{
			Display = toDisplay;
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

				case ConsoleKey.UpArrow:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.DownArrow:
					ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.LeftArrow:
					ParentScene.Terrain.Move(this, new Vector(Position.X - 1, Position.Y));
					break;

				case ConsoleKey.RightArrow:
					ParentScene.Terrain.Move(this, new Vector(Position.X + 1, Position.Y));
					break;
			}
			
			var span = Program.MaxTime.Subtract(DateTime.Now.Subtract(Program.StartTime));
			if (DateTime.Now.Subtract(Program.StartTime) > Program.MaxTime)
			{
				Program.Lose();
			}

			Program.WriteString(String.Format("{0}", span.Minutes) + ":" + String.Format("{00}", span.Seconds), new Vector(0,33), Program.CurrentScene);
			Program.WriteString("|" + "PTS " + String.Format("{0000}", Program.Score), new Vector(4, 33), Program.CurrentScene);
			Program.WriteString("|" + "LVL " + String.Format("{00}", Program.Level), new Vector(13, 33), Program.CurrentScene);
			Program.WriteString("|" + "HP " + Program.Health, new Vector(21, 33), Program.CurrentScene);
		}
	}
}
