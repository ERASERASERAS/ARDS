using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;
using ASPAP.generators.speedgenerators;
using ASPAP.generators.timegenerators;

namespace ASPAP.generators.distribution_for_generators
{
    class GeneratorsHolder
    {
        private static GeneratorsHolder generatorsHolder;
        private static SpeedGenerator speedsGenerator;
        private static TimeGenerator timesGenerator;

        private GeneratorsHolder() { }

        public static GeneratorsHolder getGeneratorsHolder()
        {
            if (generatorsHolder == null)
            {
                generatorsHolder = new GeneratorsHolder();
            }
            return generatorsHolder;
        }

        public SpeedGenerator SPEEDSGENERATOR
        {
            get { return speedsGenerator; }
            set { speedsGenerator = value; }
        }

        public TimeGenerator TIMESGENERATOR
        {
            get { return timesGenerator; }
            set { timesGenerator= value; }
        }



    }
}
