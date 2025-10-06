using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    public class TvSet : AudioAndVideo
    {
        private short frequency;
        private short diagonalSize;

        public short Frequency
        {
            get => frequency;
            set
            {
                if (value < 50 || value > 360)
                    frequency = 50;
                else
                    frequency = value;
            }
        }

        public short DiagonalSize
        {
            get => diagonalSize;
            set
            {
                if (value < 24 || value > 115)
                    diagonalSize = 24;
                else
                    diagonalSize = value;
            }
        }

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
            // Используем базовый Init для manufacturer и price
            base.Init(manufacturer, price);

            // Проверка и установка frequency
            if (frequency < 50 || frequency > 360)
                this.frequency = 50;
            else
                this.frequency = frequency;

            // Проверка и установка diagonalSize
            if (diagonalSize < 24 || diagonalSize > 115)
                this.diagonalSize = 24;
            else
                this.diagonalSize = diagonalSize;

            // Дополнительная проверка цены для TV
            if (price < 7000 || price > 7000000)
                Price = 7000;
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