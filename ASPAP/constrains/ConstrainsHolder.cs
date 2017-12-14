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
        private static int minTime = 100;

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
       

    }
}
