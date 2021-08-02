using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergy;
        protected float m_MaximumEnergyCapacity;
        protected Engine(float i_MaxEnergy)
        {
            MaxEnergy = i_MaxEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaximumEnergyCapacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The maximum energy capacity must be above 0.{0}", Environment.NewLine));
                }
                m_MaximumEnergyCapacity = value;
            }
        }

        public virtual void FillEnergy(float i_EnergyToAdd)
        {
            if (i_EnergyToAdd < 0 || i_EnergyToAdd + m_CurrentEnergy > m_MaximumEnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaximumEnergyCapacity - m_CurrentEnergy);
            }
            m_CurrentEnergy += i_EnergyToAdd;
        }

        public float Energy
        {
            get
            {

                return m_CurrentEnergy;
            }
        }

        public float EnergyPrecentCalc()
        {

            return (m_CurrentEnergy / m_MaximumEnergyCapacity) * 100f;
        }

        public override string ToString()
        {

            return string.Format("The current energy left is {0}.{1}The maximum capacity in the engine is {2}.{1}",
                m_CurrentEnergy.ToString(), Environment.NewLine, m_MaximumEnergyCapacity.ToString());
        }
    }
}
