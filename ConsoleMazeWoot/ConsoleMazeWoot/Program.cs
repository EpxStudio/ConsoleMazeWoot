using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	class Program
	{
		static void Main(string[] args)
		{
			GenerateNewScene();
			CurrentScene.Terrain.Add(new PlayerEntity(), new Vector(1, 1));
			GameLoop.Begin(CurrentScene);
		}

		public static Scene CurrentScene { get; private set; }

		public static void GenerateNewScene()
		{
			var CurrentScene = new Scene(
				"NewScene",
				new DictionaryTerrainManager(' ', new Vector(33, 33)),
				new Camera(new Vector(0, 0), new Vector(33, 33)));

			//Generate maze here
		}
	}
}
