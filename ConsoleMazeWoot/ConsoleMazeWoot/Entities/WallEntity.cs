using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class WallEntity : Entity
	{
		public bool LoseOnCollide { get; private set; }

		public WallEntity(bool loseOnCollide = false)
		{
			LoseOnCollide = loseOnCollide;
			Display = '■';
			OnCollidedWith += WallEntity_OnCollidedWith;
		}

		private void WallEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (LoseOnCollide && e.Caller.GetType() == typeof(PlayerEntity))
			{
				Program.Lose();
			}

			e.Cancel = true;
		}
	}
}
