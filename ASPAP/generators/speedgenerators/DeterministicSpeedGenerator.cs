using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.generators.speedgenerators
{
    class DeterministicSpeedGenerator: SpeedGenerator
    {
        private double speed;

        public DeterministicSpeedGenerator(double speed)
        {
            this.speed = speed;
        }


        public override double getSpeed()
        {
            return speed;
        }
    }
}
