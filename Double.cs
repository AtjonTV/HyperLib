using System;
using System.Collections.Generic;

namespace HyperLib
{
    public class Double
    {
        private static bool isdouble;
        private static bool aredoubles;
        private static String[] parts;

        public Double()
        {
            isdouble = true;
            aredoubles = true;
            parts = null;
        }

        public static bool isDouble(String value)
        {
            if (value == "" || value == null)
                return false;

            if (value.Contains(","))
                parts = value.Split(',');
            else if (value.Contains("."))
                parts = value.Split('.');
            else
                isdouble = false;

            if (parts.Length > 2)
                isdouble = false;

            if (isdouble)
            {
                if (!Integer.isInteger(parts[0]) && !Integer.isInteger(parts[1]))
                    isdouble = false;
            }

            return isdouble;
        }

        public static bool areDoubles(List<String> values)
        {
            if (values == null)
                return false;

            foreach (String value in values)
            {
                if(!isDouble(value)) aredoubles = false;
            }
            return aredoubles;
        }
    }
}
