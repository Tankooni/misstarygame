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
using System.Linq;
using MissTaryGame.Json;
using System.IO;
using Indigo;

namespace MissTaryGame.Json.Models
{
	/// <summary>
	/// Description of GameEvent.
	/// </summary>
	public class GameEvent
	{
		public string Name { get; set; }
		public Action[] Actions { get; set; }
		public GameEvent[] Dependencies { get; set; }
        public GameEvent[] Restrictions { get; set; }
		
		
		public static Dictionary<string, GameEvent> loadGameEvents(string path) {
			Dictionary<string, GameEvent> eventDict = new Dictionary<string, GameEvent>();
			
			var files = Utility.RetrieveFilePathForFilesInDirectory(path, "*.json");
			foreach( var file in files) {
				var evt = JsonLoader.Load<GameEvent>(file, false);
				eventDict.Add(Path.GetFileNameWithoutExtension(file), evt);
			}
			
			return eventDict;
		}

        public static bool checkDependanciesAndRestrictions(GameEvent[] deps, GameEvent[] rests = null) {
            string[] depStrs = deps?.Select(x => x.Name).ToArray();
            string[] restStrs = rests?.Select(x => x.Name).ToArray();

            return checkDependanciesAndRestrictions(depStrs, restStrs);
        }
        public static bool checkDependanciesAndRestrictions(string[] deps, string[] rests=null) {
			if( deps == null) {
                deps = new string[0];
			}
            if( rests == null) {
                rests = new string[0];
            }
			
			var world = (DynamicSceneWorld)FP.World;
			bool depsFinished = deps.All((string e) => world.completedEvents.ContainsKey(e));
            bool restFinished = rests.Any((string e) => world.completedEvents.ContainsKey(e));

            return depsFinished && !restFinished;
		}
	}
}
