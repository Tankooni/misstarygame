using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indigo;
using System.IO;

public static class Utility
{
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
	/// <returns></returns>
	public static bool[,] LoadAndProcessClickMap(string path)
	{
		var map = new SFML.Graphics.Image(path);
		var clickMap = new bool[map.Size.X,map.Size.Y];
		for(uint i = 0; i < map.Size.X; i++)
			for(uint j = 0; j < map.Size.Y; j++)
				clickMap[i,j] = (map.GetPixel(i,j).B != 0);
		return clickMap;
	}
}