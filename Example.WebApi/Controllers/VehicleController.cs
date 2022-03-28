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

namespace Example.WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        public HttpResponseMessage GetPage()
        {
            VehicleService vehicleService = new VehicleService();
            List<VehicleModel> vehicles = new List<VehicleModel>();
            vehicles = vehicleService.GetPage();
            if (vehicles == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicles );
            }
        }
        
        public HttpResponseMessage PostColumn([FromBody] VehicleModel car)
        {
            VehicleService vehicleService = new VehicleService();
            vehicleService.PostColumn(car);
            return Request.CreateResponse(HttpStatusCode.OK, "Successfully added.");
        }

        public HttpResponseMessage DeleteById(int Id)
        {
            VehicleService vehicleService =new VehicleService();
            vehicleService.DeleteById(Id);
            return Request.CreateResponse(HttpStatusCode.OK, $"Vehicle '{Id}'' was deleted");
        }


    }
}
      
            

    
