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
     
        


        private Road() { }

        public static Road getRoad()
        {
            if (road == null)
            {
                road = new Road();
                trafficLights = new LinkedList<TrafficLight>();
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


        public LinkedList<Way> WAYS
        {
            get { return ways; }
            set { ways = value; }
        }


        public Stripe getStripeForOvertaking(Stripe stripe, string nameOfWay)
        {
            Stripe returnedStripe = null;
            Way wayForOvertaking = getWayForOvertaking(nameOfWay);
            if(wayForOvertaking != null)
            {
                LinkedListNode<Stripe> currentStripeNode = wayForOvertaking.stripes.Find(stripe);
                if (currentStripeNode.Next != null)
                {
                    returnedStripe = currentStripeNode.Next.Value;
                }
                else if (currentStripeNode.Previous != null)
                {
                    returnedStripe = currentStripeNode.Previous.Value;
                }
            }

            return returnedStripe;
        }

        private Way getWayForOvertaking(string nameOfWay)
        {
            Way returnedWay = null;
            if (nameOfWay.Equals("LEFT"))
            {
                returnedWay = ways.ElementAt(0);
            }
            else if (nameOfWay.Equals("RIGHT"))
            {
                returnedWay = ways.ElementAt(1);
            }
            return returnedWay;
        }

        public bool checkOppurtunityForOvertaking()
        {
            bool result = false;
            if (countOfWays == 1)
            {
                if(countOfStripes > 1)
                {
                    result = true;
                }
            }
            else if (countOfWays == 2)
            {
                if(ways.ElementAt(0).stripes.Count > 1)
                {
                    result = true;
                }

            }
            return result;
        }

        public void clearRoad()
        {
            trafficLights.Clear();
            signs.Clear();
            ways.Clear();
        }

       

        

    }
}

