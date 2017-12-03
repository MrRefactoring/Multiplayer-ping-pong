using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace newpong
{
    class Config
    {

        private double _windowWidth = 525;
        private double _windowHeight = 350;

        private double _padWidth = 25;
        private double _padHeight = 100;

        private double _ballSize = 25;

        public double padWidth {
            get
            {
                return _padWidth;
            }
        }

        public double padHeight {
            get
            {
                return _padHeight;
            }
        }

        public double ballSize {
            get
            {
                return _ballSize;
            }
        }

        public Thickness ballPosition
        {
            get
            {
                return new Thickness(windowWidth / 2 - ballSize, windowHeight / 2 - ballSize, 0, 0);
            }
        }

        public double windowWidth
        {
            get
            {
                return _windowWidth;
            }
        }

        public double windowHeight
        {
            get
            {
                return _windowHeight;
            }
        }

    }
}
