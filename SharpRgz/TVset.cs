using System;

namespace SharpRgz
{
    public class TvSet : AudioAndVideo
    {
        private const short MinFrequency = 50;
        private const short MaxFrequency = 360;

        private const short MinDiagonalSize = 24;
        private const short MaxDiagonalSize = 115;

        private const int MinPriceForTv = 7000;
        private const int MaxPriceForTv = 7000000;

        private short frequency;
        private short diagonalSize;

        public short Frequency
        {
            get => frequency;
            set
            {
                if (value < MinFrequency || value > MaxFrequency)
                    frequency = MinFrequency;
                else
                    frequency = value;
            }
        }

        public short DiagonalSize
        {
            get => diagonalSize;
            set
            {
                if (value < MinDiagonalSize || value > MaxDiagonalSize)
                    diagonalSize = MinDiagonalSize;
                else
                    diagonalSize = value;
            }
        }

        public TvSet() : base()
        {
            Frequency = MinFrequency;
            DiagonalSize = MinDiagonalSize;
            Price = MinPriceForTv;
        }

        public TvSet(string manufacturer, int price, short frequency, short diagonalSize) : base()
        {
            Init(manufacturer, price, frequency, diagonalSize);
        }

        public TvSet(TvSet other) : base()
        {
            Init(other.Manufacturer, other.Price, other.Frequency, other.DiagonalSize);
        }

        protected void Init(string manufacturer, int price, short frequency, short diagonalSize)
        {
            base.Init(manufacturer, price);

            Frequency = frequency;
            DiagonalSize = diagonalSize;

            if (price < MinPriceForTv || price > MaxPriceForTv)
                Price = MinPriceForTv;
            else
                Price = price;
        }

        public TvSet Assign(TvSet other) // Сравнение
        {
            if (this != other)
            {
                Manufacturer = other.Manufacturer;
                Price = other.Price;
                Frequency = other.Frequency;
                DiagonalSize = other.DiagonalSize;
            }
            return this;
        }

        public override string ToString() // Конвертирование в строку
        {
            return Print();
        }

        protected new string Print() // Вывод
        {
            string baseString = base.Print();
            return baseString + $"\tFrequency: {Frequency}\n\tDiagonal size: {DiagonalSize}\n\n";
        }
    }
}
