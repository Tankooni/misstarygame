/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/24/2014
 * Time: 3:02 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using MissTaryGame.Json;
using System.IO;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of GameEvent.
	/// </summary>
	public class GameEvent
	{
		public string Name { get; set; }
		public Action[] Actions { get; set; }
		public GameEvent[] Dependancies { get; set; }
		
		
		public static Dictionary<string, GameEvent> loadGameEvents(string path) {
			Dictionary<string, GameEvent> eventDict = new Dictionary<string, GameEvent>();
			
			var files = Utility.RetrieveFilePathForFilesInDirectory(path, "*.json");
			foreach( var file in files) {
				var evt = JsonLoader.Load<GameEvent>(path);
				eventDict.Add(Path.GetFileNameWithoutExtension(file), evt);
			}
			
			return eventDict;
		}
	}
}
