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
        public LinkedList<CarDrawing> carsDrawings { get; set; }
        //public int width, heig

        public StripeDrawing(int coordX, int coordY)
        {
            X = coordX;
            Y = coordY;
            carsDrawings = new LinkedList<CarDrawing>();
        }
        
        public void drawStripe(Graphics g, int width, int height)
        {
            g.FillRectangle(new SolidBrush(Color.SlateGray), new Rectangle(X, Y, width, height));
        }

        

        public bool canGenerateNewCar(int coordX, int k) // k = 1(right), k = -1 (left)
        {
            bool result = false;
            if (carsDrawings.Count > 0)
            {
                if (k * (carsDrawings.Last.Value.X - coordX) >= 50)
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            return result;
        }

        public bool firstCarIsLeaved(int coordX)
        {
            bool result = false;
            if (this.carsDrawings.First.Value.car.speed < 0)
            {
                if (this.carsDrawings.First.Value.X >= coordX)
                {
                    result = true;
                }
            }
            else
            {
                if (this.carsDrawings.First.Value.X <= coordX)
                {
                    result = true;
                }
            }
            
            return result;
        }

        public void correctSpeeds()
        {
            if (this.carsDrawings.Count > 1)
            {
                LinkedListNode<CarDrawing> cd = this.carsDrawings.First;
                    while (cd.Next != null)
                    {
                           if (this.carsDrawings.First.Value.car.initialSpeed < 0)
                           {
                                if (Math.Abs(cd.Next.Value.car.speed) >= Math.Abs(cd.Value.car.speed))
                                {
                                    if (cd.Value.X - cd.Next.Value.X <= 110)
                                    {
                                        cd.Next.Value.car.speed = cd.Value.car.speed;
                                        if (cd.Value.car.stayByTrafficLight)
                                        {
                                            cd.Next.Value.car.stayByTrafficLight = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (cd.Next.Value.car.speed > cd.Value.car.speed)
                                {
                                    if (cd.Value.X - cd.Next.Value.X >= -110)
                                    {
                                        cd.Next.Value.car.speed = cd.Value.car.speed;
                                        if (cd.Value.car.stayByTrafficLight)
                                        {
                                            cd.Next.Value.car.stayByTrafficLight = true;
                                        }
                                    }
                                }
                            }
                        
                        cd = cd.Next;
                    }
                
            }
            
        }

        public void drawControlStripe(Graphics g, int coordX, int coordY, int width, int height)
        {
        }
    }
}
