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
				if (Program.Level < 20)
				{
					Program.GenerateNewScene(new PlayerEntity(StaticScenes.PlayerChar) { Position = e.Caller.Position });
					GameLoop.NavigateScene(Program.CurrentScene);
				}
				else
				{
					Program.Win();
				}
			}

			e.Cancel = true;
		}
	}
}
