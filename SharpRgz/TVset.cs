using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    public class TvSet : AudioAndVideo
    {
        public short Frequency { get; set; }
        public short DiagonalSize { get; set; }

        public TvSet() : base()
        {
            Frequency = 50; 
            DiagonalSize = 24;
            Price = 7000;
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

            if (price < 7000 || price > 7000000)
                Price = 7000;
            else
                Price = price;

            if (frequency < 50 || frequency > 360)
                Frequency = 50;
            else
                Frequency = frequency;

            if (diagonalSize < 24 || diagonalSize > 115)
                DiagonalSize = 24;
            else
                DiagonalSize = diagonalSize;
        }

        // Оператор присваивания
        public TvSet Assign(TvSet other)
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

        // Переопределение метода ToString()
        public override string ToString()
        {
            return Print();
        }

        // Метод Print с вызовом базового метода
        protected new string Print()
        {
            string baseString = base.Print();
            return baseString + $"\tFrequency: {Frequency}\n\tDiagonal size: {DiagonalSize}\n\n";
        }
    }
}