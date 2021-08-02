using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.CosoleUI
{
    class ConsoleGarageInteface
    {
        public static void GarageUserInterface()
        {
            Garage myGarage = new Garage();
            bool goToManuAgain = true;

            GarageEnums.eMainMenuOption userSelection;
            ConsoleInputOutput.PrintWelcomeMessage();
            while (goToManuAgain)
            {
                try
                {
                    userSelection = ConsoleInputOutput.ChooseOption<GarageEnums.eMainMenuOption>("number");
                    switch (userSelection)
                    {
                        case GarageEnums.eMainMenuOption.InsertNewVehicleInGarage:
                            insertVehicle(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.ListOfLicensePlates:
                            printListOfLicensePlates(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.ChangeVehicleStatus:
                            changeVehicleStatus(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.WheelPressureToMax:
                            tryToFillAirInWheels(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.FuelVehicle:
                            tryToFuelVehicle(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.ChargeVehicle:
                            tryToChargeVehicle(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.InfoOfVehicle:
                            printDetails(myGarage);
                            break;
                        case GarageEnums.eMainMenuOption.Exit:
                            goToManuAgain = false;
                            break;
                        default:
                            throw new ArgumentException("Invalid Option Number. Try Again.");
                    }
                }

                catch (ValueOutOfRangeException valueEx)
                {
                    Console.WriteLine(string.Format("{0}{1}please try again.", valueEx.Message, Environment.NewLine));
                }

                catch (FormatException formatEx)
                {
                    Console.WriteLine(string.Format("{0}{1}please try again.", formatEx.Message, Environment.NewLine));
                }

                catch (ArgumentException argumentEx)
                {
                    Console.WriteLine(string.Format("{0}{1}please try again.", argumentEx.Message, Environment.NewLine));
                }

                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                }

                Console.ReadLine();//wait for enter
            }
        }

        private static void insertVehicle(Garage io_Garage)
        {
            string insertMsg = GeneralMethods.SplitByBigLetters(GarageEnums.eMainMenuOption.InsertNewVehicleInGarage.ToString());
            string fullInsertMsg = string.Format("{0}{1} {2}", "You chose to", insertMsg, "Please enter your license number");
            string licenseNumber = ConsoleInputOutput.TypeToGetString(fullInsertMsg);

            if (io_Garage.CheckIfInGarage(licenseNumber))
            {
                io_Garage.UpdateVehicleStatus(licenseNumber, GarageEnums.eVehicleStatus.InTreatment);
                Console.WriteLine(string.Format("The vehicle is already in the garage.His status changed to 'in reapair'.{0}", Environment.NewLine));
            }
            else
            {
                GarageEnums.eVehicle usersVehicleType = ConsoleInputOutput.ChooseOption<GarageEnums.eVehicle>("Vehicle");
                Vehicle usersVehicle = VehicleFactory.CreateVehicle(usersVehicleType);
                updateVehicleBaseDetails(licenseNumber, usersVehicle);
                VehicleInGarage newVehicleInGarage = new VehicleInGarage(usersVehicle);
                updateUsersDetails(newVehicleInGarage);
                setValuesToVehicle(newVehicleInGarage.Vehicle);
                io_Garage.AddVehicle(licenseNumber, newVehicleInGarage);
            }
        }

        private static void setValuesToVehicle(Vehicle usersVehicle)
        {
            List<Type> types = usersVehicle.ClassFieldTypes();
            List<object> newFieldValues = new List<object>();
            int typeListIndex = 0;

            try
            {
                foreach (string msg in usersVehicle.ClassFieldInstractions())
                {
                    if (types[typeListIndex].Equals(typeof(bool)))
                    {
                        newFieldValues.Add(ConsoleInputOutput.TypeToGetBool(msg));
                    }
                    else if (types[typeListIndex].Equals(typeof(string)))
                    {
                        newFieldValues.Add(ConsoleInputOutput.TypeToGetString(msg));
                    }
                    else if (types[typeListIndex].Equals(typeof(float)))
                    {
                        newFieldValues.Add(ConsoleInputOutput.TypeToGetFloat(msg));
                    }
                    else if (types[typeListIndex].Equals(typeof(int)))
                    {
                        newFieldValues.Add(ConsoleInputOutput.TypeToGetInt(msg));
                    }
                    else if (types[typeListIndex].IsEnum)
                    {
                        newFieldValues.Add(ConsoleInputOutput.TypeToGetString(msg));
                    }
                    typeListIndex++;
                }
                usersVehicle.SetValues(newFieldValues);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                setValuesToVehicle(usersVehicle);
            }

            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                setValuesToVehicle(usersVehicle);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                setValuesToVehicle(usersVehicle);
            }
        }

        private static void updateUsersDetails(VehicleInGarage io_UsersVehicle)
        {
            io_UsersVehicle.Name = ConsoleInputOutput.TypeToGetString("Please enter your name: ");
            updateUserPhoneNumber(io_UsersVehicle);
        }

        private static void updateUserPhoneNumber(VehicleInGarage io_UsersVehicle)
        {
            string userInput = ConsoleInputOutput.TypeToGetString("Please enter your phone number: ");
            int validInt;

            try
            {
                validInt = int.Parse(userInput);
                io_UsersVehicle.Phone = userInput;
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again, the phone number must be only numbers.{1}", ex.Message, Environment.NewLine));
                updateUserPhoneNumber(io_UsersVehicle);
            }
        }

        private static void updateVehicleBaseDetails(string i_LicenseNumber, Vehicle io_UsersVehicle)
        {
            io_UsersVehicle.LicenseNumber = i_LicenseNumber;
            updateVehicleModel(io_UsersVehicle);
            updateVehicleCurrentEnergy(io_UsersVehicle.Engine);
            io_UsersVehicle.CalcEnergyPrecent();
            updateWheelsCompany(io_UsersVehicle.Wheels);
            updateWheelsAirPressure(io_UsersVehicle.Wheels);
        }

        private static void updateVehicleModel(Vehicle io_UsersVehicle)
        {
            io_UsersVehicle.Model = ConsoleInputOutput.TypeToGetString("Please enter your vehicle model: ");
        }

        private static void updateVehicleCurrentEnergy(Engine io_UsersEngine)
        {
            try
            {
                io_UsersEngine.FillEnergy(ConsoleInputOutput.TypeToGetFloat("Please enter the current energy in your vehicle: "));
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.{1}", ex.Message, Environment.NewLine));
                updateVehicleCurrentEnergy(io_UsersEngine);
            }
        }

        private static void updateWheelsCompany(List<Wheel> io_VehicleWheels)
        {
            string wheelsCompanyName = ConsoleInputOutput.TypeToGetString("Please enter your tires company name: ");

            foreach (Wheel wheel in io_VehicleWheels)
            {
                wheel.CompanyName = wheelsCompanyName;
            }
        }

        private static void updateWheelsAirPressure(List<Wheel> io_VehicleWheels)
        {
            float wheelsCurrentPressure = ConsoleInputOutput.TypeToGetFloat("Please enter the current pressure in your tires: ");

            try
            {
                foreach (Wheel wheel in io_VehicleWheels)
                {
                    wheel.FillAir(wheelsCurrentPressure);
                }
            }

            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                updateWheelsAirPressure(io_VehicleWheels);
            }

        }

        private static void printListOfLicensePlates(Garage io_Garage)
        {
            GarageEnums.eLicensePlatePrintOption selectedPrintOption = ConsoleInputOutput.ChooseOption<GarageEnums.eLicensePlatePrintOption>("status option");
            int count = 1;

            if (selectedPrintOption == GarageEnums.eLicensePlatePrintOption.PrintAllPlates)
            {
                foreach (string tempVehicle in io_Garage.ListOfVehicles.Keys)
                {
                    Console.WriteLine("{0}){1}.", count, tempVehicle);
                }
            }
            else
            {
                foreach (KeyValuePair<string, VehicleInGarage> tempVehicle in io_Garage.ListOfVehicles)
                {
                    if ((int)tempVehicle.Value.Status == ((int)selectedPrintOption))
                    {
                        Console.WriteLine("{0}){1}.", count, tempVehicle.Key);
                    }
                }
            }
        }

        private static void changeVehicleStatus(Garage io_Garage)
        {
            string licensePlate = getLicenseNumber("update a vehicle status", io_Garage);
            GarageEnums.eVehicleStatus newStatus = ConsoleInputOutput.ChooseOption<GarageEnums.eVehicleStatus>("vehilce status");
            io_Garage.ListOfVehicles[licensePlate].Status = newStatus;
        }

        private static void fillAirInWheels(Garage io_Garage, string licensePlate)
        {
            try
            {
                io_Garage.ListOfVehicles[licensePlate].Vehicle.FillToMaxAir();
                Console.WriteLine(string.Format("Inflated air in the wheels successfully.{0}", Environment.NewLine));
            }

            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.{1}", ex.Message, Environment.NewLine));
                fillAirInWheels(io_Garage, licensePlate);
            }
        }

        private static void tryToFillAirInWheels(Garage io_Garage)
        {
            string licensePlate = getLicenseNumber("inflate wheels", io_Garage);
            fillAirInWheels(io_Garage, licensePlate);
        }

        private static void tryToFuelVehicle(Garage io_MyGarage)
        {
            string licensePlate = getLicenseNumber("fill gas tank", io_MyGarage);
            if (io_MyGarage.ListOfVehicles[licensePlate].Vehicle.Engine as GasEngine == null)
            {
                throw new FormatException(string.Format("The vehicle isn't on fuel.{0}", Environment.NewLine));
            }
            fuelVehicle(io_MyGarage, licensePlate);
        }

        private static void fuelVehicle(Garage io_MyGarage, string licensePlate)
        {
            try
            {
                GarageEnums.eGasType gasType = ConsoleInputOutput.ChooseOption<GarageEnums.eGasType>("fuel type");
                float litersToFuel = ConsoleInputOutput.TypeToGetFloat(string.Format("Please enter the number of liters you want to refuel.{0}", Environment.NewLine));

                (io_MyGarage.ListOfVehicles[licensePlate].Vehicle.Engine as GasEngine).FillGas(litersToFuel, gasType);
                io_MyGarage.ListOfVehicles[licensePlate].Vehicle.CalcEnergyPrecent();
                Console.WriteLine("You have successfully refueled the vehicle.");
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                Console.ReadLine();
                fuelVehicle(io_MyGarage, licensePlate);
            }

            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                Console.ReadLine();
                fuelVehicle(io_MyGarage, licensePlate);
            }
        }

        private static void chargeVehicle(Garage io_Garage, string licensePlate)
        {
            try
            {
                float minutesToCharge = ConsoleInputOutput.TypeToGetFloat(string.Format("Please enter the number of minutes you want to charge your car.{0}", Environment.NewLine));

                (io_Garage.ListOfVehicles[licensePlate].Vehicle.Engine as ElectricEngine).ChargeBattery(minutesToCharge / 60f);
                io_Garage.ListOfVehicles[licensePlate].Vehicle.CalcEnergyPrecent();
                Console.WriteLine("You have successfully charged the vehicle.");
            }

            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                chargeVehicle(io_Garage, licensePlate);
            }
        }

        private static void tryToChargeVehicle(Garage io_MyGarage)
        {
            string licensePlate = getLicenseNumber("charge battery", io_MyGarage);

            if (io_MyGarage.ListOfVehicles[licensePlate].Vehicle.Engine as ElectricEngine == null)
            {
                throw new FormatException("The vehicle is not electric.");
            }
            chargeVehicle(io_MyGarage, licensePlate);
        }

        private static void printDetails(Garage io_Garage)
        {
            string licensePlate = getLicenseNumber("show vehicle details", io_Garage);

            Console.WriteLine(io_Garage.ListOfVehicles[licensePlate].ToString());
            Console.ReadLine();
        }

        private static string getLicenseNumber(string i_UserMsg, Garage io_Garage)
        {
            string licensePlate = ConsoleInputOutput.TypeToGetString(string.Format("You chose to {0}{1}{2}", i_UserMsg, " please enter a license number:", Environment.NewLine));

            if (!io_Garage.CheckIfInGarage(licensePlate))
            {
                throw new ArgumentException("The vehicle is not in the garage.{0}");
            }

            return licensePlate;
        }
    }
}
