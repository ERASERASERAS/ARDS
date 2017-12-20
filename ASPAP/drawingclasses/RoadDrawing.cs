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

        public static LinkedList<StripeDrawing> stripeDrawings { get; set; }

        private RoadDrawing()
        {

        }

        public static RoadDrawing getRoadDrawing()
        {
            if (roadDrawing == null)
            {
                roadDrawing = new RoadDrawing();
                stripeDrawings = new LinkedList<StripeDrawing>();
                
            }
            return roadDrawing;
        }
      

        public void drawRoad(Graphics g, int width, int height) 
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

        private void drawTonnel(Graphics g, int width, int height)
        {
            //stripeDrawings.AddLast(
            StripeDrawing sd = new StripeDrawing(0, height / 2 - height / 14); //7 - потому что максимум 6 полос + 2 полосы для знаков и светофоров(эти полосы равны половине от обычных)
            sd.drawStripe(g, width, height / 7);
            sd.stripe = Road.getRoad().WAYS.First.Value.stripes.First.Value;
            stripeDrawings.AddLast(sd);

        }

        private void drawMagistral(Graphics g, int width, int height)
        {
            g.Clear(Color.WhiteSmoke);
            LineDrawing lineDrawing = new LineDrawing();
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
                        lineDrawing.drawBrokenLine(g, 0, height / 2 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                        lineDrawing.drawBrokenLine(g, 0, height / 2 + (i + 1) * height / 7 - 2, width, height / 2 + (i + 1) * height / 7 - 2);
                    }
                    
                    
                }
                lineDrawing.drawSolidLine(g, 0, height / 2 - 1, width, height / 2 - 1);
                lineDrawing.drawSolidLine(g, 0, height / 2 + 1, width, height / 2 + 1);
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
                            lineDrawing.drawBrokenLine(g, 0, height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7, width,
                                                            height / 2 + (Road.getRoad().COUNTOFSTRIPES / 2 - 1) * height / 7 - i * height / 7);
                            
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
                                lineDrawing.drawBrokenLine(g, 0, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                                                    height / 7 + height / 14 - i * height / 7, width, height / 2 + (Road.getRoad().COUNTOFSTRIPES - 3) / 2 *
                                                                    height / 7 + height / 14 - i * height / 7);
   
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

        

        


    }
}
