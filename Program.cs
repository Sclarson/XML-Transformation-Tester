using System;
using System.IO;
using System.Linq;
using Microsoft.Web.Publishing.Tasks;

namespace TransformTesterConsole
{
    public class TransformArgs
    {
        public string SourceFile { get; set; }
        public string TransformFile { get; set; }
        public string DestinationFile { get; set; }

        public TransformArgs() { }

        public TransformArgs(string[] args)
        {
            this.SourceFile = args[0];
            this.TransformFile = args[1];
            if (args.Length > 2)
            {
                DestinationFile = args[2];
            }
            else
            {
                DestinationFile = args[0];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TransformArgs strongArgs = new TransformArgs();
            if (args.Any(p=> p.Contains("help")))
            {
                Console.WriteLine("Usage: transform.exe <original file>  <tranformation file> [output file]");
            }
            else if (args.Length > 1)
            {
                strongArgs = new TransformArgs(args);
            }
            else
            {
                Console.Write("Enter the name of original configuration file:");
                strongArgs.SourceFile = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

                Console.Write("Enter the name of the transformation file:");
                strongArgs.TransformFile = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

                Console.Write("Enter the name of the output file:");
                strongArgs.DestinationFile = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());
            }

            var successful = ProcessTransform(strongArgs);
            Console.WriteLine("Transformer returned {0}",successful);

            Environment.ExitCode = successful ? 0 : 1;
        }

        private static bool ProcessTransform(TransformArgs args)
        {
            if (string.Equals(args.SourceFile, args.DestinationFile))
            {
                var tempFileName = Path.GetTempFileName();
                File.Delete(tempFileName);
                File.Copy(args.SourceFile, tempFileName);
                args.SourceFile = tempFileName;
            }

            var engine = new TransformOnlyBuildEngine();

            var transformer = new TransformXml
            {
                BuildEngine = engine,
                Source = args.SourceFile,
                Destination = args.DestinationFile,
                Transform = args.TransformFile
            };

            return transformer.Execute();
        }
    }
}
