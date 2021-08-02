using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private readonly Vehicle r_Vehicle;
        private string m_OwnerName;
        private string m_Phone;
        private GarageEnums.eVehicleStatus m_Status;
        public VehicleInGarage(Vehicle i_NewVehicle)
        {
            r_Vehicle = i_NewVehicle;
            m_Status = GarageEnums.eVehicleStatus.InTreatment;
        }

        public Vehicle Vehicle
        {
            get
            {

                return r_Vehicle;
            }
        }

        public string Name
        {
            get
            {

                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        public string Phone
        {
            get
            {

                return m_Phone;
            }
            set
            {
                int phoneNumber;

                if (!int.TryParse(value,out phoneNumber))
                {
                    throw new ArgumentException(string.Format("The phone number must be only numbers.{0}", Environment.NewLine));
                }
                m_Phone = value;
            }
        }

        public override string ToString()
        {

            return string.Format("The vehicle owner is {0} and his phone number is - {1}.{2}The vehicle status is - {3}.{2}{4}",
                m_OwnerName, m_Phone, Environment.NewLine, m_Status.ToString(), r_Vehicle.ToString());
        }

        public GarageEnums.eVehicleStatus Status
        {
            get
            {

                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }
    }
}
