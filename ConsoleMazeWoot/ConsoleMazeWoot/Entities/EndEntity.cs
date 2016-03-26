using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class EndEntity : Entity
	{
		public EndEntity(char toDisplay = '>')
		{
			Display = toDisplay;
			OnCollidedWith += EndEntity_OnCollidedWith;
		}

		private void EndEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				Program.GenerateNewScene(e.Caller as PlayerEntity);
				GameLoop.NavigateScene(Program.CurrentScene);
				ParentScene.Terrain.Remove(e.Caller);
			}

			e.Cancel = true;
		}
	}
}
