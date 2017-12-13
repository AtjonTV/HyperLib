using System;

namespace HyperLib.Random
{
    public class Generator
    {
        private GeneratorType Type;

        public Generator(GeneratorType type)
        {
            Type = type;
        }

        public string Generate(GeneratorCharset Charset)
        {
            if(Charset == GeneratorCharset.All)
            {
                if (Type == GeneratorType.RandomKey4)
                    return genAll(4);
                if (Type == GeneratorType.RandomKey8)
                    return genAll(8);
                if (Type == GeneratorType.RandomKey16)
                    return genAll(16);
                if (Type == GeneratorType.RandomKey32)
                    return genAll(32);
                if (Type == GeneratorType.RandomKey64)
                    return genAll(64);
                if (Type == GeneratorType.RandomKey128)
                    return genAll(128);
            }

            if(Charset == GeneratorCharset.NumbersLowerUpperCase)
            {
                if (Type == GeneratorType.RandomKey4)
                    return genNLU(4);
                if (Type == GeneratorType.RandomKey8)
                    return genNLU(8);
                if (Type == GeneratorType.RandomKey16)
                    return genNLU(16);
                if (Type == GeneratorType.RandomKey32)
                    return genNLU(32);
                if (Type == GeneratorType.RandomKey64)
                    return genNLU(64);
                if (Type == GeneratorType.RandomKey128)
                    return genNLU(128);
            }

            return "An Error Accoured while processing 'GeneratorType' which was given with the Constructor";
        }


        private string genAll(int length)
        {
            System.Random rnd = new System.Random();
            string key = "";
            for (int i = 0; i < (length - 1); i++)
            {
                int chr = 0;
                int rnda = rnd.Next(0, 4);
                switch (rnda)
                {
                    case 0:
                        chr = rnd.Next(48, 57);
                        key += (char)chr;
                        break;
                    case 1:
                        chr = rnd.Next(65, 90);
                        key += (char)chr;
                        break;
                    case 2:
                        chr = rnd.Next(97, 122);
                        key += (char)chr;
                        break;
                    case 3:
                        chr = rnd.Next(35, 38);
                        key += (char)chr;
                        break;
                }
            }
            return key;
        }

        private string genNLU(int length)
        {
            System.Random rnd = new System.Random();
            string key = "";
            for (int i = 0; i < (length - 1); i++)
            {
                int chr = 0;
                int rnda = rnd.Next(0, 3);
                switch (rnda)
                {
                    case 0:
                        chr = rnd.Next(48, 57);
                        key += (char)chr;
                        break;
                    case 1:
                        chr = rnd.Next(65, 90);
                        key += (char)chr;
                        break;
                    case 2:
                        chr = rnd.Next(97, 122);
                        key += (char)chr;
                        break;
                }
            }
            return key;
        }
    }
}