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
        public int width { get; set; }
        public int height { get; set; }

        public StripeDrawing(int coordX, int coordY)
        {
            X = coordX;
            Y = coordY;
            carsDrawings = new LinkedList<CarDrawing>();
        }
        
        public void drawStripe(Graphics g, int width, int height)
        {
            g.FillRectangle(new SolidBrush(Color.SlateGray), new Rectangle(X, Y, width, height));
            this.width = width;
            this.height = height;
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
                                        else
                                        {
                                            cd.Next.Value.car.overtaking = true;
                                        }
                                    }
                                }

                            }
                            else
                            {
                                if (cd.Next.Value.car.speed > cd.Value.car.speed)
                                {
                                    if (cd.Value.X - cd.Next.Value.X >= -160)
                                    {
                                        cd.Next.Value.car.speed = cd.Value.car.speed;
                                        if (cd.Value.car.stayByTrafficLight)
                                        {
                                            cd.Next.Value.car.stayByTrafficLight = true;
                                        }

                                        else
                                        {
                                            cd.Next.Value.car.overtaking = true;
                                        }
                                    }
                                }
                            }
                        
                        cd = cd.Next;
                    }
                
            }
            
        }

        //public void drawControlStripe(Graphics g, int coordX, int coordY, int width, int height)
        //{
        //}

        public void overtaking()
        {
            if (Road.getRoad().checkOppurtunityForOvertaking())
            {
                //for(int i =0; i < carsDrawings.Count; i++)

                for(int i = 0; i < carsDrawings.Count; i++)//foreach (CarDrawing cd in carsDrawings)
                {
                    CarDrawing cd = carsDrawings.ElementAt(i);
                    if (cd.car.overtaking == true)
                    {
                        Stripe stripeForOverTaking = Road.getRoad().getStripeForOvertaking(this.stripe,
                                                                cd.car.initialSpeed < 0 ? "RIGHT" : "LEFT");
                        StripeDrawing stripeDrawingForOvertaking = RoadDrawing.getRoadDrawing().getStripeDrawingForOverTaking(stripeForOverTaking);
                        Car car = cd.car;
                        this.stripe.CARS.Remove(cd.car);
                        CarDrawing carDrawing = cd;
                        this.carsDrawings.Remove(cd);

                        if (cd.car.initialSpeed < 0)
                        {
                            if (stripeDrawingForOvertaking.carsDrawings.Count > 0)
                            {
                                if (stripeDrawingForOvertaking.carsDrawings.First.Value.X + 55 < cd.X)
                                {
                                    stripeDrawingForOvertaking.carsDrawings.AddFirst(cd);
                                    stripeDrawingForOvertaking.stripe.CARS.AddFirst(car);
                                    cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                    cd.car.speed = cd.car.initialSpeed;
                                    cd.car.overtaking = false;
                                }
                                else if (stripeDrawingForOvertaking.carsDrawings.Last.Value.X - 55 > cd.X)
                                {
                                    stripeDrawingForOvertaking.carsDrawings.AddLast(cd);
                                    stripeDrawingForOvertaking.stripe.CARS.AddLast(car);
                                    cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                    cd.car.speed = cd.car.initialSpeed;
                                    cd.car.overtaking = false;
                                }
                                else
                                {
                                    if (getCarDrawingForAddAfterForOvetaking(cd, stripeDrawingForOvertaking) != null)
                                    {
                                        stripeDrawingForOvertaking.carsDrawings.AddAfter(stripeDrawingForOvertaking.carsDrawings.Find(getCarDrawingForAddAfterForOvetaking(cd, stripeDrawingForOvertaking)), cd);
                                        stripeDrawingForOvertaking.stripe.CARS.AddLast(car);
                                        cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                        cd.car.speed = cd.car.initialSpeed;
                                        cd.car.overtaking = false;
                                    }
                                }
                            }
                            else
                            {
                                stripeDrawingForOvertaking.carsDrawings.AddFirst(cd);
                                stripeDrawingForOvertaking.stripe.CARS.AddFirst(car);
                                cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                cd.car.speed = cd.car.initialSpeed;
                                cd.car.overtaking = false;
                            }
                        }
                        else if (cd.car.initialSpeed > 0)
                        {
                            if (stripeDrawingForOvertaking.carsDrawings.Count > 0)
                            {
                                if (stripeDrawingForOvertaking.carsDrawings.First.Value.X - 55 > cd.X)
                                {
                                    stripeDrawingForOvertaking.carsDrawings.AddFirst(cd);
                                    stripeDrawingForOvertaking.stripe.CARS.AddFirst(cd.car);
                                    cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                    cd.car.speed = cd.car.initialSpeed;
                                    cd.car.overtaking = false;
                                }
                                else if (stripeDrawingForOvertaking.carsDrawings.Last.Value.X + 55 < cd.X)
                                {
                                    stripeDrawingForOvertaking.carsDrawings.AddFirst(cd);
                                    stripeDrawingForOvertaking.stripe.CARS.AddLast(car);
                                    cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                    cd.car.speed = cd.car.initialSpeed;
                                    cd.car.overtaking = false;
                                }
                                else
                                {
                                    if (getCarDrawingForAddAfterForOvetaking(cd, stripeDrawingForOvertaking) != null)
                                    {
                                        stripeDrawingForOvertaking.carsDrawings.AddAfter(stripeDrawingForOvertaking.carsDrawings.Find(getCarDrawingForAddAfterForOvetaking(cd, stripeDrawingForOvertaking)), cd);
                                        stripeDrawingForOvertaking.stripe.CARS.AddLast(car);
                                        cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                        cd.car.speed = cd.car.initialSpeed;
                                        cd.car.overtaking = false;
                                    }
                                }
                            }
                            else
                            {
                                stripeDrawingForOvertaking.carsDrawings.AddFirst(cd);
                                stripeDrawingForOvertaking.stripe.CARS.AddFirst(cd.car);
                                cd.Y = stripeDrawingForOvertaking.Y + height / 2;
                                cd.car.speed = cd.car.initialSpeed;
                                cd.car.overtaking = false;
                            }
                        }
                        
                    }
                }

            }
        }

        private CarDrawing getCarDrawingForAddAfterForOvetaking(CarDrawing cdForOvertaking, StripeDrawing stripeDrawingForOvertaking)
        {
            CarDrawing returnedCarDrawing = null;
            if (stripeDrawingForOvertaking.carsDrawings.Count > 0)
            {
                for (int i = 0; i < stripeDrawingForOvertaking.carsDrawings.Count - 1; i++)
                {
                    if (cdForOvertaking.car.initialSpeed < 0)
                    {
                        if (cdForOvertaking.X + 55 < stripeDrawingForOvertaking.carsDrawings.ElementAt(i).X && cdForOvertaking.X > stripeDrawingForOvertaking.carsDrawings.ElementAt(i + 1).X + 55)
                        {
                            returnedCarDrawing = stripeDrawingForOvertaking.carsDrawings.ElementAt(i);
                        }
                    }
                    else if (cdForOvertaking.car.initialSpeed > 0)
                    {
                        if (cdForOvertaking.X - 55 > stripeDrawingForOvertaking.carsDrawings.ElementAt(i).X && cdForOvertaking.X < stripeDrawingForOvertaking.carsDrawings.ElementAt(i + 1).X - 55)
                        {
                            returnedCarDrawing = stripeDrawingForOvertaking.carsDrawings.ElementAt(i);
                        }
                    }
                }
            }
            return returnedCarDrawing;
        }

        

     
    }
}
