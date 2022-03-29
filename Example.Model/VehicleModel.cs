using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model.Common;

namespace Example.Model
{
    public class VehicleModel : IVehicleModel
    {
        public string CarBrand { get; set; }
        public int ID { get; set; }
        public string CarModel { get; set; }
        public int ProductionYear { get; set; }
        public string Usage { get; set; }

        public Guid Id { get; set; }

        public VehicleModel(int id, string carbrand, string carmodel, string usage, int prodyear)
        {
            ID = id;
            CarBrand = carbrand;
            CarModel = carmodel;
            ProductionYear = prodyear;
            Usage = usage;
            
        }

        public VehicleModel()
        {
        }
    }
}
