using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    { 
        protected GarageEnums.eMotorcycleLicenseType m_LicenseType;
        protected int m_EngineCapacity;

        public Motorcycle(Engine i_Engine, float i_MaxWheelPressure, int i_NumOfWheels) :
            base(i_Engine,i_MaxWheelPressure,i_NumOfWheels) 
        { 

        }

        public GarageEnums.eMotorcycleLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                bool validLicense = false;
                foreach (GarageEnums.eMotorcycleLicenseType motorLicense in (GarageEnums.eMotorcycleLicenseType[])Enum.GetValues(typeof(GarageEnums.eMotorcycleLicenseType)))
                {
                    if (value == motorLicense)
                    {
                        validLicense = true;
                    }
                }
                if (!validLicense)
                {
                    throw new ArgumentException("The license type is not valid");
                }
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The maximum engine capacity must be above 0.{0}", Environment.NewLine));
                }
                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {

            return string.Format("{0}The motorcycle license type is {1}.{2}The engine capacity is {3}.{2}",
                base.ToString(), m_LicenseType.ToString(), Environment.NewLine, m_EngineCapacity.ToString());
        }

        public override List<Type> ClassFieldTypes()
        {
            List<Type> fieldTypes = base.ClassFieldTypes();
            fieldTypes.Add(typeof(GarageEnums.eMotorcycleLicenseType));
            fieldTypes.Add(typeof(int));

            return fieldTypes;
        }

        public override List<string> ClassFieldInstractions()
        {
            List<string> fieldNames = base.ClassFieldInstractions();
            fieldNames.Add("Please enter your license type: 1.A, 2.B1 3.AA 4.BB ");
            fieldNames.Add("Please enter the engine capasity of your motorcycle: ");

            return fieldNames;
        }

        public override void SetValues(List<object> i_Values)
        {
            LicenseType = GeneralMethods.ConvertToEnum<GarageEnums.eMotorcycleLicenseType>(i_Values[0]);
            i_Values.RemoveAt(0);
            m_EngineCapacity = Convert.ToInt32(i_Values[0]);
            i_Values.RemoveAt(0);
        }
    }
}
