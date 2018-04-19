using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonelMSystem.Utils
{
    class LogUtils
    {

        public static void log2txt(string information)
        {
            string filePath = System.Windows.Forms.Application.StartupPath + "\\log.txt";
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath, true);
                writer.WriteLine($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}{information}");
            }
            catch (IOException e)
            {
                return;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
