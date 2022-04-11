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

        public async Task<List<VehicleModel>> GetPageAsync()
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            return await  vehicleRepository.GetPageAsync();
        }

        public async Task<VehicleModel> GetVehicleByIdAsync(int id)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            return await vehicleRepository.GetVehicleByIdAsync(id);
        }


        public async Task PostColumnAsync(VehicleModel vehicle)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            await vehicleRepository.PostColumnAsync(vehicle);
        }

        public async Task UpdateVehicleAsync(int id, VehicleModel vehicle)
        {
            VehicleRepository vehicleRepository=new VehicleRepository();
            await vehicleRepository.UpdateVehicleAsync(id, vehicle);
        }
        public async Task DeleteByIdAsync(int Id)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();
            await vehicleRepository.DeleteByIdAsync(Id);
        }
    }
}