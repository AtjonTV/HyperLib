using System;
using System.Collections.Generic;

namespace HyperLib.Values
{
    public class Boolean
    {
        private static bool arebooleans;

        public Boolean()
        {
            arebooleans = true;
        }

        public static bool isBoolean(String value)
        {
            if (value == "" || value == null)
                return false;

            if (value.ToLower() == "true")
                return true;
            else
                return false;
        }

        public static bool areBooleans(List<String> values)
        {
            if (values == null)
                return false;

            foreach (String value in values)
            {
                if (!isBoolean(value)) arebooleans = false;
            }
            return arebooleans;
        }
    }
}
