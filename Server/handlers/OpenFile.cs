using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server.handlers
{
    class OpenFile
    {

        public static string open(string path)
        {
            try
            {
                return File.ReadAllText(path);  // Читаем текст из файла
            } catch (IOException e)
            {
                throw e;
            }
        }

    }
}
