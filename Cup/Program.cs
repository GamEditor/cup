using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Cup
{
    class Program
    {
        [DllImport("shell32.dll")]
        private static extern long FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);

        private static void Main(string[] args)
        {
            RegisteryWriter.RegisterThisApp();

            if (args.Length > 0)
            {
                string url = "";

                if (args[0].IndexOf("cup://") == 0)
                {
                    url = args[0].Replace("cup://", "");
                }
                else if (args[0].IndexOf("cup:") == 0)
                {
                    url = args[0].Replace("cup:", "");
                }
                else
                {
                    return;
                }

                Process.Start("chrome.exe", url);
            }
        }
    }
}
