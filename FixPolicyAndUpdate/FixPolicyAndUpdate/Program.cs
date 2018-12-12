using System;

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

            Console.WriteLine("Press any key to exist.");
            Console.ReadLine();
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
