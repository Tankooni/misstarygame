using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Indigo.Masks;
using MissTaryGame.Pathing;
using Priority_Queue;

public static class Utility
{
	public const int CURSOR_LAYER = 0;
	public const int COMMAND_UI_LAYER = 1;
	public const int WHEEL_UI_LAYER = 2;
	public const int MIDDLE_UI_LAYER = 20;
	public const int FOREGROUND_LAYER = 49;
	public const int BACKGROUND_LAYER = 1001;
	
	
	/// <summary>
	/// Returns all files in a folder using one or more search filters.
	/// Treats filters as or's
	/// </summary>
	/// <param name="path">Path to folder to search</param>
	/// <param name="filters">A list of filters speparated by |</param>
	/// <returns></returns>
	public static string[] RetrieveFilePathForFilesInDirectory(string path, string filters)
	{
		List<string> files = new List<string>();
		foreach(string filter in filters.Split('|'))
			files.AddRange(Directory.GetFiles(path, filter));
		return files.Select(x => x.Remove(0, 2).Replace(@"\","/")).ToArray();
	}
	
	/// <summary>
	/// Processes a greyscale image to determe a scaling factor for each location on the map
	/// </summary>
	/// <param name="path">Indigo path to content</param>
	/// <param name="minScaleValue">Scaling value that represents black in the image</param>
	/// <param name="maxScaleVale">Scaling value that represents white in the image</param>
	/// <returns></returns>
	public static float[,] LoadAndProcessPerspectiveMap(string path, float minScaleValue, float maxScaleVale)
	{
		var map = new SFML.Graphics.Image(path);
		var perspectiveMap = new float[map.Size.X,map.Size.Y];
		float maxValue = maxScaleVale - minScaleValue;
		for(uint i = 0; i < map.Size.X; i++)
			for(uint j = 0; j < map.Size.Y; j++)
				perspectiveMap[i,j] = (map.GetPixel(i,j).B / 255f) * maxValue + minScaleValue;
		return perspectiveMap;
	}
	
	/// <summary>
	/// Processes a black and white image to determine which areas on a map can or can't be clicked
	/// </summary>
	/// <param name="path">Path to click map file</param>
	/// <param name="pathGrid">Grid object to set</param>
	/// <returns></returns>
	public static void LoadAndProcessClickMap(string path, PathNode[,] pathNodes, Grid pathGrid, int tileSize)
	{
		var map = new SFML.Graphics.Image(path);
		var clickMap = new bool[map.Size.X,map.Size.Y];

		float totalPixelsInTile = tileSize * tileSize;
		int totalTrue = 0;
		int xMax = 0;
		int yMax = 0;
		for(int x = 0; x < pathNodes.GetLength(0); x++)
		{
			for(int y = 0; y < pathNodes.GetLength(1); y++)
			{
				totalTrue = 0;
				xMax = tileSize * x + tileSize;
				
				for(int xMap = tileSize * x; xMap < xMax; xMap++)
				{
					yMax = tileSize * y + tileSize;
					for(int yMap = tileSize * y; yMap < yMax; yMap++)
						if(xMap < map.Size.X && yMap < map.Size.Y && map.GetPixel((uint)xMap,(uint)yMap).B > 40)
							totalTrue++;
				}
				pathGrid.SetTile(x, y, pathNodes[x,y].Enabled = (totalTrue / totalPixelsInTile) >= .5f);
			}
		}
	}
	
	public static List<Tuple<PathNode, float>> SelectTilesAroundTile(int centerX, int centerY, PathNode[,] pathNodes)
	{
		int mapWidth = pathNodes.GetLength(0);
		int mapHeight = pathNodes.GetLength(1);
		List<Tuple<PathNode, float>> nodes = new List<Tuple<PathNode, float>>();
		for (int x = -1; x < 2; ++x)
		{
			int cX = centerX + x;
			if (cX >= mapWidth)
				break;
			if (cX < 0)
				continue;
			for(int y = -1; y < 2; ++y)
			{
				int cY = centerY + y;
				if (cY >= mapHeight)
					break;
				if (cY < 0 || (x == 0 && y == 0))
					continue;
				nodes.Add(Tuple.Create<PathNode, float>(pathNodes[cX,cY], (Abs(x) == 1 && Abs(y) == 1) ? 1.41f : 1));
			}
		}
		return nodes;
	}
	
	public static float CalculateHeuristic(float x1, float y1, float x2, float y2)
	{
		return Abs(x1 - x2) + Abs(y1 - y2);
	}
	
	public static IEnumerable<PathNode> SelectAstarPath(PathNode startNode, PathNode endNode, PathNode[,] pathNodes)
	{
        if (startNode != endNode)
        {

            HeapPriorityQueue<PathNode> frontier = new HeapPriorityQueue<PathNode>(PathNode.ConnectedNodes.Keys.Count);
            frontier.Enqueue(startNode, 0);

            Dictionary<PathNode, PathNode> cameFrom = new Dictionary<PathNode, PathNode>();
            Dictionary<PathNode, float> costSoFar = new Dictionary<PathNode, float>();

            cameFrom.Add(startNode, null);
            costSoFar.Add(startNode, 0);


            while (frontier.Count != 0)
            {
                PathNode current = frontier.Dequeue();
                if (current == endNode)
                    break;

                //Console.WriteLine("Processing Node " + current.X + " " + current.Y);
                foreach (var next in PathNode.ConnectedNodes[current])
                {
                    if (!next.Item1.Enabled) continue;
                    if (cameFrom.ContainsKey(next.Item1)) continue;

                    float newCost = costSoFar[current] + next.Item2;
                    if (!costSoFar.ContainsKey(next.Item1) || newCost < costSoFar[next.Item1])
                    {
                        costSoFar[next.Item1] = newCost;
                        float priority = newCost + CalculateHeuristic(next.Item1.X, next.Item1.Y, endNode.X, endNode.Y);
                        frontier.Enqueue(next.Item1, priority);
                        cameFrom[next.Item1] = current;
                    }
                }
            }
            //Console.WriteLine("Done Next up building");

            var result = new List<PathNode>();
            PathNode currentNode = endNode;

            do
            {
                //Console.WriteLine("Processing Node2 " + currentNode.X + " " + currentNode.Y);
                PathNode next = null;
                if (!cameFrom.TryGetValue(currentNode, out next))
                    break;
                yield return (currentNode = next);
            } while (startNode != currentNode);
        }
        else
        {
            yield return startNode;
        }
    }
	
	public static float Abs(float number)
	{
		return (number < 0 ? -number : number);
	}
	public static int Abs(int number)
	{
		return (number < 0 ? -number : number);
	}
}