using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        protected GarageEnums.eCarColor m_Color;
        protected GarageEnums.eCarDoorNumber m_DoorNum;
        public Car(Engine i_Engine, float i_MaxWheelPressure, int i_NumOfWheels) : base(i_Engine, i_MaxWheelPressure, i_NumOfWheels)
        {

        }

        public GarageEnums.eCarColor Color
        {
            get
            {

                return m_Color;
            }

            private set
            {
                bool validColor = false;

                foreach (GarageEnums.eCarColor carColor in (GarageEnums.eCarColor[])Enum.GetValues(typeof(GarageEnums.eCarColor)))
                {
                    if (value == carColor)
                    {
                        validColor = true;
                    }
                }

                if (!validColor)
                {
                    throw new ArgumentException("The color is not valid");
                }

                m_Color = value;
            }
        }

        public GarageEnums.eCarDoorNumber DoorNum
        {
            get
            {
                return m_DoorNum;
            }

            private set
            {
                bool validNumber = false;

                foreach (GarageEnums.eCarDoorNumber doorsNumber in (GarageEnums.eCarDoorNumber[])Enum.GetValues(typeof(GarageEnums.eCarDoorNumber)))
                {
                    if(value == doorsNumber)
                    {
                        validNumber = true;
                    }
                }

                if (!validNumber)
                {
                    throw new ArgumentException("The number of doors is not valid");
                }

                m_DoorNum = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}The car color is {1}.{2}The number of doors is {3}.{2}",
                                    base.ToString(), m_Color.ToString(), Environment.NewLine, m_DoorNum.ToString());
        }

        public override List<Type> ClassFieldTypes()
        {
            List<Type> fieldTypes = base.ClassFieldTypes();
            fieldTypes.Add(m_Color.GetType());
            fieldTypes.Add(m_DoorNum.GetType());

            return fieldTypes;
        }

        public override List<string> ClassFieldInstractions()
        {
            List<string> fieldNames = base.ClassFieldInstractions();
            fieldNames.Add("Please choose you car color: 1.Red 2.Silver 3.White 4.Black ");
            fieldNames.Add("Please enter the number of doors on your vehicle: ");

            return fieldNames;
        }

        public override void SetValues(List<object> io_Values)
        {
            Color = GeneralMethods.ConvertToEnum<GarageEnums.eCarColor>(io_Values[0]);
            io_Values.RemoveAt(0);
            DoorNum = GeneralMethods.ConvertToEnum<GarageEnums.eCarDoorNumber>(io_Values[0]);
            io_Values.RemoveAt(0);
        }
    }
}
