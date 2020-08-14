using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    /// <summary>
    /// 1 = I, 5 = V, 10 = X, 50 = L, 100 = C, 500 = D, 1000 = M
    /// </summary>
    public class KataRomanNumeral
    {       
        public string GetRomanNumeral(int number)
        {
            string result = "";

            // The solution should get the students to 
            // notice that there is a repetitive while loop
            /*
                while (number >= 1)
                {
                    number -= 1;
                    result += "I";
                }   
                while (number >= 5)
                {
                    number -= 5;
                    result += "V";
                }   
            */


            result += ConvertArabicToRoman(1000, "M", ref number);
            result += ConvertArabicToRoman(500, "D", ref number);
            result += ConvertArabicToRoman(100, "C", ref number);
            result += ConvertArabicToRoman(50, "L", ref number);
            result += ConvertArabicToRoman(10, "X", ref number);
            result += ConvertArabicToRoman(5, "V", ref number);
            result += ConvertArabicToRoman(1, "I", ref number);

            // Fix the long form to short form
            // CCCC -> CD
            // LXXXX -> XC
            result = FixLongFormToShortForm(result, "CCCC", "CD");
            result = FixLongFormToShortForm(result, "LXXXX", "XC");
            result = FixLongFormToShortForm(result, "XXXX", "XL");
            result = FixLongFormToShortForm(result, "VIIII", "IX");
            result = FixLongFormToShortForm(result, "IIII", "IV");

            return result;
        }

        private string FixLongFormToShortForm(string result, string find, string replace)
        {
            return result.Replace(find, replace);
        }

        private string ConvertArabicToRoman(int places, string romanNumeral, ref int number)
        {
            string result = "";
            while (number >= places)
            {
                number -= places;
                result += romanNumeral;
            }

            return result;
        }
    }
}
