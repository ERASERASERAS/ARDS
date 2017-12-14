using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;
using ASPAP.generators.timegenerators;
using ASPAP.generators.speedgenerators;


namespace ASPAP
{
    class Road
    {
        private static Road road;
        private static int countOfStripes, countOfWays;
        private static TrafficLight trafficLight;
        private static Sign sign;
        private static string roadType;
        private static LinkedList<TrafficLight> trafficLights = new LinkedList<TrafficLight>();
        private static LinkedList<Sign> signs = new LinkedList<Sign>();


        private Road() { }

        public static Road getRoad()
        {
            if (road == null)
            {
                road = new Road();
            }
            return road;
        }

        public string ROADTYPE
        {
            get { return roadType; }
            set { roadType = value; }
        }

        public int COUNTOFSTRIPES
        {
            get { return countOfStripes; }
            set { countOfStripes = value; }
        }

        public int COUNTOFWAYS
        {
            get { return countOfWays; }
            set { countOfWays = value; }
        }

        public LinkedList<TrafficLight> TRAFFICLIGHTS
        {
            get { return trafficLights; }
            set { trafficLights = value; }
        }

        public LinkedList<Sign> SIGNS
        {
            get { return signs; }
            set { signs = value; }
        }
        
        

    }
}

