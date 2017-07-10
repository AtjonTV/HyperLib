using System;

namespace HyperLib
{
    public class ASCII
    {
        private static char[] CharCache;
        private static int[] IntCache;

        public ASCII()
        {
            IntCache = null;
            CharCache = null;
        }

        public static int[] StringToAscii(String value)
        {
            CharCache = value.ToCharArray();
            for(int i = 0; i < value.Length; i++)
            {
                IntCache[i] = CharToAscii(CharCache[i]);
            }
            return IntCache;
        }

        public static string AsciiToString(int[] values)
        {
            for(int i = 0; i < values.Length; i++)
            {
                CharCache[i] = AsciiToChar(values[i]);
            }
            return CharCache.ToString();
        }

        public static int CharToAscii(char value)
        {
            return (int)value;
        }

        public static char AsciiToChar(int value)
        {
            return (char)value;
        }

    }
}
