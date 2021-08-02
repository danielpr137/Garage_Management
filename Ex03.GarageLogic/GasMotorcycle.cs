using System;

namespace Ex03.GarageLogic
{
    public class GasMotorcycle : Motorcycle
    {
        public GasMotorcycle() :base(new GasEngine(6, GarageEnums.eGasType.Octan98), 30, 2){ }

        public override string ToString()
        {
            return string.Format("The vehicle type is a gas motorcycle.{0}{1}", Environment.NewLine, base.ToString());
        }

    }
}
