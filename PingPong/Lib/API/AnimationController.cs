using System;
using System.Windows;
using System.Windows.Media.Animation;
using Lib.Exceptions;
using System.Windows.Shapes;
using System.Threading;

namespace Lib.API
{
    class AnimationController: Window
    {

        private Config config;

        public AnimationController(Config config)
        {
            this.config = config;
        }

        public void setStartPosition(Rectangle element, double width, double heigth)
        {
            config.canUpdate = false;
            ThicknessAnimation animation = new ThicknessAnimation
            {
                To = new Thickness(width, heigth, 0, 0),
                Duration = TimeSpan.FromSeconds(1)
            };
            animation.Completed += new EventHandler((obj, arg) => {
                element.BeginAnimation(MarginProperty, null);
                element.Margin = new Thickness(width, heigth, 0, 0);
                config.canUpdate = true;
            });
            element.BeginAnimation(MarginProperty, animation);
        }

        public void setStartPosition(Rectangle element, double[] position)
        {
            if (position.Length != 2)  // Проверка на дурака
            {
                throw new PositionNotFullySpecifiedException(
                    String.Format("position length = {0}, expected 2", position.Length));
            }
            config.canUpdate = false;
            ThicknessAnimation animation = new ThicknessAnimation
            {
                To = new Thickness(position[0], position[1], 0, 0),
                Duration = TimeSpan.FromSeconds(1),
                IsAdditive = true
            };
            animation.Completed += new EventHandler((obj, arg) => {
                element.BeginAnimation(MarginProperty, null);
                element.Margin = new Thickness(position[0], position[1], 0, 0);
                config.canUpdate = true;
            });
            element.BeginAnimation(MarginProperty, animation);
        }

    }
}
