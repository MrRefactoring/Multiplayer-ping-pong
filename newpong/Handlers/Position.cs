using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace newpong.Handlers
{
    class Position
    {
        public Rectangle init(double width, double height, Thickness position)
        {
            Rectangle obj = new Rectangle();
            obj.Width = width;
            obj.Height = height;
            obj.Fill = (Brush)new BrushConverter().ConvertFrom("#FFF4F4F5");
            obj.Stroke = Brushes.Black;
            obj.Margin = position;
            return obj;
        }

    }
}
