using System;
using System.Collections.Generic;

namespace HyperLib
{
    public class Double
    {
        private static bool aredoubles;
        private static String[] parts;

        public Double()
        {
            aredoubles = true;
            parts = null;
        }

        public static bool isDouble(String value)
        {
			if (value != "" && value != null)
			{
				if (value.Contains("."))
				{
					parts = value.Split('.');
				}
				else {
					parts = value.Split(',');
				}

				if (parts.Length != 2)
					return false;

				if (parts.Length == 2 && Integer.isInteger(parts[0]) && Integer.isInteger(parts[1])) {
					return true;
				}

			}

			return false;
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
