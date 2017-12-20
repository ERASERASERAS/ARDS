using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ASPAP.drawingclasses
{
    class LineDrawing
    {
        public void drawBrokenLine(Graphics g, int X1, int Y1, int X2, int Y2)
        {
            int i = 0;
            while (i + 25 < X2)
            {
                g.DrawLine(new Pen(Color.White, 1), i + 5, Y1, i + 20, Y2);
                i += 20;
            }
        }

        public void drawSolidLine(Graphics g, int X1, int Y1, int X2, int Y2)
        {
            g.DrawLine(new Pen(Color.White, 1), X1, Y1, X2, Y2);
        }
    }
}
