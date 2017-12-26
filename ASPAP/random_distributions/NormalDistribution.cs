using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.random_distributions
{
    class NormalDistribution :IDistribution
    {
        private double expectedValue, dispersion;
        private Random rnd1 = new Random();
        private Random rnd2 = new Random();

        public NormalDistribution(double expectedValue, double dispersion)
        {
            this.expectedValue = expectedValue;
            this.dispersion = dispersion; ;
        }

        public double EXPECTEDVALUE
        {
            get { return expectedValue; }
            set { expectedValue = value; }
        }

        public double DISPERSION
        {
            get { return dispersion; }
            set { dispersion = value; }
        }

        public double getRandomNumber()
        {
            return expectedValue +  Math.Cos(2 * Math.PI * rnd1.NextDouble()) * Math.Sqrt(-2 * Math.Log(rnd2.NextDouble())) * Math.Sqrt(dispersion); 
        }
    }

}
