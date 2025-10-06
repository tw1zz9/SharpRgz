using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRgz
{
    class Program
    {
        private static List<AudioAndVideo> objects = new List<AudioAndVideo>();

        static void Main(string[] args)
        {
            int choice = 0;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine(" 1. Add an object");
                Console.WriteLine(" 2. Print all objects");
                Console.WriteLine(" 3. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddObject();
                            break;
                        case 2:
                            PrintObjects();
                            break;
                        case 3:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            CleanupObjects();
        }

        static string InputString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static int InputInt(string prompt)
        {
            Console.Write(prompt);
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return result;
        }

        static double InputDouble(string prompt)
        {
            Console.Write(prompt);
            double result;
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return result;
        }

        static short InputShort(string prompt)
        {
            Console.Write(prompt);
            short result;
            while (!short.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return result;
        }

        static void AddObject()
        {
            Console.WriteLine("\nSelect the type of object to add:");
            Console.WriteLine(" 1. Audio and video");
            Console.WriteLine(" 2. Radio");
            Console.WriteLine(" 3. Tv");
            Console.Write("Enter number of the type: ");

            if (!int.TryParse(Console.ReadLine(), out int type))
            {
                Console.WriteLine("Invalid type selected.");
                return;
            }

            AudioAndVideo obj = null;

            if (type == 1)
            {
                string manufacturer = InputString("Enter manufacturer: ");
                int price = InputInt("Enter price: ");

                obj = new AudioAndVideo(manufacturer, price);
            }
            else if (type == 2)
            {
                string manufacturer = InputString("Enter manufacturer: ");
                int price = InputInt("Enter price: ");
                double transmitterPower = InputDouble("Enter transmitter power (0-200): ");
                short hasBluetooth = InputShort("Does it have bluetooth? (1 for yes, 0 for no): ");

                obj = new Radio(manufacturer, price, transmitterPower, hasBluetooth);
            }
            else if (type == 3)
            {
                string manufacturer = InputString("Enter manufacturer: ");
                int price = InputInt("Enter price: ");
                short frequency = InputShort("Enter frequency: ");
                short diagonalSize = InputShort("Enter diagonal size: ");

                obj = new TvSet(manufacturer, price, frequency, diagonalSize);
            }
            else
            {
                Console.WriteLine("Invalid type selected.");
                return;
            }

            objects.Add(obj);
            Console.WriteLine("Object added successfully.");
        }

        static void PrintObjects()
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("\nList is empty.");
                return;
            }

            Console.WriteLine("\nList of objects:");
            foreach (var obj in objects)
            {
                Console.WriteLine(obj);
                Console.WriteLine();
            }
        }

        static void CleanupObjects()
        {
            objects.Clear();
        }
    }
}