namespace HyperLib
{
    public class ASCII_Check
    {
        private static int[] asciis = null;

        public ASCII_Check()
        {
        }

        public static void InternalConvert(char[] toconvert) // Convert chars to ascii and save in var
        {
            for (int i = 0; i < toconvert.Length; i++)
            {
                asciis[i] = (int)toconvert[i];
            }
        }

        public static bool areLettersWithInternal() // check if the asciis in the var are only letters
        {
            bool isok = true;
            foreach(int i in asciis)
            {
                if (!isLetter(i)) {
                    isok = false;
                }
            }
            return isok;
        }

        public static bool isLetter(int asciicode)
        {
            bool isok = true;
            if ((asciicode >= 97 && asciicode <= 122) || (asciicode >= 65 && asciicode <= 90))
            { }
            else
                isok = false;
            return isok;
        }

        public static bool isLetterLowerCase(int asciicode)
        {
            bool isok = true;
            if (asciicode >= 97 && asciicode <= 122)
            { }
            else
                isok = false;
            return isok;
        }

        public static bool isLetterUpperCase(int asciicode)
        {
            bool isok = true;
            if (asciicode >= 65 && asciicode <= 90)
            { }
            else
                isok = false;
            return isok;
        }

        public static bool isLetterWithMoreChars(int asciicode)
        {
            bool isok = true;
            if ((asciicode >= 65 && asciicode <= 90) || (asciicode >= 97 && asciicode <= 122) || (asciicode >= 128 && asciicode <= 165))
            { }
            else
                isok = false;
            return isok;
        }

        public static bool isNumber(int asciicode)
        {
            bool isok = true;
            if (asciicode >= 48 && asciicode <= 57)
            { }
            else
                isok = false;
            return isok;
        }
    }
}
