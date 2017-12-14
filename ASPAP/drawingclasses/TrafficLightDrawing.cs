using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ASPAP.drawingclasses
{
    class TrafficLightDrawing
    {

        private static TrafficLightDrawing trafficLightDrawing;

        private static LinkedList<Point []> coordinats = new LinkedList<Point []>(); //2 светофора - 2 элемента в массивa. 1 -й верхгий

        private static Image defaultStateTop = Image.FromFile("..\\..\\images\\traffic_light_images\\default_light_top.png");
        private static Image defaultStateBottom = Image.FromFile("..\\..\\images\\traffic_light_images\\default_light_bottom.png");
        private static Image greenStateTop = Image.FromFile("..\\..\\images\\traffic_light_images\\green_light_top.png");
        private static Image greenStateBottom = Image.FromFile("..\\..\\images\\traffic_light_images\\green_light_bottom.png");
        private static Image redStateTop = Image.FromFile("..\\..\\images\\traffic_light_images\\red_light_top.png");
        private static Image redStateBottom = Image.FromFile("..\\..\\images\\traffic_light_images\\red_light_bottom.png");


        private   TrafficLightDrawing() 
        {

        }


        public static TrafficLightDrawing getTrafficLightDrawing()
        {
            if(trafficLightDrawing == null)
            {
                trafficLightDrawing = new TrafficLightDrawing();
            }
            return trafficLightDrawing;
        }
        

        public Image REDSTATEBOTTOM
        {
            get { return redStateBottom; }
        }

        public Image REDSTATETOP
        {
            get { return redStateTop; }
        }

        public Image GREENSTATETOP
        {
            get { return greenStateTop; }
        }

        public Image GREENSTATEBOTTOM
        {
            get { return greenStateBottom; }
        }

        public Image DEFAULTSTATETOP
        {
            get { return defaultStateTop; }
        }

        public Image DEFAULTSTATEBOTTOM
        {
            get { return defaultStateBottom; }
        }

        public LinkedList<Point[]> COORDINATS
        {
            get { return coordinats; }
            set { coordinats = value; }
        }

    }
}
