using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP
{
    class TrafficLight
    {
        private static int redLightTime, greenLightTime;
        private bool redLight, greenLight;

        public TrafficLight(int redLightTimeVal, int greenLightTimeVal)
        {
            redLightTime = redLightTimeVal;
            greenLightTime = greenLightTimeVal;
            redLight = true;
            greenLight = false;
        }

        public int REDLIGHTTIME
        {
            get { return redLightTime; }
            set { redLightTime = value; }

        }

        public int GREENLIGHTTIME
        {
            get { return greenLightTime; }
            set { greenLightTime = value; }
        }

        public bool REDLIGHT
        {
            get { return redLight; }
            set { redLight = value; }
        }

        public bool GREENLIGHT
        {
            get { return greenLight; }
            set { GREENLIGHT = value; }
        }
    

    }
}
