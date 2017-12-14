using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.random_distributions
{
    class ExponentialDistribution: IDistribution
    {
        private double lambda;
        Random rnd = new Random();

        public ExponentialDistribution(double lambda)
        {
            this.lambda = lambda;
        }

        public double LAMBDA
        {
            get { return lambda; }
            set { lambda = value; }
        }

        public double getRandomNumber()
        {
            return -1 * Math.Log(rnd.NextDouble()) / lambda;
        }
    }
}
