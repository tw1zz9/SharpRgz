using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    public class Radio : AudioAndVideo
    {
        private double transmitterPower;
        private short hasBluetooth;

        public double TransmitterPower
        {
            get => transmitterPower;
            set
            {
                if (value < 0 || value > 200)
                    transmitterPower = 0.5;
                else
                    transmitterPower = value;
            }
        }

        public short HasBluetooth
        {
            get => hasBluetooth;
            set
            {
                if (value != 0 && value != 1)
                    hasBluetooth = 0;
                else
                    hasBluetooth = value;
            }
        }

        public Radio() : base()
        {
            TransmitterPower = 0.5;
            HasBluetooth = 0;
            Price = 300;
        }

        public Radio(string manufacturer, int price, double transmitterPower, short hasBluetooth) : base()
        {
            Init(manufacturer, price, transmitterPower, hasBluetooth);
        }

        public Radio(Radio other) : base()
        {
            Init(other.Manufacturer, other.Price, other.TransmitterPower, other.HasBluetooth);
        }

        protected void Init(string manufacturer, int price, double transmitterPower, short hasBluetooth)
        {
            // Используем базовый Init для manufacturer и price
            base.Init(manufacturer, price);

            // Проверка и установка transmitterPower
            if (transmitterPower < 0 || transmitterPower > 200)
                this.transmitterPower = 0.5;
            else
                this.transmitterPower = transmitterPower;

            // Проверка и установка hasBluetooth
            if (hasBluetooth != 0 && hasBluetooth != 1)
                this.hasBluetooth = 0;
            else
                this.hasBluetooth = hasBluetooth;

            // Дополнительная проверка цены для Radio
            if (price < 300 || price > 100000)
                Price = 300;
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