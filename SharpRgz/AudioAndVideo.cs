using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    public class AudioAndVideo
    {
        protected string Manufacturer { get; set; }
        protected int Price { get; set; }

        public AudioAndVideo()
        {
            Manufacturer = "Unknown";
            Price = 0;
        }

        public AudioAndVideo(string manufacturer, int price)
        {
            Init(manufacturer, price);
        }

        public AudioAndVideo(AudioAndVideo other)
        {
            Init(other.Manufacturer, other.Price);
        }

        protected void Init(string manufacturer, int price)
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

            if (price < 300 || price > 7000000)
                Price = 300;
            else
                Price = price;
        }

        protected void IsStr(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Empty input!");

            char[] chars = str.ToCharArray();

            if (!char.IsUpper(chars[0]))
                chars[0] = char.ToUpper(chars[0]);

            for (int i = 0; i < chars.Length; i++)
            {
                char ch = chars[i];
                if (char.IsWhiteSpace(ch)) continue;

                if (char.IsLetterOrDigit(ch))
                {
                    if (char.IsLetter(ch) && !char.IsLower(ch) && i > 0)
                        chars[i] = char.ToLower(ch);
                    else continue;
                }
                else throw new ArgumentException("Incorrect input!");
            }
        }

        // Оператор присваивания
        public AudioAndVideo Assign(AudioAndVideo other)
        {
            if (this != other)
            {
                this.Manufacturer = other.Manufacturer;
                this.Price = other.Price;
            }
            return this;
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return Print();
        }

        // "Метод" Print
        protected string Print()
        {
            return "Basic Specifications of Audio and Videodevices" + Environment.NewLine +
                   $"\tManufacturer: {Manufacturer}" + Environment.NewLine +
                   $"\tPrice: {Price}" + Environment.NewLine;
        }
    }
}
