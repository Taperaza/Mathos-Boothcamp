using System.Collections.Generic;
using System.Net.Http;
using System.Data.SqlClient;
using Example.Model;
using System.Net;
using Example.Repository.Common;
using System.Data;
using System.Threading.Tasks;

namespace ExampleRepository
{

    public class VehicleRepository : IVehicleRepository
    {
        
        static string connectionString = @"Data Source=DESKTOP-LMLVJ79\SQLEXPRESS;Initial Catalog = ExampleSQL;Integrated Security = True";

        public async Task<List<VehicleModel>> GetPageAsync()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Vehicle;", connection);
                await connection.OpenAsync();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    List<VehicleModel> result = new List<VehicleModel>();
                    while (await reader.ReadAsync())
                    {
                        var vehicle = new VehicleModel();
                        vehicle.CarBrand = reader.GetString(1);
                        vehicle.CarModel = reader.GetString(2);
                        vehicle.ID = reader.GetInt32(0);
                        vehicle.ProductionYear = reader.GetInt32(3);
                        vehicle.Usage = reader.GetString(4);
                        result.Add(vehicle);



                    }
                    connection.Close();
                    reader.Close();
                    return result;
                }
                else
                {
                    return null;
                }

            }

        }


        public async Task<VehicleModel> GetVehicleByIdAsync(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Vehicle WHERE ID = '{id}';", connection);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    VehicleModel vehicle = new VehicleModel
                    {
                        CarBrand = reader.GetString(1),
                        CarModel = reader.GetString(2),
                        ID = reader.GetInt32(0),
                        ProductionYear = reader.GetInt32(3),
                        Usage = reader.GetString(4)
                    };
                    reader.Close();
                    return vehicle;

                }
                else
                {
                    reader.Close();
                    return null;
                }


            }
        }








        public async Task PostColumnAsync(VehicleModel vehicle)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string newColumn = $"INSERT into Vehicle(ID, CarBrand, CarModel, ProductionYear, Usage) VALUES" +
                    $"('{vehicle.ID}'," +
                    $"'{vehicle.CarBrand}'," +
                    $"'{vehicle.CarModel}'," +
                    $"'{vehicle.ProductionYear}'," +
                    $"'{vehicle.CarBrand}')";

            using (connection)
            {
                SqlCommand command = new SqlCommand(newColumn, connection);
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(newColumn, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }

        }

        public async Task UpdateVehicleAsync(int id, VehicleModel vehicle)
        {
            if (await this.GetVehicleByIdAsync(id) == null)
            {
                return;
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string updateColumn = $"UPDATE Vehicle SET CarBrand = '{vehicle.CarBrand}',ID = '{vehicle.ID}'," +
                    $"CarModel = '{vehicle.CarModel}', Usage = '{vehicle.Usage}', ProductionYear = '{vehicle.ProductionYear}'";

                using(connection)
                {
                    SqlCommand command = new SqlCommand(updateColumn, connection);
                    await connection.OpenAsync();
                    SqlDataAdapter adapter = new SqlDataAdapter(updateColumn, connection);

                    await command.ExecuteNonQueryAsync();
                    connection.Close();
                }

            }
        }
                

            

        

        

        public  async Task DeleteByIdAsync(int Id)
        {
            if (await this.GetVehicleByIdAsync(Id)==null)
            {
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            string deleteColumn = $"DELETE FROM Vehicle WHERE ID = '{Id}';";

            using(connection)
            {
                SqlCommand command = new SqlCommand(deleteColumn, connection);
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(deleteColumn, connection);

                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
        }











    }
}
