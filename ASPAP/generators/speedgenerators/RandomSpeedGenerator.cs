using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;
using ASPAP.constrains;

namespace ASPAP.generators.speedgenerators
{
    class RandomSpeedGenerator : SpeedGenerator
    {
        private IDistribution distribution;

        public RandomSpeedGenerator(IDistribution distribution)
        {
            this.distribution = distribution;
        }

        public override double getSpeed()
        {
            double randomSpeed = distribution.getRandomNumber();

            if (randomSpeed < ConstrainsHolder.getConstrainsHolder().MINSPEED)
            {
                randomSpeed = ConstrainsHolder.getConstrainsHolder().MINSPEED;
            }
            else if (randomSpeed > ConstrainsHolder.getConstrainsHolder().MAXSPEED)
            {
                randomSpeed = ConstrainsHolder.getConstrainsHolder().MAXSPEED;
            }
            return randomSpeed;
        }
    }
}
