using Microsoft.Win32;

namespace Cup
{
    public static class RegisteryWriter
    {
        public static void RegisterThisApp()
        {
            string fileLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"cup"))
            {
                key.SetValue("", "URL:cup Protocol");   // (Default)
                key.SetValue("URL Protocol", "cup");
                key.Close();
            }

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"cup\DefaultIcon"))
            {
                key.SetValue("", fileLocation);
                key.Close();
            }

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"cup\shell"))
            {
                key.Close();
            }

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"cup\shell\open"))
            {
                key.Close();
            }

            using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(@"cup\shell\open\command"))
            {
                key.SetValue("", fileLocation + " \"%1\"");
                key.Close();
            }
        }
    }
}
