using System;

namespace HyperLib.Exceptions
{
    class BV_ValueException:Exception
    {
        public BV_ValueException() : base("A value was invalid and can't be used now!")
        {

        }

        public BV_ValueException(string message) : base(message)
        {

        }
    }

    class BV_InvalidBuildDateException : BV_ValueException
    {
        public BV_InvalidBuildDateException() : base("The Build date must be over 1886 and before "+DateTime.Now.Year+1+" !")
        {

        }
    }
    class BV_InvalidManufacturerException : BV_ValueException
    {
        public BV_InvalidManufacturerException() : base("The Manufacturer can only be written in upper or lower case letters!")
        {

        }
    }
    class BV_InvalidPowerException : BV_ValueException
    {
        public BV_InvalidPowerException() : base("The Power can only be over 0 and lower 10.000!")
        {

        }
    }
    class BV_InvalidModellException : BV_ValueException
    {
        public BV_InvalidModellException() : base("The Modell can only be written in upper or lower case letters!")
        {

        }
    }
    class BV_InvalidMarkException : BV_ValueException
    {
        public BV_InvalidMarkException() : base("The Mark can only be written in this pattern: AB-C123456!")
        {

        }
    }
}
