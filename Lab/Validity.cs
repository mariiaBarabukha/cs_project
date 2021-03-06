using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Validity
    {
        public static bool checkValidity(string input)
        {
            char[] badSymbols = {'@', '-', '_', '!', '?', '+', '=', ')',
                '(', '*', '^', '$', '#', '"', '`', '~', '/', '\\', '.', ',', '|', '№', ';', '₴', '%', '&',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            if (input.IndexOfAny(badSymbols, 0) == -1 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkValidityEmail(string input)
        {
           
            if ((input.IndexOf('@', 0) != -1 && input.IndexOf('.', 0) != -1))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkValidityCurrency(string input)
        {
            if (input.Equals("UAH") || input.Equals("USD") || input.Equals("EUR"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool checkValiditySum(string input)
        {
            char[] badSymbols = {'@', '-', '_', '!', '?', '+', '=', ')',
                '(', '*', '^', '$', '#', '"', '`', '~', '/', '\\', ',', '|', '№', ';', '₴', '%', '&',
            'q', 'w', 'e', 'r', 'd', 'f', 't', 'y', 'u', 'i' , 'o', 'p', '[', ']', 'a', 's', 'g', 'h', 'j', 'k', 'l', 'z'
            , 'x', 'c', 'v', 'b', 'n', 'm', 'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы',
            'в', 'а', 'п', 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю'

            };
            if (input.IndexOfAny(badSymbols, 0) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double checkValidityTransaction(double sum)
        {
            while (sum == 0)
            {
                Console.WriteLine("Enter another sum, differed from 0 to make transaction:");
                var input = Console.ReadLine();
                if (!Validity.checkValiditySum(input))
                {
                    continue;
                }
                sum = Convert.ToDouble(input);
            }
            return sum;
        }
    }
}
