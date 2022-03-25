﻿namespace Example.WebApi.Models
{
    public class Vehicle
    {
        public string CarBrand { get; set; }
        public int ID { get; set; }
        public string CarModel { get; set; }
        public int ProductionYear { get; set; }
        public string Usage { get; set; }

        public Vehicle(int id, string carbrand, string carmodel, string usage, int prodyear)
        {
            ID = id;
            CarBrand = carbrand;
            CarModel = carmodel;
            ProductionYear = prodyear;
            Usage = usage;
        }

        public Vehicle()
        {
        }
    }
}