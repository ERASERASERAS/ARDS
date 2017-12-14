using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.generators.speedgenerators
{
    abstract class SpeedGenerator
    {
        private static double minSpeed, maxSpeed;

        //public SpeedGenerator(double minSpeedVal, double maxSpeedVal)
        //{
        //    minSpeed = minSpeedVal;
        //    maxSpeed = maxSpeedVal;
        //}

        public double MINSPEED
        {
            get { return minSpeed; }
            set { minSpeed = value; }
        }

        public double MAXSPEED
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        public abstract double getSpeed();
    }
}
