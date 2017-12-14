using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;

namespace ASPAP.generators.timegenerators
{
    class RandomTimeGenerator: TimeGenerator
    {
        private IDistribution distribution;

        public RandomTimeGenerator(IDistribution distribution)
        {
            this.distribution = distribution;
        }

        public override double getTime()
        {
            return distribution.getRandomNumber();
        }
    }
}
