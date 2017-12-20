using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASPAP.random_distributions;
using ASPAP.generators.timegenerators;
using ASPAP.generators.speedgenerators;
using Timer = System.Windows.Forms.Timer;
using ASPAP.generators.distribution_for_generators;


namespace ASPAP
{
    class Road
    {
        private static Road road;
        private static int countOfStripes, countOfWays;
        private static TrafficLight trafficLight;
        private static Sign sign;
        private static string roadType;
        private static LinkedList<TrafficLight> trafficLights;
        private static LinkedList<Sign> signs = new LinkedList<Sign>();
        private static LinkedList<Way> ways = new LinkedList<Way>();
        private static Timer carAppereanceTimer;
        


        private Road() { }

        public static Road getRoad()
        {
            if (road == null)
            {
                road = new Road();
            }
            return road;
        }

        public void Init()
        {
            carAppereanceTimer = new Timer { Interval = (int) GeneratorsHolder.getGeneratorsHolder().TIMESGENERATOR.getTime() * 1000 }; 
            carAppereanceTimer.Tick += (sender, e) => { generateCar() ;};
        }

        public void Start()
        {
            carAppereanceTimer.Start();
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

        public Timer CARAPPEREANCETIMER
        {
            get { return carAppereanceTimer; }
            set { carAppereanceTimer = value; }
        }

        public LinkedList<Way> WAYS
        {
            get { return ways; }
            set { ways = value; }
        }

        

        public void generateCar()
        {

        }
        
        

    }
}

