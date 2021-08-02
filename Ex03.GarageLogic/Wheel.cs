using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_CompanyName;
        private float m_CurAirPressure;
        private float m_MaximumAirPressure;

        public Wheel(float i_MaxPressure)
        {
            MaxAirPressure = i_MaxPressure;
        }
        public override string ToString()
        {
            return string.Format("The wheel company is {0}.{1}The current air pressure is {2} and the maximum air pressure is {3}.{1}",
                m_CompanyName, Environment.NewLine, m_CurAirPressure.ToString(), MaxAirPressure.ToString());
        }
        public override bool Equals(object i_Obj)
        {
            bool isEqual = false;
            Wheel temp = i_Obj as Wheel;
            if (temp != null)
            {
                isEqual = (temp.m_CompanyName == this.m_CompanyName && temp.m_MaximumAirPressure == this.m_MaximumAirPressure);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return m_CompanyName.GetHashCode();
        }

        public static bool operator ==(Wheel i_Obj1, Wheel i_Obj2)
        {
            return i_Obj1.Equals(i_Obj2);
        }

        public static bool operator !=(Wheel i_Obj1, Wheel i_Obj2)
        {
            return !i_Obj1.Equals(i_Obj2);
        }

        public void FillAir(float i_AddAirPressure)
        {
            if (i_AddAirPressure < 0 || i_AddAirPressure + m_CurAirPressure > m_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaximumAirPressure - m_CurAirPressure);
            }
            m_CurAirPressure += i_AddAirPressure;
        }

        public void FillMaxAir()
        {
            m_CurAirPressure = m_MaximumAirPressure;
        }

        public string CompanyName
        {
            get
            {
                return m_CompanyName;
            }
            set
            {
                m_CompanyName = value;
            }
        }

        public float AirPressurePrecent
        {
            get
            {
                return m_CurAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaximumAirPressure;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The maximum air pressure must be above 0.{0}", Environment.NewLine));
                }
                m_MaximumAirPressure = value;
            }
        }
    }
}
