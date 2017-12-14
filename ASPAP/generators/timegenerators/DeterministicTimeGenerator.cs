using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.generators.timegenerators
{
    class DeterministicTimeGenerator : TimeGenerator
    {
        
        private double interval;

        public DeterministicTimeGenerator(double interval)
        {
            this.interval = interval;
        }

        public override double getTime()
        {
            return interval;
        }
        


    }
}
