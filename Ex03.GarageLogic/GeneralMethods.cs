using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GeneralMethods
    {
        public static string SplitByBigLetters(string i_Sentence)
        {
            StringBuilder newSentence = new StringBuilder();
            StringBuilder word = new StringBuilder();
            foreach (char letter in i_Sentence)
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    newSentence.Append(word.ToString());
                    newSentence.Append(" ");
                    word.Clear();
                }

                word.Append(letter);
            }

            newSentence.Append(word.ToString());

            return newSentence.ToString();
        }

        public static T ConvertToEnum<T>(object i_ObjToEnum)
        {
            T enumVal = (T)Enum.Parse(typeof(T), i_ObjToEnum.ToString());

            return enumVal;
        }
    }
}
