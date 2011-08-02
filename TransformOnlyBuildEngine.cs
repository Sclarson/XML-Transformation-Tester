using System;
using System.Collections;
using Microsoft.Build.Framework;

namespace TransformTesterConsole
{
    public class TransformOnlyBuildEngine : IBuildEngine
    {
        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs)
        {
            throw new NotImplementedException();
        }

        public bool ContinueOnError
        {
            get { throw new NotImplementedException(); }
        }

        public int LineNumberOfTaskNode
        {
            get { return 0; }
        }

        public int ColumnNumberOfTaskNode
        {
            get { return 0; }
        }

        public string ProjectFileOfTaskNode
        {
            get { return string.Empty; }
        }
    }
}