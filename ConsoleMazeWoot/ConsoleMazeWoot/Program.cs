using System;
using System.Collections.Generic;
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
			CurrentScene = new Scene(
				"NewScene",
				new DictionaryTerrainManager(' ', new Vector(32, 32)),
				new Camera(new Vector(0, 0), new Vector(32, 32)));

			CreateGraph();
			CreateMaze();

			for (int x = 0; x < 16; x += 1)
			{
				for (int y = 0; y < 16; y += 1)
				{
					var mod_x = x * 2;
					var mod_y = y * 2;

					CurrentScene.Terrain.Add(new WallEntity(), new Vector(mod_x, mod_y));
					var pindex = (y * Size) + x;

					var _up = graph[pindex, up];

					if (!_up.deleted) CurrentScene.Terrain.Add(new WallEntity(), new Vector(mod_x + 1, mod_y));
					if (!graph[pindex, left].deleted)
					{
						if (mod_x == 0 && mod_y == 0) CurrentScene.Terrain.Add(new StartEntity(), new Vector(mod_x, mod_y + 1));
						else CurrentScene.Terrain.Add(new WallEntity(), new Vector(mod_x, mod_y + 1));
					}
				}
			}

			for (int x = 0; x < 32; x++)
			{
				CurrentScene.Terrain.Add(new WallEntity(), new Vector(x, 32));
			}

			for (int y = 0; y < 31; y++)
			{
				CurrentScene.Terrain.Add(new WallEntity(), new Vector(32, y));
			}

			CurrentScene.Terrain.Add(new EndEntity(), new Vector(32, 31));
			CurrentScene.Terrain.Add(new WallEntity(), new Vector(32, 32));
		}

		#region MazeGen

		const int right = 0;
		const int down = 1;
		const int left = 2;
		const int up = 3;
		static Random randomGenerator;

		const int Size = 16;
		static Point[,] board = new Point[Size, Size];
		static Edge dummy = new Edge(new Point(0, 0), 0);
		static Edge[,] graph = new Edge[Size * Size, 4];

		static void CreateGraph()
		{
			dummy.used = true;
			dummy.point.visited = true;

			for (int i = 0; i < Size; ++i)
			{
				for (int j = 0; j < Size; ++j)
				{
					var p = new Point(i, j);
					var pindex = i * Size + j;
					p.index = pindex;

					board[i, j] = p;

					graph[pindex, right] = (j < Size - 1) ? new Edge(p, right) : dummy;
					graph[pindex, down] = (i < Size - 1) ? new Edge(p, down) : dummy;
					graph[pindex, left] = (j > 0) ? graph[pindex - 1, right] : dummy;
					graph[pindex, up] = (i > 0) ? graph[pindex - Size, down] : dummy;

				}
			}
		}

		static Point GetAdjacent(Point pnt, int dir)
		{
			Point toReturn = null;

			if (graph[pnt.index, dir] != dummy && dir == down && pnt.x + 1 < Size)
			{
				toReturn = board[pnt.x + 1, pnt.y];
			}
			else if (graph[pnt.index, dir] != dummy && dir == up && pnt.x - 1 != -1)
			{
				toReturn = board[pnt.x - 1, pnt.y];
			}
			else if (graph[pnt.index, dir] != dummy && dir == right && pnt.y + 1 < Size)
			{
				toReturn = board[pnt.x, pnt.y + 1];
			}
			else if (graph[pnt.index, dir] != dummy && dir == left && pnt.y - 1 != -1)
			{
				toReturn = board[pnt.x, pnt.y - 1];
			}

			if (toReturn != null && toReturn.visited) return null;
			else return toReturn;
		}

		static void CreateMaze()
		{
			var pointsList = new List<Point>();

			board[0, 0].visited = true;
			pointsList.Add(board[0, 0]);

			randomGenerator = new Random();
			var randomDir = 0;
			Point nextPoint = null, randomPoint;

			while (GetUnvisitedPoints() > 0)
			{
				randomPoint = pointsList[randomGenerator.Next(pointsList.Count)];

				var loopCount = 0;
				do
				{
					loopCount++;
					if (loopCount == 12) break;

					randomDir = randomGenerator.Next(4);
					nextPoint = GetAdjacent(randomPoint, randomDir);
				}
				while (nextPoint == null);

				if (nextPoint != null)
				{
					nextPoint.visited = true;
					pointsList.Add(nextPoint);

					graph[randomPoint.index, randomDir].deleted = true;
				}
			}
		}

		static int GetUnvisitedPoints()
		{
			foreach (Point p in board)
				if (!p.visited)
					return 1;
			return 0;
		}

		#endregion
	}

	class Point
	{
		// a Point is a position in the maze

		public int x, y;
		public bool visited = false;   // for DFS
		public int index;

		// Constructor
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	class Edge
	{
		// an Edge is a link between two Points: 
		// For the grid graph, an edge can be represented by a point and a direction.
		public Point point;
		public int direction;
		public bool used;     // for maze creation
		public bool deleted;  // for maze creation

		// Constructor
		public Edge(Point p, int d)
		{
			point = p;
			direction = d;
			used = false;
			deleted = false;
		}
	}
}
