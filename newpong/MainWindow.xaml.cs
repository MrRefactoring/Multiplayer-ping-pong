using newpong.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace newpong
{
    public partial class MainWindow : Window {

        Config config;

        public MainWindow()
        {
            InitializeComponent();
            initField();  // Вызываем настройку поля
        }

        private void initField()  // Метод для начальной настройки игрового поля
        {
            config = new Config();

            this.Width = config.windowWidth;
            this.Height = config.windowHeight;

            player.Width = config.padWidth;
            player.Height = config.padHeight;
            player.VerticalAlignment = VerticalAlignment.Center;

            enemy.Width = config.padWidth;
            enemy.Height = config.padHeight;
            /*enemy.VerticalAlignment = VerticalAlignment.Center;
            enemy.HorizontalAlignment = HorizontalAlignment.Right;
            enemy.HorizontalAlignment = HorizontalAlignment.Stretch;
            //enemy.Margin = new Thickness(enemy.Margin.Left - 25, enemy.Margin.Top, 0, 0);
            Console.WriteLine(enemy.Margin.ToString());*/

            ball.Width = config.ballSize;
            ball.Height = config.ballSize;
            ball.Margin = config.ballPosition;

        }

    }
}
