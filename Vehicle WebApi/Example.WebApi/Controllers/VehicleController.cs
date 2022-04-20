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
using Example.Model;
using Vehicle.Service;
using Example.Service.Common;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace Example.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        public async Task<HttpResponseMessage> GetPageAsync()
        {
            VehicleService vehicleService = new VehicleService();
           
            if (vehicleService.GetPageAsync() == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                List<RESTVehicle> vehiclesREST = new List<RESTVehicle>();
                foreach (VehicleModel vehicle in await vehicleService.GetPageAsync())
                {
                    RESTVehicle vehicleREST = new RESTVehicle()
                    {
                        ID = vehicle.ID,
                        CarBrand = vehicle.CarBrand,
                        CarModel = vehicle.CarModel,
                        Usage = vehicle.Usage,
                        ProductionYear = vehicle.ProductionYear
                    };
                    vehiclesREST.Add(vehicleREST);
                }
                return Request.CreateResponse(HttpStatusCode.OK, vehiclesREST );
            }
        }

        public async Task<HttpResponseMessage> GetIdAsync(int id)
        {
            VehicleService vehicleService =new VehicleService();

            if (await vehicleService.GetVehicleByIdAsync(id)==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                RESTVehicle vehicleREST = new RESTVehicle
                {
                    CarBrand = (await vehicleService.GetVehicleByIdAsync(id)).CarBrand,
                    ID = (await vehicleService.GetVehicleByIdAsync(id)).ID,
                    CarModel = (await vehicleService.GetVehicleByIdAsync(id)).CarModel,
                    Usage = (await vehicleService.GetVehicleByIdAsync(id)).Usage,
                    ProductionYear = (await vehicleService.GetVehicleByIdAsync(id)).ProductionYear

                };
                return Request.CreateResponse(HttpStatusCode.OK, vehicleREST);
            }
        }
        
        public async Task<HttpResponseMessage> PostColumnAsync([FromBody] RESTVehicle vehicleREST)
        {
            VehicleService vehicleService = new VehicleService();
            VehicleModel vehicle = new VehicleModel()
            {
                CarBrand = vehicleREST.CarBrand,
                CarModel = vehicleREST.CarModel,
                ID = vehicleREST.ID,
                Usage = vehicleREST.Usage,
                ProductionYear = vehicleREST.ProductionYear
            };
            await vehicleService.PostColumnAsync(vehicle);
            return Request.CreateResponse(HttpStatusCode.OK, "Vehicle added");
        }

        public async Task<HttpResponseMessage> UpdateVehicleAsync(int id, [FromBody] RESTVehicle vehicleREST)
        {
            VehicleService vehicleService = new VehicleService();

            if (await vehicleService.GetVehicleByIdAsync(id)==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                VehicleModel vehicle = new VehicleModel
                {
                    CarBrand = vehicleREST.CarBrand,
                    CarModel = vehicleREST.CarModel,
                    ID = vehicleREST.ID,
                    Usage = vehicleREST.Usage,
                    ProductionYear = vehicleREST.ProductionYear

                };

                await vehicleService.UpdateVehicleAsync(id, vehicle);

                return Request.CreateResponse(HttpStatusCode.OK, "Vehicle updated");
            }
            

            
        }
        public async Task<HttpResponseMessage> DeleteVehicleAsync(int id)
        {
            VehicleService vehicleService = new VehicleService();

            if (await vehicleService.GetVehicleByIdAsync(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Vehicle not found.");
            }
            else
            {
                await vehicleService.DeleteByIdAsync(id);

                return Request.CreateResponse(HttpStatusCode.OK, $"Vehicle '{id}'; deleted");
            }
        }


    }
}
      
            

    
