using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Diagnostics;
using System.ComponentModel;

namespace PowershellLab
{
    class Program
    {

        public static string Query { get; set; }

        static void Main(string[] args)
        {
            //Console.WriteLine(RunScript("Get-Process | Out-GridView"));
            //Console.WriteLine("done");
            //Console.ReadKey();

            //string scriptfile = @"D:\Powershell Scripts\SQLqueriesWithPowershell.ps1";
            //Command runPowershellFile = new Command(scriptfile);

            //string strCmdText;
            //strCmdText = @"D:\Powershell Scripts\SQLqueriesWithPowershell.ps1";
            //string PowershellPath = GetPowershellPath();

            //try
            //{
            //    //Process.Start(PowershellPath, strCmdText);
            //    Process.Start(strCmdText);
            //}
            //catch (Win32Exception exc)
            //{

            //    throw new Exception(exc.Message);
            //}

            string Dir = "D:\\Powershell Scripts\\";
            string command = @"dir" + " " + Dir;

            Console.WriteLine(RunScript("cd " + Dir));
            //Console.WriteLine(RunScript("dir"));
            //RunScript(@".\SQLqueriesWithPowershell.ps1");



            Console.WriteLine("ran PS1");
            Console.ReadKey();

        }

        private static string GetPowershellPath()
        {
            string path = "";
            path = RunScript("$PSHOME");

            path = path + "\\powershell.exe";
            return path;
        }

        private static string RunScript(string scriptText)
        {
            // create Powershell runspace

            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.

            pipeline.Commands.Add("Out-String");

            // execute the script

            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }
    }
   
}
