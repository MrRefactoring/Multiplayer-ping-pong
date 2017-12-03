using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;
using Server.handlers;
using System.IO;

namespace Server
{
    class Program: ServerHandler
    {

        private string[] config;

        public Program()
        {
            try
            {
                config = OpenFile.open("./config.txt").Split('\n');
            } catch (IOException e)
            {
                Console.WriteLine("Конфигурационный файл не найдет, используется" +
                    " связка localhost:9090");
                config = new string[] { "localhost", "9090"};
            }
        }

        public void bind()
        {
            bind(config[0], int.Parse(config[1]));
        }

        public override void listenLoop()
        {
            base.listenLoop();  // Берем реализованный код из исходного метода
            while (true)
            {
                if (user == null)
                {
                    user = socket.Accept();
                    Console.WriteLine("New user is connected!");
                    
                } else
                {

                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.bind();
            program.listenLoop();
        }
    }
}
