using System;

namespace Ex03.GarageLogic
{
    public class GasCar:Car
    {
        public GasCar() : base(new GasEngine(45, GarageEnums.eGasType.Octan95), 32, 4)
        {

        }

        public override string ToString()
        {
            return string.Format("The vehicle type is a gas car.{0}{1}", Environment.NewLine, base.ToString());
        }
    }
}
