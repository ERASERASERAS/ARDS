using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPAP
{
    class Stripe
    {
        private LinkedList<Car> cars;

        public Stripe()
        {
            cars = new LinkedList<Car>();
        }

        public Stripe(LinkedList<Car> cars)
        {
            this.cars = cars; 
        }

        public LinkedList<Car> CARS
        {
            get { return cars; }
            set { cars = value; }


        }


        public void addCar(Car newCar)
        {
            cars.AddLast(newCar);
        }

        public void deleteCar(Car deletedCar)
        {
            cars.Remove(deletedCar);
        }
        



    }
}
