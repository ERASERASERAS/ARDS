using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ASPAP.drawingclasses
{
    public class SignDrawing
    {
       
        private Point coordinats = new Point();
        private Sign sign;
       

        public SignDrawing()
        {
            sign = new Sign(80);
        }

        public SignDrawing(Sign sign)
        {
            this.sign = sign;
        }

        public Point COORDINATS
        {
            get { return coordinats; }
            set { coordinats = value; }
        }

        public Sign SIGN
        {
            get { return sign; }
            set { sign = value; }
        }

       

        public Graphics getSignGraphic(Graphics signPictureBoxGraphic) 
        {
            signPictureBoxGraphic.Clear(Color.FromName("ControlLight"));
            signPictureBoxGraphic.FillEllipse(new SolidBrush(Color.Red), 0, 0, 50, 50);
            signPictureBoxGraphic.FillEllipse(new SolidBrush(Color.White), 5, 5,40, 40);
            signPictureBoxGraphic.DrawString(sign.MAXSPEED.ToString(), new Font("Microsoft Sans Serif", 15), new SolidBrush(Color.Black), new PointF(12f,13f));          
            return signPictureBoxGraphic;
        }
    }
}
