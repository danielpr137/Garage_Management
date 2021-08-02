using System;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle (GarageEnums.eVehicle i_VehicleType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case GarageEnums.eVehicle.GasMotorcycle:
                    newVehicle = new GasMotorcycle();
                    break;
                case GarageEnums.eVehicle.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle();
                    break;
                case GarageEnums.eVehicle.GasCar:
                    newVehicle = new GasCar();
                    break;
                case GarageEnums.eVehicle.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case GarageEnums.eVehicle.Truck:
                    newVehicle = new Truck();
                    break;
                default:
                    throw new Exception("Factory Exeption, Invalid Vehicle");
            }

            return newVehicle;
        }
    }
}
