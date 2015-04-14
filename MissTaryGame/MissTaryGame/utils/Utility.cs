using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MissTaryGame.Pathing;
using Indigo.Masks;

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
	public static bool[,] LoadAndProcessClickMap(string path, Grid pathGrid, int rows, int columns)
	{
		var map = new SFML.Graphics.Image(path);
		var clickMap = new bool[map.Size.X,map.Size.Y];

		float totalPixelsInTile = pathGrid.TileWidth * pathGrid.TileHeight;
		int totalTrue = 0;
		int xMax = 0;
		int yMax = 0;
		for(int x = 0; x < pathGrid.Columns; x++)
		{
			for(int y = 0; y < pathGrid.Rows; y++)
			{
				totalTrue = 0;
				xMax = pathGrid.TileWidth * x + pathGrid.TileWidth;
				
				for(int xMap = pathGrid.TileWidth * x; xMap < xMax; xMap++)
				{
					yMax = pathGrid.TileHeight * y + pathGrid.TileHeight;
//					Console.WriteLine(yMax);
					for(int yMap = pathGrid.TileHeight * y; yMap < yMax; yMap++)
					{
						if(xMap < map.Size.X && yMap < map.Size.Y && (map.GetPixel((uint)xMap,(uint)yMap).B > 40))
							totalTrue++;
					}
				}
				//Console.WriteLine(totalTrue);
				pathGrid.SetTile(x, y, (totalTrue / totalPixelsInTile) >= .5f);
				//Console.WriteLine("X: " + x + "Y: " + y + " | " + totalTrue + " " + totalPixelsInTile + " " + totalTrue / totalPixelsInTile);
			}
		}
		return clickMap;
	}
	
	public static IEnumerable<Tuple<PathNode, float>> SelectTilesAroundTile(int centerX, int centerY, int mapWidth, int mapHeight)
	{
		for (int x = -1; x < 2; ++x)
		{
			if (centerX + x >= mapWidth)
				break;
			if (centerX + x < 0)
				continue;
			for(int y = -1; y < 2; ++y)
			{
				if (centerY + y >= mapHeight)
					break;
				if (centerY + y < 0 || (x == 0 && y == 0) /*|| !mapCell.MyNode.Enabled*/)
					continue;
				yield return Tuple.Create<PathNode, float>(null/*mapCell.MyNode*/, ((x < 0 ? -x : x) == 1 && (y < 0 ? -y : y) == 1) ? 1.41f : 1);
			}
		}
	}
}