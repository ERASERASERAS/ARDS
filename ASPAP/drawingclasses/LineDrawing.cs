using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ASPAP.drawingclasses
{
    class LineDrawing
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public bool whichLine { get; set; }  //true - broken, false - solid

        public LineDrawing(int X1val, int Y1val, int X2val, int Y2val)
        {
            X1 = X1val;
            Y1 = Y1val;
            X2 = X2val;
            Y2 = Y2val;
        }

        public void drawBrokenLine(Graphics g)
        {
            int i = 0;
            while (i + 25 < X2)
            {
                g.DrawLine(new Pen(Color.White, 1), i + 5, Y1, i + 20, Y2);
                i += 20;
            }
        }

        public void drawSolidLine(Graphics g)
        {
            g.DrawLine(new Pen(Color.White, 1), X1, Y1, X2, Y2);
        }

        public void drawSomeLine(Graphics g)
        {
            if (this.whichLine)
            {
                drawBrokenLine(g);
            }
            else
            {
                drawSolidLine(g);
            }
        }
    }
}
