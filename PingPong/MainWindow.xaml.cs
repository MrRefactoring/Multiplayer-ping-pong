using System.Windows;

namespace PingPong
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadGame(object sender, RoutedEventArgs e)
        {
            new PlayGround.PlayGround().Show();  // Загужаем игровое поле
            this.Close();  // Закрываем текущее окно
        }

    }
}
