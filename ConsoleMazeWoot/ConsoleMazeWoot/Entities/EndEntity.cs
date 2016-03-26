using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class EndEntity : Entity
	{
		public EndEntity()
		{
			Display = '>';

			OnCollidedWith += EndEntity_OnCollidedWith;
		}

		private void EndEntity_OnCollidedWith(object sender, CollisionEventArgs e)
		{
			if (e.Caller.GetType() == typeof(PlayerEntity))
			{
				Program.GenerateNewScene();
				Program.CurrentScene.Terrain.Add(e.Caller, new Vector(1, 1));
				GameLoop.NavigateScene(Program.CurrentScene);
				ParentScene.Terrain.Remove(e.Caller);
			}

			e.Cancel = true;
		}
	}
}
