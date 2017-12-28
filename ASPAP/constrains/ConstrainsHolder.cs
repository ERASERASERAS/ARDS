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
        private static int maxTime = 10; 
        private static int minTime = 1;
        private static int minRedLightTime = 5;
        private static int maxRedLightTime = 15;
        private static int minGreenLightTime = 5;
        private static int maxGreenLightTme = 30;
        private static int aForTime = 1;
        private static int bForTime = 10;
        private static int aForSpeed, bForSpeed;
        private static double minExpParForTime =  0.1;
        private static double maxExpParForTime = 1;
        private static double minExpParForSpeed = 0.01;
        private static double maxExpParForSpeed = 0.04;


        private ConstrainsHolder() {}

        public static ConstrainsHolder getConstrainsHolder()
        {
            if (constrainsHolder == null)
            {
                constrainsHolder = new ConstrainsHolder();
            }
            return constrainsHolder;
        }

        public int MINTIME
        {
            get { return minTime; }
            set { minTime = value; }
        }

        public int MAXTIME
        {
            get { return maxTime; }
            set { maxTime = value; }
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

        public int AFORTIME
        {
            get { return aForTime; }
            set { aForTime = value; }
        }

        public int BFORTIME
        {
            get { return bForTime; }
            set { bForTime = value; }
        }

        public int AFORSPEED
        {
            get { return aForSpeed; }
            set { aForSpeed = value; }
        }

        public int BFORSPEED
        {
            get { return bForSpeed; }
            set { bForSpeed = value; }
        }

        public double MINEXPPARFORTIME
        {
            get { return minExpParForTime; }
            set { minExpParForTime = value;  }
        }

        public double MAXEXPPARTOFTIME
        {
            get { return maxExpParForTime; }
            set { maxExpParForTime = value; }
        }

        public double MINEXPPAROFSPEED
        {
            get { return minExpParForSpeed; }
            set { minExpParForSpeed = value; }
        }

        public double MAXEXPPAROFSPEED
        {
            get { return maxExpParForSpeed; }
            set { maxExpParForSpeed = value; }
        }

       

    }
}
