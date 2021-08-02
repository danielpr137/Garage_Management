using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck:Vehicle
    {
        private bool m_DangerousMaterial;
        private float m_MaxCarry;

        public Truck() : base(new GasEngine(120f, GarageEnums.eGasType.Soler), 26, 16) 
        {

        }

        public bool DangerousMaterial
        {
            get
            {
                return m_DangerousMaterial;
            }
            set
            {
                m_DangerousMaterial = value;
            }
        }

        public float MaxCarry
        {
            get
            {
                return m_MaxCarry;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The maximum carrying weight must be above 0.{0}", Environment.NewLine));
                }
                m_MaxCarry = value;
            }
        }

        public override string ToString()
        {
            return string.Format("The vehicle type is a truck.{0}{1}The truck {2} transporting dangerous materials.{0}The maximum carrying weight is {3}.{0}",
                Environment.NewLine, base.ToString(), m_DangerousMaterial ? "is" : "is not", m_MaxCarry.ToString());
        }

        public override List<Type> ClassFieldTypes()
        {
            List<Type> fieldTypes = base.ClassFieldTypes();
            fieldTypes.Add(typeof(bool));
            fieldTypes.Add(typeof(float));
            return fieldTypes;
        }

        public override List<string> ClassFieldInstractions()
        {
            List<string> fieldNames = base.ClassFieldInstractions();
            fieldNames.Add("Enter 'true' if your truck contains dangerous materials, enter 'false' if not: ");
            fieldNames.Add("Please enter the maximum weight your truck can carry");

            return fieldNames;
        }
        
        public override void SetValues(List<object> i_Values)
        {
            m_DangerousMaterial = Convert.ToBoolean(i_Values[0]);
            i_Values.RemoveAt(0);
            m_MaxCarry = Convert.ToSingle(i_Values[0]);
            i_Values.RemoveAt(0);
        }
    }
}
