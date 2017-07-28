using System;

namespace HyperLib
{
    public class Generator
    {
        private GeneratorType Type;

        public Generator(GeneratorType type)
        {
            Type = type;
        }

        public string Generate()
        {
            if (Type == GeneratorType.RandomKey4)
                return gen(4);
            if (Type == GeneratorType.RandomKey8)
                return gen(8);
            if (Type == GeneratorType.RandomKey16)
                return gen(16);
            if (Type == GeneratorType.RandomKey32)
                return gen(32);
            if (Type == GeneratorType.RandomKey64)
                return gen(64);
            if (Type == GeneratorType.RandomKey128)
                return gen(128);

            return "An Error Accoured while processing 'GeneratorType' which was given with the Constructor";
        }


        private string gen(int length)
        {
            Random rnd = new Random();
            string key = "";
            for (int i = 0; i < (length - 1); i++)
            {
                int chr = rnd.Next(33, 126);
                key += (char)chr;
            }
            return key;
        }
    }
}