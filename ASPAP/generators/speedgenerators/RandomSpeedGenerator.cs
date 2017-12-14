using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;

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
            return distribution.getRandomNumber();
        }
    }
}
