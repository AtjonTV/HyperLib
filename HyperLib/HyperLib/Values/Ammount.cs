namespace HyperLib.Values
{
    public class Ammount
    {
        public Ammount()
        {

        }

        public static bool compareStringArray(string[] values, string comparevalue)
        {
            foreach(string value in values)
            {
                if (value.ToLower() == comparevalue.ToLower())
                    return true;
                else
                    return false;
            }

            return false;
        }

        public static bool compareIntArray(int[] values, int comparevalue)
        {
            foreach (int value in values)
            {
                if (value == comparevalue)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public static bool compareByteArray(byte[] values, byte comparevalue)
        {
            foreach (byte value in values)
            {
                if (value == comparevalue)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public static bool compareBoolArray(bool[] values, bool comparevalue)
        {
            foreach (bool value in values)
            {
                if (value == comparevalue)
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
