using System;
using System.IO;
using Microsoft.Web.Publishing.Tasks;

namespace TransformTesterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new TransformOnlyBuildEngine();
            
            Console.Write("Enter the name of original configuration file:");
            var originalFile = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

            Console.Write("Enter the name of the transformation file:");
            var transformationFile = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

            Console.Write("Enter the name of the output file:");
            var outputFile =Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

            var transformer = new TransformXml
                                  {
                                      BuildEngine = engine,
                                      Source = originalFile,
                                      Destination = outputFile,
                                      Transform = transformationFile
                                  };

            bool execute = transformer.Execute();
            Console.WriteLine("Transformer returned {0}",execute);
        }
    }
}
