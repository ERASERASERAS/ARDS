using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP
{
    class Sign
    {
        private int maxSpeed;

        public Sign(int maxSpeedVal)
        {
            maxSpeed = maxSpeedVal;
        }

        public int MAXSPEED
        {
            get { return maxSpeed; }
        }
    }
}
