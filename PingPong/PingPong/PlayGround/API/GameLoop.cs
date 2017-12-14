using System;
using System.Windows;
using System.Threading;
using System.Windows.Input;
using Lib;
using Lib.API;

namespace PingPong.PlayGround.API
{
    class GameLoop: Window
    {

        private Config config;
        private Logic logic;

        private Thread gameThread;
        private bool running = false;

        private string _key = null;

        public GameLoop(Config config)
        {
            this.config = config;
        }

        public void start()
        {
            if (!running)  // Если игровой цикл не запущен
            {
                logic = new Logic(config);
                gameThread = new Thread(() => {
                    Dispatcher.Invoke(() => {
                        logic.setStartPosition();
                    });
                    Thread.Sleep(500);  // Ждем 500 милисекунд для того, чтобы передать управление после анимации
                    long lastUpdate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    while (true)
                    {
                        if (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - lastUpdate
                        >= 1000 / config.fps && config.canUpdate)
                        {
                            Dispatcher.Invoke(() => {
                                logic.move(_key);
                            });
                            lastUpdate = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                        }
                    }
                });
                gameThread.Start();  // Запускаем игровой цикл
                running = true;
            }
        }

        public void stop()
        {
            if (running)  // Если игровой цикл запущен
            {
                try
                {
                    gameThread.Abort();  // Убиваем игровой цикл
                } catch (ThreadAbortException e)
                {
                    Application.Current.Shutdown();  // Принудительно закрываем приложение
                }
                running = false;
            }
        }

        public void setKey()
        {
            _key = null;
        }

        public void setKey(Key key)
        {
            if (key == Key.Up)
            {
                _key = "up";
            } else if (key == Key.Down)
            {
                _key = "down";
            }
        }

    }
}
