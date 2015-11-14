using System;
using System.IO;
using Newtonsoft.Json;

namespace MissTaryGame.Json
{
    public static class JsonWriter
    {
        public static void Save()
        {
            var ss = JsonConvert.SerializeObject(Utility.MainConfig);
            File.WriteAllText(JsonLoader.PATH_PREFIX + "save/MainConfig" + JsonLoader.RESOURCE_EXT, ss);
        }
        //public static WriteObjectToDisk<T>(string path)
        //{

        //}
    }

    public enum SaveType
    {
        Scene,
        Player,
        Main
    }
}
