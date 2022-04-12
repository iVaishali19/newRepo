using System;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SaaSProductsImport
{
    class Program
    {
        static void Main(string[] args)
        {
            //Can provide source as input currently taking "capterra" as fixed
            string source = "capterra";
            Console.WriteLine($"import {source}" );
            string filepath = Console.ReadLine(); // 
            Console.WriteLine($"importing:"); 
            

            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    // Load the stream
                    var yaml = new YamlStream();
                    yaml.Load(reader);

                    var mapping = ((YamlMappingNode)((YamlSequenceNode)yaml.Documents[0].RootNode)[0]);

                    foreach (var entry in mapping.Children)
                    {
                        if (((YamlScalarNode)entry.Key).Value == "tags")
                        {
                            ((YamlScalarNode)entry.Key).Value = "Categories";
                        }
                        if (((YamlScalarNode)entry.Key).Value == "twitter")
                        {
                            ((YamlScalarNode)entry.Value).Value = "@"+entry.Value;
                        }
                        Console.WriteLine($"{entry.Key}:{entry.Value}");
                    }

                }

            }
            catch
            {
                Console.WriteLine("You did not input a valid path");
            }
        }
    }
}
