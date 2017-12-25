using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP
{
    class Car
    {
        public int speed { get; set; }
        public int initialSpeed { get; set; }
        public bool overtaking { get; set; }
        public bool stayByTrafficLight { get; set; }


        public Car(int speed)
        {
            this.speed = speed;
            initialSpeed = speed;
        }



 
    }
}
