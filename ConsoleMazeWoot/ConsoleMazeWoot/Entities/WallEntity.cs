using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class WallEntity : Entity
	{

        /// <summary>
        /// Tracks whether the wall causes the player to lose when they collide with it
        /// </summary>
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
				if (Program.Health == 0) Program.Lose();
				else Program.Health--;
			}

			e.Cancel = true;
		}
	}
}
