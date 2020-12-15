using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleSystem.File
{
    class Captures
    {
        public static string GetCaptureDir()
        {
            CreateDir();
            return Path.Combine(__dirname, "ScreenShoot");
        }

        private static string __dirname = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        private static void CreateDir()
        {
            if (!Directory.Exists(Path.Combine(__dirname, "ScreenShoot")))
            {
                Directory.CreateDirectory(Path.Combine(__dirname, "ScreenShoot"));
            }
        }

        public static List<string> GetCaptures()
        {
            List<string>  caps = new List<string>();
            int i = 0;
            foreach(string file in System.IO.Directory.GetFiles(GetCaptureDir()))
            {
                if (caps.Count < 6)
                {
                    caps.Add(Path.GetFileName(file));
                }
                else
                {
                    i++;
                }
            }
            if (i > 0)
            {
                caps.Add($"+{i} others files...");
            }
            return caps;
        }
    }
}
