using Newtonsoft.Json;
using SaaSProductsImport.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SaaSProductsImport
{
     public class SourceLogic
     {
       public static List<Dictionary<CapterraEnum, string>> GetCapterraYamlToObject(string filePath)
        {
            try
            {
                
                StreamReader reader = new StreamReader(filePath);
                Deserializer deserializer = new Deserializer();
                StringWriter textWriter = new StringWriter();
                var yamlObject = deserializer.Deserialize(reader);

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(textWriter, yamlObject);

                List<Dictionary<string, string>> capterraObj = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(textWriter.ToString());
                List<Dictionary<CapterraEnum, string>> capterraDictionaryList = new List<Dictionary<CapterraEnum, string>>();
                foreach (var obj in capterraObj)
                {
                    Dictionary<CapterraEnum, string> capterraDictionary = new Dictionary<CapterraEnum, string>();
                    foreach (var j in obj)
                    {
                        capterraDictionary.Add(j.Key.Contains("name") ? CapterraEnum.Name : (j.Key.Contains("tags")
                            ? CapterraEnum.Categories : CapterraEnum.Twitter), j.Key.Contains("twitter") ? "@" + j.Value : j.Value);
                    }
                    capterraDictionaryList.Add(capterraDictionary);
                }
                return capterraDictionaryList;
            }
            catch
            {
                Console.WriteLine("You did not input a valid path");
                return null;
            }
        }

       public static void GetSoftwareAdviceJsonToObject(string filePath)
        {

        }
    }
}
