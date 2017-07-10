using System;
using System.Linq;

namespace HyperLib
{
    public class Integer
    {
        public static bool isInteger(String value)
        {
            if (value == "" || value == null)
                return false;

            bool isnumber = true;
            char[] numbers = new char[10];
            numbers[0] = '0'; numbers[1] = '1';
            numbers[2] = '2'; numbers[3] = '3';
            numbers[4] = '4'; numbers[5] = '5';
            numbers[6] = '6'; numbers[7] = '7';
            numbers[8] = '8'; numbers[9] = '9';
            if (value == "" && value == null) return false;
            foreach (char x in value) { if (numbers.Contains(x)) { } else { isnumber = false; } }
            if (isnumber) return true;
            else return false;
        }

        public static bool areIntegers(String[] values)
        {
            if (values == null)
                return false;

            bool arenumbers = true;
            foreach (String value in values)
            {
                bool isnumber = isInteger(value);
                if (isnumber) { } else arenumbers = false;
            }
            if (arenumbers) return true;
            else return false;
        }
    }
}
