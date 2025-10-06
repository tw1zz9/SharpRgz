using System;

namespace SharpRgz
{
    public class Radio : AudioAndVideo
    {
        private const double MinTransmitterPower = 0.0;
        private const double MaxTransmitterPower = 200.0;

        private const short MinHasBluetooth = 0;
        private const short MaxHasBluetooth = 1;

        private const int MinPriceForRadio = 300;
        private const int MaxPriceForRadio = 100000;

        private double transmitterPower;
        private short hasBluetooth;

        public double TransmitterPower
        {
            get => transmitterPower;
            set
            {
                if (value < MinTransmitterPower || value > MaxTransmitterPower)
                    transmitterPower = MinTransmitterPower;
                else
                    transmitterPower = value;
            }
        }

        public short HasBluetooth
        {
            get => hasBluetooth;
            set
            {
                if (value != MinHasBluetooth && value != MaxHasBluetooth)
                    hasBluetooth = MinHasBluetooth;
                else
                    hasBluetooth = value;
            }
        }

        public Radio() : base()
        {
            TransmitterPower = MinTransmitterPower;
            HasBluetooth = MinHasBluetooth;
            Price = MinPriceForRadio;
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
            base.Init(manufacturer, price);

            if (transmitterPower < MinTransmitterPower || transmitterPower > MaxTransmitterPower)
                this.transmitterPower = MinTransmitterPower;
            else
                this.transmitterPower = transmitterPower;

            if (hasBluetooth != MinHasBluetooth && hasBluetooth != MaxHasBluetooth)
                this.hasBluetooth = MinHasBluetooth;
            else
                this.hasBluetooth = hasBluetooth;

            if (price < MinPriceForRadio || price > MaxPriceForRadio)
                Price = MinPriceForRadio;
            else
                Price = price;
        }

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

        public override string ToString()
        {
            return Print();
        }

        protected new string Print()
        {
            string baseString = base.Print();
            return baseString + $"\tTransmitter power: {TransmitterPower}\n\tHas bluetooth: {HasBluetooth}\n";
        }
    }
}
