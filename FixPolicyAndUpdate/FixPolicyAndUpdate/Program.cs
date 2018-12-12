using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FixPolicyAndUpdate
{
    class Program
    {
        private static WindowsUpdateService _service;
        static void Main()
        {
            _service = new WindowsUpdateService();
            _service.ResetWindowsUpdateService();

            ResetGroupPolicy();

            UpdateGroupPolicy();
            
            Console.WriteLine("Press any key to exist.");
            Console.ReadLine();
        }

        private static void UpdateGroupPolicy()
        {
            FileInfo execFile = new FileInfo("gpupdate.exe");
            Process proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.FileName = execFile.Name;
            proc.StartInfo.Arguments = "/force";
            proc.Start();
            //Wait for GPUpdate to finish
            while (!proc.HasExited)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Update group policy done.");
        }

        private static void ResetGroupPolicy()
        {
            Console.WriteLine("Reset windows update group policy.\n");
            try
            {
                var gpRegistryPath = @"C:\Windows\System32\GroupPolicy\Machine\Registry.pol";
                
                var polFile = new PolFile();
                polFile.LoadFile(gpRegistryPath);
                polFile.DeleteContainer(@"Software\Policies\Microsoft\Windows\WindowsUpdate");
                polFile.SaveFile(gpRegistryPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

    }
}
