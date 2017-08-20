using System;
using System.Text.RegularExpressions;

namespace HyperLib
{
    public class BasicVehicle
    {
        protected string _manufacturer;
        protected string _modell;
        protected string _mark;
        protected int _builddate;
        protected int _power;

        public BasicVehicle(string manufacturer, string modell, string mark, int builddate, int power)
        {
            Regex regTXT = new Regex(@"^[A-Za-z]{3,30}$");
            Regex regMRK = new Regex(@"^[A-Z]{1,2}[-][A-Z0-9]{3,7}$");

            if (regTXT.IsMatch(manufacturer))
                _manufacturer = manufacturer;
            else
                throw new BV_InvalidManufacturerException();


            if (regTXT.IsMatch(modell))
                _modell = modell;
            else
                throw new BV_InvalidModellException();


            if (regMRK.IsMatch(mark))
                _mark = mark;
            else
                throw new BV_InvalidMarkException();


            if (builddate > 1886 && builddate < DateTime.Now.Year)
                _builddate = builddate;
            else
                throw new BV_InvalidBuildDateException();


            if (power > 0 && power <= 10000)
                _power = power;
            else
                throw new BV_InvalidPowerException();
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                if (Letter.areOnlyLetters(value))
                    _manufacturer = value;
                else
                    throw new BV_InvalidManufacturerException();
            }
        }

        public string Modell
        {
            get
            {
                return _modell;
            }
            set
            {
                if (Letter.areOnlyLetters(value))
                    _modell = value;
                else
                    throw new BV_InvalidModellException();
            }
        }

        public string Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                Regex regMRK = new Regex(@"^[A-Z]{1,2}[-][A-Z0-9]{3,7}$");
                if (regMRK.IsMatch(value))
                    _mark = value;
                else
                    throw new BV_InvalidMarkException();
            }
        }

        public int Builddate
        {
            get
            {
                return _builddate;
            }
            set
            {
                if (value > 1886 && value < DateTime.Now.Year)
                    _builddate = value;
                else
                    throw new BV_InvalidBuildDateException();
            }
        }

        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                if (value > 0 && value <= 10000)
                    _power = value;
                else
                    throw new BV_InvalidPowerException();
            }
        }

        public override string ToString()
        {
            return "Manufacturer: " + _manufacturer + " , Modell: " + _modell + " , Mark: "+_mark+" , Builddate: " + _builddate + " , Power: " + _power;
        }
    }
}
