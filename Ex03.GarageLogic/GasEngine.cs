using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public class GasEngine : Engine
    {
        
        private readonly GarageEnums.eGasType r_GasType;

        public GasEngine(float i_MaxEnergy, GarageEnums.eGasType i_GasType) : base(i_MaxEnergy)
        {
            r_GasType = i_GasType;
        }

        public void FillGas(float i_GasToAddAmount, GarageEnums.eGasType i_GasType)
        {
            if (i_GasType != r_GasType)
            {
                throw new ArgumentException(string.Format("Invalid gas type, your vehicle uses {0}.", r_GasType.ToString()));
            }

            base.FillEnergy(i_GasToAddAmount);
        }

        public override string ToString()
        {

            return string.Format("This is gas engine.{0}The gas type is {1}.{0}{2}",Environment.NewLine,r_GasType.ToString() ,base.ToString());
        }
    }
}
