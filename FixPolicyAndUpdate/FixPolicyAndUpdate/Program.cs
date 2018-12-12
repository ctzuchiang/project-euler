using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace FixPolicyAndUpdate
{
    class Program
    {
        private static WindowsUpdateService _service;
        static void Main()
        {
            _service = new WindowsUpdateService();
            //_service.ResetWindowsUpdateService();

            ResetGroupPolicy();

            Console.WriteLine("Press any key to exist.");
            Console.ReadLine();
        }

        private static void ResetGroupPolicy()
        {
        }

    }
}
