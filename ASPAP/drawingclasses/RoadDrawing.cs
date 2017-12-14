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
        //Bitmap bitmap;
        private Graphics mainPictureBoxGraphics;
        private int width, height;
        
        
        

        public RoadDrawing(Graphics g, int width, int height)
        {
            mainPictureBoxGraphics = g;
            this.width = width;
            this.height = height;
        }

  

        public void draw() 
        {
            switch (Road.getRoad().ROADTYPE)
            {
                case ("Тоннель"):
                    drawTonnel();
                    break;
                case ("Магистраль"):
                    drawMagistral();
                    break;
                case ("Городская дорога"):
                    drawCityRoad();
                    break;
                case ("Загородная дорога"):
                    drawCountryRoad();
                    break;
                default:
                    break;
            }           
        }

        private void drawTonnel()
        {
            new StripeDrawing().drawStripe(mainPictureBoxGraphics, 0, height/2 - height / 14, width, height / 7);   //7 - потому что максимум 6 полос + 2 полосы для знаков и светофоров(эти полосы равны половине от обычных)
        }

        private void drawMagistral()
        {
            StripeDrawing stripeDrawing = new StripeDrawing();
            mainPictureBoxGraphics.Clear(Color.WhiteSmoke);
            if (Road.getRoad().COUNTOFWAYS == 2)
            {
                for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES; i++)
                {
                    
                    stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2 - (i + 1) * height / 7, width, height / 7);
                    stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2 + i * height / 7, width, height / 7);
                    if (i < Road.getRoad().COUNTOFSTRIPES - 1)
                    {
                        stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                        stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 + (i + 1) * height / 7 - 2, width, height / 2 + (i + 1) * height / 7 - 2);
                    }
                    
                    
                }
                stripeDrawing.drawSolidLine(mainPictureBoxGraphics, 0, height / 2 - 1, width, height / 2 - 1);
                stripeDrawing.drawSolidLine(mainPictureBoxGraphics, 0, height / 2 + 1, width, height / 2 + 1);
            }
            else
            {
                
                if (Road.getRoad().COUNTOFSTRIPES % 2 == 0)
                {
                    for (int i = 0; i < Road.getRoad().COUNTOFSTRIPES / 2; i++)
                    {
                        stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2 - (i + 1) * height / 7, width, height / 7);
                        stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2 + i * height / 7, width, height / 7);
                        if (i < Road.getRoad().COUNTOFSTRIPES / 2 - 1)
                        {
                            stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                            stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 + (i + 1) * height / 7 - 2, width, height / 2 + (i + 1) * height / 7 - 2);
                        }
                                           
                    }                   

                    stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2, width, height / 2);
                }
                else
                {
                    drawTonnel();
                    if (Road.getRoad().COUNTOFSTRIPES > 1)
                    {
                        for (int i = 0; i < (Road.getRoad().COUNTOFSTRIPES - 1) / 2; i++)
                        {
                            stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2 -  height / 14 - (i + 1) * height / 7, width, height / 7);
                            stripeDrawing.drawStripe(mainPictureBoxGraphics, 0, height / 2  + height / 14 + i * height / 7, width, height / 7);
                            //stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 + height / 14 - (i + 1) * height / 7, width, height / 2 - (i + 1) * height / 7);
                            if (i < Road.getRoad().COUNTOFSTRIPES / 2 - 1)
                            {
                                stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 - height / 14 - (i + 1) * height / 7, width, height / 2 - height / 14 - (i + 1) * height / 7);
                                stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 + height / 14 + (i + 1) * height / 7 - 1, width, height / 2 + height / 14 + (i + 1) * height / 7 - 1);
                            }                         
                        }
                        stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 - height / 14, width, height / 2 - height / 14);
                        stripeDrawing.drawBrokenLine(mainPictureBoxGraphics, 0, height / 2 + height / 14, width, height / 2 + height / 14);
                    }
                }
            }

        }

        private void drawCityRoad()
        {
        }

        private void drawCountryRoad()
        {
        }

        

        


    }
}
