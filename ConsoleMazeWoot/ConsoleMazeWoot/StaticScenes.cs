﻿using System;
using Trilobyte;

namespace ConsoleMazeWoot
{
	static class StaticScenes
	{
		public static Scene MainMenu { get; set; }
		static SelectorEntity MainMenuSelector { get; set; }

		public static Scene CreditsMenu { get; set; }

		public static Scene GameOverMenu { get; set; }
		public static Scene PlayerIconMenu { get; set; }
		static SelectorEntity PlayerIconMenuSelector { get; set; }

		public static void LoadScenes()
		{
			#region MainMenu
			MainMenu = new Scene("MainMenu",
				new DictionaryTerrainManager(' ', new Vector(32, 33)),
				new Camera(new Vector(0, 0), new Vector(32, 33)));

			Program.WriteString("CONSOLE MAZE", new Vector(1, 1), MainMenu);
			Program.WriteString("NEW GAME", new Vector(2, 3), MainMenu);
			Program.WriteString("CREDITS", new Vector(2, 4), MainMenu);
			Program.WriteString("QUIT", new Vector(2, 5), MainMenu);

			MainMenuSelector = new SelectorEntity(new Vector(3, 5), SelectorMode.Vertical);
			MainMenuSelector.OnUpdate += MainMenuSelector_OnUpdate;

			MainMenu.Terrain.Add(MainMenuSelector, new Vector(1, 3));
			#endregion

			#region CreditsMenu
			CreditsMenu = new Scene("CreditsMenu",
				new DictionaryTerrainManager(' ', new Vector(32, 33)),
				new Camera(new Vector(0, 0), new Vector(32, 33)));

			Program.WriteString("CONSOLE MAZE", new Vector(1, 1), CreditsMenu);
			Program.WriteString("COPYRIGHT 2016", new Vector(1, 2), CreditsMenu);

			Program.WriteString("MADE BY", new Vector(1, 4), CreditsMenu);
			Program.WriteString("IAN WOLD", new Vector(9, 4), CreditsMenu);
			Program.WriteString("ANDREW WILLETTE", new Vector(9, 5), CreditsMenu);
			Program.WriteString("MADE AT EPX STUDIO", new Vector(1, 6), CreditsMenu);

			Program.WriteString("USES THE TRILOBYTE ENGINE", new Vector(1, 8), CreditsMenu);

			Program.WriteString("MAIN MENU", new Vector(2, 10), CreditsMenu);

			var CreditsMenuSelector = new SelectorEntity(new Vector(10, 10), SelectorMode.Vertical);
			CreditsMenuSelector.OnUpdate += ReturnToMain_OnUpdate;

			CreditsMenu.Terrain.Add(CreditsMenuSelector, new Vector(1, 10));
			#endregion

			#region GameOverMenu
			GameOverMenu = new Scene("GameOver",
				new DictionaryTerrainManager(' ', new Vector(32, 33)),
				new Camera(new Vector(0, 0), new Vector(32, 33)));

			Program.WriteString("GAME OVER.", new Vector(1, 1), GameOverMenu);

			Program.WriteString("LEVEL " + Program.Level, new Vector(1, 3), GameOverMenu);
			Program.WriteString("POINTS " + Program.Level, new Vector(1, 4), GameOverMenu);
			Program.WriteString("HP " + Program.Level, new Vector(1, 5), GameOverMenu);

			Program.WriteString("MAIN MENU", new Vector(2, 7), GameOverMenu);

			var GameOverSelector = new SelectorEntity(new Vector(7, 7), SelectorMode.Vertical);
			GameOverSelector.OnUpdate += ReturnToMain_OnUpdate;

			GameOverMenu.Terrain.Add(GameOverSelector, new Vector(1, 7));
			#endregion

			#region PlayerIconMenu
			PlayerIconMenu = new Scene("PlayerIconMenu",
				new DictionaryTerrainManager(' ', new Vector(32, 33)),
				new Camera(new Vector(0, 0), new Vector(32, 33)));

			Program.WriteString("CHOOSE YOUR CHARACTER", new Vector(1, 1), PlayerIconMenu);

			Program.WriteString(((char)1).ToString(), new Vector(1, 3), PlayerIconMenu);
			Program.WriteString(((char)2).ToString(), new Vector(2, 3), PlayerIconMenu);
			Program.WriteString(((char)3).ToString(), new Vector(3, 3), PlayerIconMenu);
			Program.WriteString(((char)4).ToString(), new Vector(4, 3), PlayerIconMenu);
			Program.WriteString(((char)5).ToString(), new Vector(5, 3), PlayerIconMenu);
			Program.WriteString(((char)6).ToString(), new Vector(6, 3), PlayerIconMenu);
			Program.WriteString(((char)11).ToString(), new Vector(7, 3), PlayerIconMenu);
			Program.WriteString(((char)12).ToString(), new Vector(8, 3), PlayerIconMenu);

			PlayerIconMenuSelector = new SelectorEntity(new Vector(1, 8), SelectorMode.Horizontal);
			PlayerIconMenuSelector.OnUpdate += PlayerIconMenuSelector_OnUpdate;

			PlayerIconMenu.Terrain.Add(PlayerIconMenuSelector, new Vector(1, 4));
			#endregion

		}

		private static void PlayerIconMenuSelector_OnUpdate(UpdateEventArgs e)
		{
			if (e.Key == ConsoleKey.Enter)
			{
				char playerChar = (char)1;

				switch (PlayerIconMenuSelector.Position.X)
				{
					case 1:
						playerChar = (char)1;
						break;

					case 2:
						playerChar = (char)2;
						break;

					case 3:
						playerChar = (char)3;
						break;

					case 4:
						playerChar = (char)4;
						break;

					case 5:
						playerChar = (char)5;
						break;

					case 6:
						playerChar = (char)6;
						break;

					case 7:
						playerChar = (char)11;
						break;

					case 8:
						playerChar = (char)12;
						break;
				}

				Program.Score = 0;
				Program.Level = 0;
				Program.Health = 5;

				Program.GenerateNewScene(new PlayerEntity(playerChar) { Position = new Vector(1, 1) });
				GameLoop.NavigateScene(Program.CurrentScene);
			}
		}

		private static void ReturnToMain_OnUpdate(UpdateEventArgs e)
		{
			if (e.Key == ConsoleKey.Enter)
			{
				GameLoop.NavigateScene(MainMenu);
			}
		}

		private static void MainMenuSelector_OnUpdate(UpdateEventArgs e)
		{
			if (e.Key== ConsoleKey.Enter)
			{
				switch (MainMenuSelector.Position.Y)
				{
					case 3: //New Game
						GameLoop.NavigateScene(PlayerIconMenu);
						break;

					case 4: //Credits
						GameLoop.NavigateScene(CreditsMenu);
						break;

					case 5: //Quit
						Environment.Exit(0);
						break;
				}
			}
		}
	}
}