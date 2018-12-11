using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace FixPolicyAndUpdate
{
    class Program
    {
        static void Main()
        {
            //ResetWindowsUpdateService();
            ResetGroupPolicy();

            Console.WriteLine("Press any key to exist.");
            Console.ReadLine();
        }

        private static void ResetGroupPolicy()
        {
        }

        private const string ServiceName = "wuauserv"; //Windows Update Service Name

        private static void ResetWindowsUpdateService()
        {
            var sc = new ServiceController(ServiceName);

            if (sc.Status == ServiceControllerStatus.Running)
            {
                Console.WriteLine("Stop windows update service.\n");
                sc.Stop();
            }
            else
            {
                Console.WriteLine("Skip: Windows update service already stop.\n");
            }

            Thread.Sleep(2000);

            DeleteDirectory("C:\\Windows\\SoftwareDistribution");

            Thread.Sleep(2000);

            sc = new ServiceController(ServiceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine("Start windows update service.\n");
                sc.Start();
            }
            else
            {
                Console.WriteLine("Skip: Windows update service already running.\n");
            }

        }

        private static void DeleteDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Skip: Already reset windows update.\n");
                return;
            }

            Console.WriteLine("Reset windows update directory.\n");

            try
            {
                RecursiveDelete(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Please run as administrator!!\n");
            }
        }

        private static void RecursiveDelete(string path)
        {
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                RecursiveDelete(dir);
            }

            Directory.Delete(path, false);
        }
    }
}
