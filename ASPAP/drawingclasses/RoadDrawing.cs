using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ASPAP.drawingclasses
{
    class RoadDrawing
    {
        private static RoadDrawing roadDrawing;

        private static LinkedList<StripeDrawing> stripeDrawings { get; set; }
        public static LinkedList<LineDrawing> lineDrawings { get; set; }


        private RoadDrawing()
        {

        }

        public LinkedList<StripeDrawing> STRIPEDRAWINGS
        {
            get { return stripeDrawings; }
            set { stripeDrawings = value; }
        }

        public static RoadDrawing getRoadDrawing()
        {
            if (roadDrawing == null)
            {
                roadDrawing = new RoadDrawing();
                stripeDrawings = new LinkedList<StripeDrawing>();
                lineDrawings = new LinkedList<LineDrawing>();
                
            }
            return roadDrawing;
        }
      

        public void drawRoad(Graphics g, int width, int height)        
        {
            if (stripeDrawings.Count == 0)
            {
                switch (Road.getRoad().ROADTYPE)
                {
                    case ("Тоннель"):
                        drawTonnel(g, width, height);
                        break;
                    case ("Магистраль"):
                        drawMagistral(g, width, height);
                        break;
                    case ("Городская дорога"):
                        drawCityRoad(g, width, height);
                        break;
                    case ("Загородная дорога"):
                        drawCountryRoad(g, width, height);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                foreach (StripeDrawing sd in stripeDrawings)
                {
                    sd.drawStripe(g, width, height / 7);
                }
                foreach (LineDrawing ld in lineDrawings)
                {
                    ld.drawSomeLine(g);
                }
            }
        }

        private void drawTonnel(Graphics g, int width, int height)
        {
            StripeDrawing sd = new StripeDrawing(0, height / 2 - height / 14); //7 - потому что максимум 6 полос + 2 полосы для знаков и светофоров(эти полосы равны половине от обычных)
            sd.drawStripe(g, width, height / 7);
            sd.stripe = Road.getRoad().WAYS.First.Value.stripes.First.Value;
            stripeDrawings.AddLast(sd);

        }

        private void drawMagistral(Graphics g, int width, int height)
        {
            g.Clear(Color.WhiteSmoke);
            
            
            if (Road.getRoad().COUNTOFWAYS == 2)
            {
                for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                {
                    StripeDrawing leftWaySD = new StripeDrawing(0, height / 2 - (i + 1) * height / 7);
                    leftWaySD.stripe = Road.getRoad().WAYS.First.Value.stripes.ElementAt(i);
                    leftWaySD.drawStripe(g, width, height / 7);   
                    stripeDrawings.AddLast(leftWaySD);
                    StripeDrawing rightWaySD = new StripeDrawing(0, height / 2 + i * height / 7);
                    rightWaySD.stripe = Road.getRoad().WAYS.Last.Value.stripes.ElementAt(i);
                    rightWaySD.drawStripe(g, width, height / 7);
                    stripeDrawings.AddLast(rightWaySD);
                    if (i < Road.getRoad().COUNTOFSTRIPES - 1)
                    {
                        LineDrawing ld1 = new LineDrawing(0, height / 2 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                        ld1.drawBrokenLine(g);
                        ld1.whichLine = true;
                        lineDrawings.AddLast(ld1);
                        LineDrawing ld2 = new LineDrawing(0, height / 2 + (i + 1) * height / 7 - 2, width, height / 2 + (i + 1) * height / 7 - 2);
                        ld2.drawBrokenLine(g);
                        ld2.whichLine = true;
                        lineDrawings.AddLast(ld2);

                        //lineDrawing.drawBrokenLine(g, 0, height / 2 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                        //lineDrawing.drawBrokenLine(g, 0, height / 2 + (i + 1) * height / 7 - 2, width, height / 2 + (i + 1) * height / 7 - 2);
                    }
                    
                    
                }
                //lineDrawing.drawSolidLine(g, 0, height / 2 - 1, width, height / 2 - 1);
                //lineDrawing.drawSolidLine(g, 0, height / 2 + 1, width, height / 2 + 1);
                LineDrawing solidLD1 = new LineDrawing(0, height / 2 - 1, width, height / 2 - 1);
                solidLD1.drawSolidLine(g);
                solidLD1.whichLine = false;
                lineDrawings.AddLast(solidLD1);
                LineDrawing solidLD2 = new LineDrawing(0, height / 2 + 1, width, height / 2 + 1);
                solidLD2.drawSolidLine(g);
                solidLD2.whichLine = false;
                lineDrawings.AddLast(solidLD2);
            }
            else
            {

                if (Road.getRoad().COUNTOFSTRIPES % 2 == 0)
                {
                    for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                    {
                        StripeDrawing sd = new StripeDrawing(0, height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7);
                        sd.stripe = Road.getRoad().WAYS.First.Value.stripes.ElementAt(i);
                        sd.drawStripe(g, width, height / 7);
                        if (i < Road.getRoad().COUNTOFSTRIPES  - 1)
                        {
                            //lineDrawing.drawBrokenLine(g, 0, height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7, width,
                            //                                height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7);
                            LineDrawing ld = new LineDrawing(0, height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7, width,
                                                            height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7);
                            ld.drawBrokenLine(g);
                            ld.whichLine = true;
                            lineDrawings.AddLast(ld);
                        }

                    }
           
                }
                else
                {                  
                        for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                        {
                            StripeDrawing sd = new StripeDrawing(0, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                                                    height / 7 + height / 14 - i * height / 7);
                            sd.drawStripe(g, width, height / 7);
                            sd.stripe = Road.getRoad().WAYS.First.Value.stripes.ElementAt(i); //пофиксить ошибку с вылетом(выход за пределы)
                            stripeDrawings.AddLast(sd);
                            if (i < Road.getRoad().COUNTOFSTRIPES - 1)
                            {
                                //lineDrawing.drawBrokenLine(g, 0, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                //                                    height / 7 + height / 14 - i * height / 7, width, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                //                                    height / 7 + height / 14 - i * height / 7);
                                LineDrawing ld = new LineDrawing(0, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                                                    height / 7 + height / 14 - i * height / 7, width, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                                                   height / 7 + height / 14 - i * height / 7);
                                ld.drawBrokenLine(g);
                                ld.whichLine = true;
                                lineDrawings.AddLast(ld);

   
                            }
                        }
                    
                }
            }
    

        }

        private void drawCityRoad(Graphics g, int width, int height)
        {
        }

        private void drawCountryRoad(Graphics g, int width, int height)
        {
        }

        public void stopCars(int lengthOfTrafficLight, int offsetTrafficLight)  //смещение светофора относительно формы и mainpictureBox
        {
            foreach (StripeDrawing sd in stripeDrawings)
            {
                
                foreach (CarDrawing cd in sd.carsDrawings)
                {
                    if (cd.car.speed < 0)
                    {
                        if ((cd.X < TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[1].X - offsetTrafficLight) && 
                               (cd.X + Math.Abs(cd.car.speed) >= TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[1].X - offsetTrafficLight))
                        {
                            cd.car.speed = 0;
                            cd.car.stayByTrafficLight = true;
                            cd.X = TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[1].X - offsetTrafficLight - 50;
                        }
                    }
                    else
                    {
                        if ((cd.X > TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[0].X + lengthOfTrafficLight - offsetTrafficLight) &&
                            (cd.X - cd.car.speed <= TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[0].X + lengthOfTrafficLight - offsetTrafficLight))
                        {
                            cd.car.speed = 0;
                            cd.car.stayByTrafficLight = true;
                            cd.X = TrafficLightDrawing.getTrafficLightDrawing().COORDINATS.First.Value[0].X + lengthOfTrafficLight - offsetTrafficLight;
                        }
                    }
                }
            }
        }

        public void resumeCarsTraffic()
        {
            foreach (StripeDrawing sd in stripeDrawings)
            {
                foreach (CarDrawing cd in sd.carsDrawings)
                {
                    if (cd.car.stayByTrafficLight)
                    {
                        cd.car.stayByTrafficLight = false;
                        cd.car.speed = cd.car.initialSpeed;
                    }
                }
            }
        }

        

        


    }
}
