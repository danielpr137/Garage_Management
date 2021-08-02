using System;
using Ex03.GarageLogic;

namespace Ex03.CosoleUI
{
    class ConsoleInputOutput
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to DotNet garage!");
            Console.ReadLine();
        }

        public static T ChooseOption<T>(string i_EnumType)
        {
            T enumFromUser;
            string selectedVehicle;
            int optionNumber = 1;

            Console.Clear();
            Console.WriteLine("Please choose a {0} from the list:", i_EnumType);
            foreach (string option in Enum.GetNames((typeof(T))))
            {
                Console.WriteLine("{0}){1}", optionNumber++, GeneralMethods.SplitByBigLetters(option), Environment.NewLine);
            }
            selectedVehicle = Console.ReadLine();

            try
            {
                enumFromUser = (T)Enum.Parse(typeof(T), selectedVehicle);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                enumFromUser = ChooseOption<T>(i_EnumType);
            }

            return enumFromUser;
        }

        public static void PrintDetails(string i_ChosenVehicle)
        {
            Console.WriteLine(i_ChosenVehicle);
        }

        public static bool TypeToGetBool(string i_CurrentMsg)
        {
            Console.WriteLine(i_CurrentMsg);
            string userInput = Console.ReadLine();
            bool userAnswer;

            try
            {
                userAnswer = bool.Parse(userInput);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.", ex.Message, Environment.NewLine));
                userAnswer = TypeToGetBool(i_CurrentMsg);
            }

            return userAnswer;
        }

        public static string TypeToGetString(string i_CurrentMsg)
        {
            Console.WriteLine(i_CurrentMsg);

            return Console.ReadLine();
        }

        public static int TypeToGetInt(string i_CurrentMsg)
        {
            Console.WriteLine(i_CurrentMsg);
            string userInput = Console.ReadLine();
            int validInt;

            try
            {
                validInt = int.Parse(userInput);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.{1}", ex.Message, Environment.NewLine));
               validInt = TypeToGetInt(i_CurrentMsg);
            }

            return validInt;
        }

        public static float TypeToGetFloat(string i_CurrentMsg)
        {
            Console.WriteLine(i_CurrentMsg);
            string userInput = Console.ReadLine();
            float validFloat;

            try
            {
                validFloat = float.Parse(userInput);
            }

            catch (FormatException ex)
            {
                Console.WriteLine(string.Format("{0}{1}please try again.{1}", ex.Message, Environment.NewLine));
                validFloat = TypeToGetInt(i_CurrentMsg);
            }

            return validFloat;
        }
    }
}
