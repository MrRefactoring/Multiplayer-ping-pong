using System;
using System.Windows;
using System.Windows.Input;
using PingPong.PlayGround.Exceptions;
using PingPong.PlayGround.API;
using Lib.API;

namespace PingPong.PlayGround
{
    public partial class PlayGround : Window
    {

        private double width, heigth;
        private GameLoop gameLoop;
        private Config config;

        public PlayGround()
        {
            InitializeComponent();
        }

        private void CustomConstructor()
        {
            config = new Config(width, heigth, ball, left, right, score);
            gameLoop = new GameLoop(config);
            gameLoop.start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            gameLoop.stop();  // При закрытии окна останавливаем все потоки
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            gameLoop.setKey(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            gameLoop.setKey();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = this.Content as FrameworkElement;
            if (window != null)
            {
                width = window.ActualWidth;  // Получаем действительный размер окна
                heigth = window.ActualHeight;  // Получаем действительный размер окна
                CustomConstructor();
            }
            else
            {
                throw new WindowNotLoadedException(String.Format("{0} window not loaded", this.Title));
            }
        }
    }
}
