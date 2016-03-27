using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class SelectorEntity : Entity
	{
		int Min;
		int Max;
		SelectorMode Mode;

		public SelectorEntity(Vector positions, SelectorMode mode)
		{
			if (mode == SelectorMode.Horizontal) Display = '^';
			else Display = '>';

			Mode = mode;

			Min = positions.X;
			Max = positions.Y;

			OnUpdate += SelectorEntity_OnUpdate;
		}

		private void SelectorEntity_OnUpdate(UpdateEventArgs e)
		{
			switch (e.Key)
			{
				case ConsoleKey.W:
					if (Position.Y > Min && Mode == SelectorMode.Vertical)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.S:
					if (Position.Y < Max && Mode == SelectorMode.Vertical)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.UpArrow:
					if (Position.Y > Min && Mode == SelectorMode.Vertical)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y - 1));
					break;

				case ConsoleKey.DownArrow:
					if (Position.Y < Max && Mode == SelectorMode.Vertical)
						ParentScene.Terrain.Move(this, new Vector(Position.X, Position.Y + 1));
					break;

				case ConsoleKey.A:
					if (Position.X > Min && Mode == SelectorMode.Horizontal)
						ParentScene.Terrain.Move(this, new Vector(Position.X - 1, Position.Y));
					break;

				case ConsoleKey.D:
					if (Position.X < Max && Mode == SelectorMode.Horizontal)
						ParentScene.Terrain.Move(this, new Vector(Position.X + 1, Position.Y));
					break;

				case ConsoleKey.LeftArrow:
					if (Position.X > Min && Mode == SelectorMode.Horizontal)
						ParentScene.Terrain.Move(this, new Vector(Position.X - 1, Position.Y));
					break;

				case ConsoleKey.RightArrow:
					if (Position.X < Max && Mode == SelectorMode.Horizontal)
						ParentScene.Terrain.Move(this, new Vector(Position.X + 1, Position.Y));
					break;
			}
		}
	}

	enum SelectorMode
	{
		Horizontal,
		Vertical
	}
}
