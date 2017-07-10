using System;
using System.Linq;

namespace HyperLib
{
    public class Letter
    {
        private static bool areonlyletters;
        private static char[] lcl = new char[26];

        public Letter()
        {
            areonlyletters = true;
            lcl[0] = 'a'; lcl[1] = 'b'; lcl[2] = 'c'; lcl[3] = 'd'; lcl[4] = 'e'; lcl[5] = 'f'; lcl[6] = 'g';
            lcl[7] = 'h'; lcl[8] = 'i'; lcl[9] = 'j'; lcl[10] = 'k'; lcl[11] = 'l'; lcl[12] = 'm'; lcl[13] = 'n';
            lcl[14] = 'o'; lcl[15] = 'p'; lcl[16] = 'q'; lcl[17] = 'r'; lcl[18] = 's'; lcl[19] = 't'; lcl[20] = 'u';
            lcl[21] = 'v'; lcl[22] = 'w'; lcl[23] = 'x'; lcl[24] = 'y'; lcl[25] = 'z';
        }

        public static bool areOnlyLetters(String value)
        {
            if (value == "" || value == null)
                return false;

            foreach (char x in value.ToLower())
            {
               if(!lcl.Contains(x)) areonlyletters = false;
            }

            return areonlyletters;
        }

        public static bool isLetter(char value)
        {
            if (lcl.Contains(value)) return true;
            else return false;
        }
    }
}
