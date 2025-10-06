using System;

namespace SharpRgz
{
    public class AudioAndVideo
    {
        private const int MinPrice = 300; 
        private const int MaxPrice = 7000000;
        private const string DefaultManufacturer = "Unknown";

        private string manufacturer;
        private int price;

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                try
                {
                    IsStr(value);
                    manufacturer = value;
                }
                catch (ArgumentException e)
                {
                    Console.Error.WriteLine(e.Message);
                    manufacturer = DefaultManufacturer;
                }
            }
        }

        public int Price
        {
            get => price;
            set
            {
                if (value < MinPrice || value > MaxPrice)
                    price = MinPrice;  
                else
                    price = value;
            }
        }

        public AudioAndVideo()
        {
            Manufacturer = DefaultManufacturer;
            Price = MinPrice; 
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
                this.manufacturer = manufacturer;
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
                this.manufacturer = DefaultManufacturer;
            }

            if (price < MinPrice || price > MaxPrice)
                this.price = MinPrice;
            else
                this.price = price;
        }

        protected void IsStr(string str) // Проверка на строковый формат и преобразование в него
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

            manufacturer = new string(chars);
        }

        public AudioAndVideo Assign(AudioAndVideo other) // Сравнение
        {
            if (this != other)
            {
                this.Manufacturer = other.Manufacturer;
                this.Price = other.Price;
            }
            return this;
        }

        public override string ToString() // Конвертирование в строку
        {
            return Print();
        }

        protected string Print() // Вывод
        {
            return "Basic Specifications of Audio and Videodevices" + Environment.NewLine +
                   $"\tManufacturer: {Manufacturer}" + Environment.NewLine +
                   $"\tPrice: {Price}" + Environment.NewLine;
        }
    }
}
