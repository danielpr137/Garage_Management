using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxEnergy) : base(i_MaxEnergy) { }

        public void ChargeBattery(float i_HoursToCharge)
        {
            base.FillEnergy(i_HoursToCharge);
        }

        public override string ToString()
        {

            return string.Format("The engine is electric.{0}{1}", Environment.NewLine, base.ToString());
        }
    }
}
