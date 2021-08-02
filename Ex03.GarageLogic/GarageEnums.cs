using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageEnums
    {
        public enum eMainMenuOption
        {
            InsertNewVehicleInGarage = 1,
            ListOfLicensePlates,
            ChangeVehicleStatus,
            WheelPressureToMax,
            FuelVehicle,
            ChargeVehicle,
            InfoOfVehicle,
            Exit,
        }

        public enum eLicensePlatePrintOption
        {
            PrintOnlyInTreatmentPlates = 1,
            PrintOnlyDoneTreatmentPlates,
            PrintOnlyPaidTeatmentPlates,
            PrintAllPlates,
        }

        public enum eGasType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler,
        }

        public enum eCarColor
        {
            Red = 1,
            Silver,
            White,
            Black,
        }

        public enum eCarDoorNumber
        {
            Two = 2,
            Three,
            Four,
            Five,
        }

        public enum eEngineType
        {
            Gas,
            Electric,
        }

        public enum eMotorcycleLicenseType
        {
            A = 1,
            B1,
            AA,
            BB,
        }

        public enum eVehicleStatus
        {
            InTreatment = 1,
            DoneTreatment,
            PaidForTreatment,
        }

        public enum eVehicle
        {
            GasCar = 1,
            ElectricCar,
            GasMotorcycle,
            ElectricMotorcycle,
            Truck,
        }
    }
}
