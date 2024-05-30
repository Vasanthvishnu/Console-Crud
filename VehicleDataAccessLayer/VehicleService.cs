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
                if(option>=5)
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
                        Remove();
                        break;
                    case 4:
                        ShowAll();
                        break;
                }

            }
            while (option != 5);
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
                Vehicle.ContactNumber =Convert.ToInt64 (Console.ReadLine());
                rep.Insert(Vehicle);
            }catch(Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
        public void Update()
        {
            try
            {
                Console.WriteLine("Enter The Vehicle Number");
                Vehicle.VehicleNumber = Console.ReadLine();
                Console.WriteLine("Enter The Driver Name To Update");
                Vehicle.DriverName = Console.ReadLine();
                Console.WriteLine("Enter The ContactNumber To Update");
                Vehicle.ContactNumber =Convert.ToInt64( Console.ReadLine());
                rep.Update(Vehicle);
            }catch(Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
        public void Remove()
        {
            try
            {
                Console.WriteLine("Enter Vehicle Number To Remove Vehicle Details");
                Vehicle.VehicleNumber = Console.ReadLine();
                rep.Remove(Vehicle);
            }catch(Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
        public void ShowAll()
        {
            try
            {
                var ShowAllresult = rep.ShowAll();
                if (ShowAllresult == null || ShowAllresult.Count() == 0)
                {
                    Console.WriteLine("No Records");
                }
                else
                {
                    Console.WriteLine($"{"Id"} | {"Name"}    |{"VehicleNumber "}  |{"OwnerName"}  |{"DriverName"}  |{"ContactNumber"}");
                    foreach(var record in ShowAllresult)
                    {
                        Console.WriteLine($"{record.Id}     |{record.Name} |{record.VehicleNumber} |{record.OwnerName} |{record.DriverName} |{record.ContactNumber}");
                    }
                }
            }catch(Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
    }
}
