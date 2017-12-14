using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Lib.API
{
    class CollisionDetection
    {

        private Config config;

        public CollisionDetection(Config config)
        {
            this.config = config;
        }

        public bool topCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Top <= 0 + offset;
        }

        public bool bottomCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Top + element.Height >= config.heigth - offset;
        }

        public bool leftCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Left <= 0 + offset;
        }

        public bool rightCollision(Rectangle element, double offset = 0)
        {
            return element.Margin.Left + element.Width >= config.width - offset;
        }

        public bool rightPadCollision()
        {
            return config.right.Margin.Left < config.ball.Margin.Left + config.ball.Width &&
                config.right.Margin.Top - config.ball.Height / 2 <= config.ball.Margin.Top &&
                config.right.Margin.Top + config.right.Height >= config.ball.Margin.Top;

        }

        public bool leftPadCollision()
        {
            
            return config.left.Margin.Left + config.left.Width >= config.ball.Margin.Left &&
                config.left.Margin.Top - config.ball.Height / 2 <= config.ball.Margin.Top &&
                config.left.Margin.Top + config.left.Height >= config.ball.Margin.Top;
        }

    }
}
