﻿/*
 * Created by SharpDevelop.
 * User: Lindenk
 * Date: 11/23/2014
 * Time: 1:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Newtonsoft.Json;

namespace MissTaryGame.Json
{
	/// <summary>
	/// Loads/unloads json into the given object type.
	/// </summary>
	
	public static class JsonLoader
	{
		public const string PATH_PREFIX = "assets/";
		private const string RESOURCE_EXT = ".json";
		
		/// <param name="path">Path to json from assets/</param>
		/// <returns></returns>
		public static T Load<T>(string path) {
			return LoadStream<T>(File.ReadAllText( PATH_PREFIX + path + RESOURCE_EXT));
		}
		
		public static T LoadStream<T>(string stream) {
			JsonSerializerSettings jsonSettings = new JsonSerializerSettings {
				Error = (sender, arg) =>
				{
					throw new Exception(arg.ToString());
				}
			};
			
			T obj = JsonConvert.DeserializeObject<T>(stream, jsonSettings);
			
			if(obj.Equals(null)) {
				throw new Exception("Unable to parse Json: " + stream);
			}
			
			return obj;
		}
		
		public static void Unload<T>(string path, T obj) {
			File.WriteAllText(path + RESOURCE_EXT, JsonConvert.SerializeObject(obj));
		}
	}
}
