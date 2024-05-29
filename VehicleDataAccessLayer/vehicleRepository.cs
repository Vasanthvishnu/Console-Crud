using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace VehicleDataAccessLayer
{
   internal class vehicleRepository
    {
        string connectionstring = " Data Source = DESKTOP-1U0BM0H\\SQLEXPRESS;Initial Catalog = BATCH8 VASANTH;User Id = sa; Password=Anaiyaan@123;";
        SqlConnection DAL;
        VehicleModel Vehicle = new VehicleModel();
        public vehicleRepository()
        {
            DAL = new SqlConnection(connectionstring);
        }
        public void Insert(VehicleModel Vehicle)
        {
            try
            {

                var Insertsql = ($"exec InsertVehicle'{Vehicle.Name}','{Vehicle.VehicleNumber}','{Vehicle.OwnerName}','{Vehicle.DriverName}',{Vehicle.ContactNumber}");
                DAL.Open();
                DAL.Execute(Insertsql);
                DAL.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Update( VehicleModel vehicle)
        {
            try
            {
                var update = ($"exec UpdateVehicle'{vehicle.DriverName}',{vehicle.ContactNumber},'{vehicle.VehicleNumber}'");
                DAL.Open();
                DAL.Execute(update);
                DAL.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<VehicleModel> ShowAll()
        {
            IEnumerable<VehicleModel> result = Enumerable.Empty<VehicleModel>();
            try
            {
                var query = ($"exec  ShowAll");
                DAL.Open();
                result = DAL.Query<VehicleModel>(query);

            }
            catch
            {
                throw;
            }
            finally
            {
                DAL.Close();
            }
            return result;
        }
        public void Remove(VehicleModel vehicle)
        {
            try
            {
                if (vehicle.VehicleNumber!= null && vehicle.VehicleNumber.Length != 0)
                {
                    var Remove = ($" exec RemoveVehicle'{vehicle.VehicleNumber}'");
                    DAL.Open();
                    DAL.Execute(Remove);
                    DAL.Close();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        public IEnumerable<VehicleModel> getbyid(int id)
        {
            IEnumerable<VehicleModel> result;
            try
            {
                var view = ($"select *from Vehicle where Id={id}");
                DAL.Open();
                var name = DAL.Query<VehicleModel>(view);
                DAL.Close();
                return name;


            }
            catch
            {
                throw;
            }
            finally
            {
                DAL.Close();
            }
            return result;
        }
    }
}
