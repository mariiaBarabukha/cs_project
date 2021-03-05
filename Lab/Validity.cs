﻿using System;
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
            if (input.IndexOfAny(badSymbols, 0) != -1 || input.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkValidityEmail(string input)
        {
           
            if ((input.IndexOf('@', 0) != -1 && input.IndexOf('.', 0) != -1) || input.Equals(""))
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
