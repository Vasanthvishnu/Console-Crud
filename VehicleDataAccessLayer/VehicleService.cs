using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDataAccessLayer
{
    public class VehicleService
    {
        VehicleModel Vehicle = new VehicleModel();
        vehicleRepository rep = new vehicleRepository();

        public void MenuDriven()
        {
            int option=0;
            do
            {
                Console.WriteLine("Choose The Below Option");
                Console.WriteLine("1.Insert New Vehicle");
                Console.WriteLine("2.Change Vehicle Details");
                Console.WriteLine("3.Remove Vehicle");
                Console.WriteLine("4.Show All");

                option = int.Parse(Console.ReadLine());
                if(option<=5)
                {
                    Console.WriteLine("Exit OPtion");
                    return;
                }
                switch(option)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        REmove();
                        break;
                    case 4:
                        ShowAll();
                        break;
                }

            }
            while (option != 6);
        }
        public void Insert()
        {
            try
            {
                Console.WriteLine("Enter Your Vehicle Name");
                Vehicle.Name = Console.ReadLine();
                Console.WriteLine("Enter Your Vehicle NUmber");
                Vehicle.VehicleNumber = Console.ReadLine();
                Console.WriteLine("Enter Your Owner Name");
                Vehicle.OwnerName = Console.ReadLine();
                Console.WriteLine("Enter Your Driver Name");
                Vehicle.DriverName = Console.ReadLine();
                Console.WriteLine("Enter Contact Number");
                Vehicle.ContactNumber = Console.ReadLine();
            }
        }
    }
}
