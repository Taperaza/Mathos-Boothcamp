using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Service.Common;
using ExampleRepository;

namespace Vehicle.Service
{
    public class VehicleService : IVehicleService
    {
        
        List<VehicleModel> car = new List<VehicleModel>();

        public List<VehicleModel> GetPage()
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            return vehicleRepository.GetPage();
        }
        public void  PostColumn(VehicleModel car)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            vehicleRepository.PostColumn(car);
        }

        public void DeleteById(int Id)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            vehicleRepository.DeleteById(Id);
        }
    }
}