using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Example.WebApi.Models;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net;
using System.Data;

namespace Example.WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        static string connectionString = @"Data Source=DESKTOP-LMLVJ79\SQLEXPRESS;Initial Catalog = ExampleSQL;Integrated Security = True";

        public List<Vehicle> vehicles = new List<Vehicle>();
        
        
        
        
        public HttpResponseMessage GetPage(int id)
        { 

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Vehicle;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
        
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var vehicle = new Vehicle();
                        vehicle.CarBrand = reader.GetString(1);
                        vehicle.CarModel = reader.GetString(2);
                        vehicle.ID = reader.GetInt32(0);
                        vehicle.ProductionYear = reader.GetInt32(3);
                        vehicle.Usage = reader.GetString(4);
                        vehicles.Add(vehicle);

                        
                    }
                    connection.Close();
                    reader.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, vehicles);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"EMPTY!");
                }




            }
            

        }

        public HttpResponseMessage PostColumn(Vehicle vehicle)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();

            using (connection)
            {
                connection.Open();
                string NewColumn = $"INSERT into Vehicle(ID, CarBrand, CarModel, ProductionYear, Usage) VALUES"+
                    $"('{vehicle.ID}',"+
                    $"'{vehicle.CarBrand}',"+
                    $"'{vehicle.CarModel}',"+
                    $"'{vehicle.ProductionYear}',"+
                    $"'{vehicle.CarBrand}')";

                adapter.InsertCommand = new SqlCommand(NewColumn, connection);
                adapter.InsertCommand.ExecuteNonQuery();

                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, vehicles);

            }

        }

      } 
            

    
}