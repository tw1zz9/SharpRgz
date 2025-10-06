using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    public class Radio : AudioAndVideo
    {
        public double TransmitterPower { get; set; }
        public short HasBluetooth { get; set; }

        public Radio() : base()
        {
            TransmitterPower = 0;
            HasBluetooth = 0;
            Price = 300; 
        }

        public Radio(string manufacturer, int price, double transmitterPower, short hasBluetooth)
            : base()
        {
            Init(manufacturer, price, transmitterPower, hasBluetooth);
        }

        public Radio(Radio other)
            : base()
        {
            Init(other.Manufacturer, other.Price, other.TransmitterPower, other.HasBluetooth);
        }

        protected void Init(string manufacturer, int price, double transmitterPower, short hasBluetooth)
        {
            try
            {
                IsStr(manufacturer);
                Manufacturer = manufacturer;
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
                Manufacturer = "Unknown";
            }

            if (price < 300 || price > 100000)
                Price = 300;
            else
                Price = price;

            if (hasBluetooth != 0 && hasBluetooth != 1)
                HasBluetooth = 0;
            else
                HasBluetooth = hasBluetooth;

            TransmitterPower = transmitterPower;
            
        }

        // Оператор присваивания
        public Radio Assign(Radio other)
        {
            if (this != other)
            {

                Manufacturer = other.Manufacturer;
                Price = other.Price;

                TransmitterPower = other.TransmitterPower;
                HasBluetooth = other.HasBluetooth;
            }
            return this;
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return Print();
        }

        // Метод Print с вызовом базового метода
        protected new string Print()
        {
            string baseString = base.Print();
            return baseString + $"\tTransmitter power: {TransmitterPower}\n\tHas bluetooth: {HasBluetooth}\n";
        }
    }
}