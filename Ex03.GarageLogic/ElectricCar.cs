using System;

namespace Ex03.GarageLogic
{
    public class ElectricCar :Car
    {
        public ElectricCar() : base(new ElectricEngine(3.2f), 32, 4)
        {

        }
        public override string ToString()
        {

            return string.Format("The vehicle type is an electric car.{0}{1}", Environment.NewLine, base.ToString());
        }
    }
}
