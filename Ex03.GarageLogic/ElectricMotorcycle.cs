using System;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle:Motorcycle
    {
        public ElectricMotorcycle() : base(new ElectricEngine(1.8f), 30, 16)
        { 

        }

        public override string ToString()
        {

            return string.Format("The vehicle type is an electric motorcycle.{0}{1}", Environment.NewLine, base.ToString());
        }
    }
}
