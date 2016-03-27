using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class SelectorEntity : Entity
	{
		int Top;
		int Bottom;

		public SelectorEntity(int top, int bottom)
		{
			Display = '>';

			Top = top;
			Bottom = bottom;

			OnUpdate += SelectorEntity_OnUpdate;
		}

		private void SelectorEntity_OnUpdate(UpdateEventArgs e)
		{
			switch (e.Key)
			{
				case ConsoleKey.W:
					if (Position.Y > Top)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.S:
					if (Position.Y < Bottom)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.UpArrow:
					if (Position.Y > Top)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.DownArrow:
					if (Position.Y < Bottom)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;
			}
		}
	}
}
