using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;
using ASPAP.constrains;

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
            double randomTime = distribution.getRandomNumber();
            if (randomTime < ConstrainsHolder.getConstrainsHolder().MINTIME)
            {
                randomTime = ConstrainsHolder.getConstrainsHolder().MINTIME;
            }
            else if (randomTime > ConstrainsHolder.getConstrainsHolder().MAXTIME)
            {
                randomTime = ConstrainsHolder.getConstrainsHolder().MAXTIME;
            }
            return randomTime;
        }
    }
}
