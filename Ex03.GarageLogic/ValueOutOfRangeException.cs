using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinVal, float i_MaxVal) :
                                        base(string.Format("The value is out of range.{0}The maximum value is {1} and the minimum value is {2}.",
                                        Environment.NewLine, i_MaxVal.ToString(), i_MinVal.ToString()))
        {
            m_MaxValue = i_MaxVal;
            m_MinValue = i_MinVal;
        }

        public float MaxValue
        {
            get
            {

                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {

                return m_MinValue;
            }
        }

        public override string ToString()
        {

            return string.Format("This is an exception of value is out of range.{0}The maximum value is {1} and the minimum value is {2}.",
                Environment.NewLine, m_MaxValue.ToString(), m_MinValue.ToString());
        }
    }
}
