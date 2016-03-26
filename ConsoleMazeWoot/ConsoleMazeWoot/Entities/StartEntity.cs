using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class StartEntity : Entity
	{
		public StartEntity()
		{
			Display = '>';

			OnCollidedWith += StartEntity_OnCollidedWith;
		}

		private void StartEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
