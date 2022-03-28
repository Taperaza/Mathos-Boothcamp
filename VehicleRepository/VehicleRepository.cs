using System.Collections.Generic;
using System.Net.Http;
using System.Data.SqlClient;
using Example.Model;
using System.Net;
using Example.Repository.Common;
using System.Data;

namespace ExampleRepository
{

    public class VehicleRepository : IVehicleRepository
    {
        public List<VehicleModel> vehicles = new List<VehicleModel>();
        static string connectionString = @"Data Source=DESKTOP-LMLVJ79\SQLEXPRESS;Initial Catalog = ExampleSQL;Integrated Security = True";

        public List<VehicleModel> GetPage()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Vehicle;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    var vehicle = new VehicleModel();
                    vehicle.CarBrand = reader.GetString(1);
                    vehicle.CarModel = reader.GetString(2);
                    vehicle.ID = reader.GetInt32(0);
                    vehicle.ProductionYear = reader.GetInt32(3);
                    vehicle.Usage = reader.GetString(4);
                    vehicles.Add(vehicle);



                }
                connection.Close();
                reader.Close();


            }
            return vehicles;
        }




        public VehicleModel PostColumn(VehicleModel vehicle)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                connection.Open();
                string NewColumn = $"INSERT into Vehicle(ID, CarBrand, CarModel, ProductionYear, Usage) VALUES" +
                    $"('{vehicle.ID}'," +
                    $"'{vehicle.CarBrand}'," +
                    $"'{vehicle.CarModel}'," +
                    $"'{vehicle.ProductionYear}'," +
                    $"'{vehicle.CarBrand}')";

                adapter.InsertCommand = new SqlCommand(NewColumn, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
                return vehicle;

            }

        }

        public void DeleteById(int Id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();

                string DeleteId = $"SELECT * FROM Vehicle WHERE Id = '{Id}';";
                SqlCommand command = new SqlCommand(DeleteId, connection);
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    connection.Close();
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DeleteId = $"DELETE FROM Vehicle WHERE Id = '{Id}';";
                    adapter.InsertCommand = new SqlCommand(DeleteId, connection);
                    adapter.InsertCommand.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }











    }
}
