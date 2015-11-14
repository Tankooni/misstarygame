using System;
using System.IO;
using Newtonsoft.Json;

namespace MissTaryGame.Json
{
    public static class JsonWriter
    {
        public const string SAVE_PREFIX = "save/";

        public static void Save(SaveType saveType, object objectToSave, string subfolderName)
        {
            string path = JsonLoader.PATH_PREFIX + SAVE_PREFIX;
            string fileName = "";
            switch (saveType)
            {
                case SaveType.Scenes:
                    path += "scenes/" + subfolderName + "/";
                    fileName = "MetaData";
                    break;
                case SaveType.Events:
                    throw new NotImplementedException("Events saving not implemented yet");
                    break;
                case SaveType.Inventory:
                    throw new NotImplementedException("Inventory saving not implemented yet");
                    break;
                case SaveType.MainConfig:
                    fileName = "MainConfig";
                    break;
                default:
                    break;
            }
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += fileName + JsonLoader.RESOURCE_EXT;
            File.WriteAllText(path, JsonConvert.SerializeObject(objectToSave));
        }
        //public static WriteObjectToDisk<T>(string path)
        //{

        //}
    }

    public enum SaveType
    {
        Scenes,
        Events,
        Inventory,
        MainConfig
    }
}
