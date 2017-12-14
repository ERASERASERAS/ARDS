using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP.generators.timegenerators
{
    abstract class TimeGenerator
    {
        private static double minTime = 0.0005;
        private static double maxTime = 10;

        public abstract double getTime();
        
    }
}
