
using SaaSProductsImport.model;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using Newtonsoft.Json;
using System.Collections.Generic;
using SaaSProductsImport.enums;

namespace SaaSProductsImport
{
    public class Program
    {
        static void ShowOutput(string filePath, string source = "capterra")
        {
            if (File.Exists(filePath))
            {
                if (source.ToLower() == SourcesEnum.Capterra.ToString().ToLower()) // for Capterra source
                {
                    List<Dictionary<CapterraEnum, string>> capterraYamlObject = SourceLogic.GetCapterraYamlToObject(filePath);

                    foreach (var capterraDictionary in capterraYamlObject)
                    {
                        foreach (var obj in capterraDictionary)
                        {
                            Console.Write("importing:");
                            Console.Write(obj.Key + ":" + obj.Value);

                        }
                        Console.Write("\n");
                    }
                }
                else if (source.ToLower() == SourcesEnum.SoftwareAdvice.ToString().ToLower())
                {
                    SourceLogic.GetSoftwareAdviceJsonToObject(filePath); // can be implement for json type input files in feed-products
                }
            }
        }
       
        

        static void Main(string[] args)
        {
            //string filePath = "C:/Users/Vaishali/source/repos/SaaSProductsImport/SaaSProductsImport/feed-products/capterra.yaml";

            var filepath = new Argument<string>
             ("filepath", "provide file path");

            var source = new Option<string>
             ("--source", "source");
            source.IsRequired = true;
            source.AddAlias("--s");

            var cmd = new RootCommand();
            cmd.AddArgument(filepath);
            cmd.AddOption(source);
            cmd.Handler = CommandHandler.Create<string, string>(ShowOutput);
            cmd.Invoke(args);

        }
    }
}

///  dotnet run -- .\feed-products\capterra.yaml --source capterra   hit this command to run program in CLI