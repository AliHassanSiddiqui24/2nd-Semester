using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    internal class Program
    {
        private static List<Ship> ships = new List<Ship>();

        static void Main(string[] args)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\nOcean Navigation System");
                    Console.WriteLine("1. Add Ship");
                    Console.WriteLine("2. View Ship Position");
                    Console.WriteLine("3. View Ship Serial Number");
                    Console.WriteLine("4. Change Ship Position");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter choice: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            AddShip();
                            break;
                        case "2":
                            ViewPosition();
                            break;
                        case "3":
                            ViewSerialNumber();
                            break;
                        case "4":
                            ChangePosition();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }

            static void AddShip()
            {
                Console.Write("Enter Ship Number: ");
                string serial = Console.ReadLine();

                Console.WriteLine("Enter Ship Latitude:");
                Angle latitude = GetAngleInput(isLatitude: true);

                Console.WriteLine("Enter Ship Longitude:");
                Angle longitude = GetAngleInput(isLatitude: false);

                ships.Add(new Ship(serial, latitude, longitude));
                Console.WriteLine("Ship added successfully!");
            }

            static Angle GetAngleInput(bool isLatitude)
            {
                Console.Write("Enter Degree: ");
                int deg = int.Parse(Console.ReadLine());

                Console.Write("Enter Minute: ");
                float min = float.Parse(Console.ReadLine());

                Console.Write($"Enter Direction ({(isLatitude ? "N/S" : "E/W")}): ");
                char dir = char.ToUpper(Console.ReadLine()[0]);

                // Simple validation
                if (isLatitude && (dir != 'N' && dir != 'S') || !isLatitude && (dir != 'E' && dir != 'W'))
                    throw new ArgumentException("Invalid direction!");

                return new Angle(deg, min, dir);
            }

            static void ViewPosition()
            {
                Console.Write("Enter Ship Serial Number: ");
                string serial = Console.ReadLine();

                Ship ship = ships.Find(s => s.SerialNumber == serial);
                if (ship != null) ship.PrintPosition();
                else Console.WriteLine("Ship not found!");
            }

            static void ViewSerialNumber()
            {
                Console.Write("Enter Latitude (e.g., 149°34.8' W): ");
                string latString = Console.ReadLine();

                Console.Write("Enter Longitude (e.g., 17°31.5' S): ");
                string lonString = Console.ReadLine();

                foreach (Ship ship in ships)
                {
                    if (ship.Latitude.ToString() == latString && ship.Longitude.ToString() == lonString)
                    {
                        ship.PrintSerialNumber();
                        return;
                    }
                }
                Console.WriteLine("Ship not found!");
            }

            static void ChangePosition()
            {
                Console.Write("Enter Ship Serial Number: ");
                string serial = Console.ReadLine();

                Ship ship = ships.Find(s => s.SerialNumber == serial);
                if (ship == null)
                {
                    Console.WriteLine("Ship not found!");
                    return;
                }

                Console.WriteLine("Enter new Latitude:");
                ship.Latitude = GetAngleInput(isLatitude: true);

                Console.WriteLine("Enter new Longitude:");
                ship.Longitude = GetAngleInput(isLatitude: false);

                Console.WriteLine("Position updated successfully!");
            }
        }
    }
   