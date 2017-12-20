using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ASPAP.drawingclasses
{
    class StripeDrawing
    {
        public Stripe stripe { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public StripeDrawing(int coordX, int coordY)
        {
            X = coordX;
            Y = coordY;
        }
        
        public void drawStripe(Graphics g, int width, int height)
        {
            g.FillRectangle(new SolidBrush(Color.SlateGray), new Rectangle(X, Y, width, height));
        }

        public void drawBrokenLine(Graphics g, int coordX1, int coordY1, int coordX2, int coordY2)
        {
            int i = 0;
            while (i + 25 < coordX2)
            {                
                g.DrawLine(new Pen(Color.White, 1), i + 5, coordY1, i + 20, coordY2);
                i += 20;
            }
        }

        public void drawSolidLine(Graphics g, int coordX1, int coordY1, int coordX2, int coordY2)
        {
            g.DrawLine(new Pen(Color.White, 1), coordX1, coordY1, coordX2, coordY2); 
        }


        public void drawControlStripe(Graphics g, int coordX, int coordY, int width, int height)
        {
        }
    }
}
