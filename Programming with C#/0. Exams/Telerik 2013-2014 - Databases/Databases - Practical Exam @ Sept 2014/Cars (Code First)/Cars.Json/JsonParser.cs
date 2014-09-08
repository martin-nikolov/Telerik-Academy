namespace Cars.Json
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Cars.Json.JsonModels;
    using Newtonsoft.Json;
    
    public class JsonParser
    {
        private const string JsonExtension = "*.json";

        public IList<CarMap> DeserializeJsonObjects(string directoryPath)
        {
            var deserializedObjects = new List<CarMap>();
            var matchedJsonFiles = this.GetFilesByGivenExtension(directoryPath, JsonExtension);

            foreach (var jsonFilePath in matchedJsonFiles)
            {
                var jsonContent = this.ReadFileContent(jsonFilePath);
                var jsonObjects = JsonConvert.DeserializeObject<IList<CarMap>>(jsonContent);
                deserializedObjects.AddRange(jsonObjects);
            }

            return deserializedObjects;
        }
    
        private string[] GetFilesByGivenExtension(string directoryPath, string extension)
        {
            var matchedFiles = Directory.GetFiles(directoryPath, extension);
            return matchedFiles;
        }

        private string ReadFileContent(string jsonFilePath)
        {
            var content = File.ReadAllText(jsonFilePath);
            return content;
        }
    }
}