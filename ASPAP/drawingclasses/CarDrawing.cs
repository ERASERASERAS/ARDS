using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ASPAP.drawingclasses
{
    class CarDrawing
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap carImage { get; set; }
        public Car car { get; set; }
        

        public CarDrawing(string fileName, Car car)
        {
            carImage = new Bitmap(Image.FromFile(fileName));
        }

        public void drawCar(Graphics g)
        {
            g.DrawImage(carImage, new Point(X, Y));
        }
    }
}
