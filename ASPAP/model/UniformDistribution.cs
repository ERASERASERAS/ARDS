using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.random_distributions
{
    class UniformDistribution: IDistribution
    {
        private double a;
        private double b;
        private Random rnd = new Random();

        public UniformDistribution(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double getRandomNumber()
        {
            return (b - a) * rnd.NextDouble() + a;
        }

        


    }
}
