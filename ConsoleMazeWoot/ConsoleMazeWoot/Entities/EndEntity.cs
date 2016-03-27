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
                try
                {
                    //deleted playerEntity from previous board
                    //garbage collection, this instance of board should never be used again
                    ParentScene.Terrain.Remove(e.Caller);

                }
                catch(Exception ex)
                {

                }
			}

			e.Cancel = true;
		}
	}
}
