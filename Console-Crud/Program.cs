using System;
using System.Collections.Generic;
using VehicleDataAccessLayer;

namespace Console_Crud
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehicleService verser = new VehicleService();
            verser.MenuDriven();
        }
    }
}
