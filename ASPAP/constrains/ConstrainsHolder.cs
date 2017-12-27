using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.constrains
{
    class ConstrainsHolder
    {
        private static ConstrainsHolder constrainsHolder;
        private static int maxSpeed, minSpeed;
        private static int maxTime = 10000; // в миллисекундах
        private static int minTime = 1000;
        private static int minRedLightTime = 5;
        private static int maxRedLightTime = 15;
        private static int minGreenLightTime = 5;
        private static int maxGreenLightTme = 30;

        private ConstrainsHolder() {}

        public static ConstrainsHolder getConstrainsHolder()
        {
            if (constrainsHolder == null)
            {
                constrainsHolder = new ConstrainsHolder();
            }
            return constrainsHolder;
        }

        public int  MAXSPEED
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        public int MINSPEED
        {
            get { return minSpeed; }
            set { minSpeed = value; }
        }

        public int MINREDLIGHTTIME
        {
            get { return minRedLightTime; }
            set { minRedLightTime = value; }
        }

        public int MAXREDLIGHTTIME
        {
            get { return maxRedLightTime; }
            set { maxRedLightTime = value; }
        }

        public int MINGREENLIGHTTIME
        {
            get { return minGreenLightTime; }
            set { minGreenLightTime = value; }
        }

        public int MAXGREENLIGHTTIME
        {
            get { return maxGreenLightTme; }
            set { maxGreenLightTme = value; }
        }
       

    }
}
