using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, VehicleInGarage> r_VehiclesInGarage;

        public Garage ()
        {
            r_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        }

        public override string ToString()
        {
            StringBuilder msg = new StringBuilder();
            int count = 1;

            msg.Append(string.Format("The number of vehicles in the garage is {0}.{1}",
            r_VehiclesInGarage.Count.ToString(), Environment.NewLine));
            foreach (KeyValuePair<string, VehicleInGarage> tempVehicle in r_VehiclesInGarage)
            {
                msg.Append(string.Format("{0}.) {1}", count.ToString(), tempVehicle.Value));
                count++;
            }

            return msg.ToString();
        }

        public Dictionary<string, VehicleInGarage> ListOfVehicles
        {
            get
            {

                return r_VehiclesInGarage;
            }
        }

        public bool CheckIfInGarage(string i_LicensePlate)
        {

            return r_VehiclesInGarage.ContainsKey(i_LicensePlate);
        }

        public void UpdateVehicleStatus(string i_Key,GarageEnums.eVehicleStatus i_newStatus)
        {
            r_VehiclesInGarage[i_Key].Status = i_newStatus;
        }

        public void UpdatePhoneNumber(string i_Key, string i_newPhoneNumber)
        {
            r_VehiclesInGarage[i_Key].Phone = i_newPhoneNumber;
        }

        public bool GetVehicle(string i_LicensePlate, out VehicleInGarage o_Vehicle)
        {

            return r_VehiclesInGarage.TryGetValue(i_LicensePlate, out o_Vehicle);
        }

        public void UpdateOwnerName(string i_Key, string i_newName)
        {
            r_VehiclesInGarage[i_Key].Name = i_newName;
        }

        public void AddVehicle(string i_LicensePlate, VehicleInGarage i_Vehicle)
        {
            if (CheckIfInGarage(i_LicensePlate))
            {
                throw new ArgumentException(string.Format("The vehicle is already in the garage.{0}", Environment.NewLine));
            }
            r_VehiclesInGarage.Add(i_LicensePlate, i_Vehicle);
        }

        public void SetPhone(string i_LicensePlate,string i_Phone)
        {
            if (!CheckIfInGarage(i_LicensePlate))
            {
                throw new ArgumentException(string.Format("The vehicle is not in the garage.{0}", Environment.NewLine));
            }
            r_VehiclesInGarage[i_LicensePlate].Phone = i_Phone;
        }

        public void SetOwnerName(string i_LicensePlate, string i_OwnerName)
        {
            if (!CheckIfInGarage(i_LicensePlate))
            {
                throw new ArgumentException(string.Format("The vehicle is not in the garage.{0}", Environment.NewLine));
            }
            r_VehiclesInGarage[i_LicensePlate].Name = i_OwnerName;
        }

        public void SetStatusVehicle(string i_LicensePlate, GarageEnums.eVehicleStatus i_Status)
        {
            if (!CheckIfInGarage(i_LicensePlate))
            {
                throw new ArgumentException(string.Format("The vehicle is not in the garage.{0}", Environment.NewLine));
            }
            r_VehiclesInGarage[i_LicensePlate].Status = i_Status;
        }
    }
}