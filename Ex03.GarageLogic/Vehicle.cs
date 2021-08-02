using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LisenceNumber;
        protected float m_EnergyPrecent;
        protected Engine m_Engine;
        protected List<Wheel> m_Wheels;

        public Vehicle(Engine i_Engine, float i_MaxWheelPressure, int i_NumOfWheels)
        {
            m_Engine = i_Engine;
            m_Wheels = new List<Wheel>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxWheelPressure));
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder msg = new System.Text.StringBuilder();
            msg.Append(string.Format("The vehicle model is {0}.{1}The serial Number is {2}.{1}The remaining energy precent is {3}.{1}{4}The number of wheels is {5}.{1}",
                m_Model, Environment.NewLine, m_LisenceNumber, m_EnergyPrecent.ToString(), m_Engine.ToString(), m_Wheels.Count.ToString()));
            int count = 1;
            foreach (Wheel tire in m_Wheels)
            {
                msg.Append(string.Format("{0}.) {1}", count.ToString(), tire.ToString()));
                count++;
            }

            return msg.ToString();
        }

        public override bool Equals(object i_Obj)
        {

            bool isEqual = false;
            Vehicle temp = i_Obj as Vehicle;
            if (temp != null)
            {
                isEqual = (temp.m_LisenceNumber == this.m_LisenceNumber);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {

            return m_LisenceNumber.GetHashCode();
        }

        public static bool operator ==(Vehicle i_Obj1, Vehicle i_Obj2)
        {

            return i_Obj1.Equals(i_Obj2);
        }

        public static bool operator !=(Vehicle i_Obj1, Vehicle i_Obj2)
        {

            return !i_Obj1.Equals(i_Obj2);
        }

        public void FillToMaxAir()
        {
            foreach (Wheel tire in m_Wheels)
            {
                tire.FillMaxAir();
            }
        }

        public void CalcEnergyPrecent()
        {
            m_EnergyPrecent = m_Engine.EnergyPrecentCalc();
        }

        public float EnergyPrecent
        {
            get
            {
                return m_EnergyPrecent;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }
            set
            {
                m_Model = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LisenceNumber;
            }
            set
            {
                m_LisenceNumber = value;
            }
        }

        public virtual List<Type> ClassFieldTypes()
        {
            List<Type> fieldTypes = new List<Type>();

            return fieldTypes;
        }

        public virtual List<string> ClassFieldInstractions()
        {
            List<string> fieldNames = new List<string>();

            return fieldNames;
        }

        public abstract void SetValues(List<object> i_Values);
    }
}
