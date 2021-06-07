using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Models
{
    public class Spice
    {
        public int SpiceID { get; set; }        
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }        
        public Unit WeightUnit { get; set; }
        public decimal Price { get; set; }        
        public Unit PriceUnit { get; set; }
        public List<SpiceCharacteristic> SpiceCharacteristics { get; set; }
        public List<GroupCharacteristic>  GroupCharacteristics { get; set; }


        //public List<SpiceCharacteristic> NutritionalValues { get; set; }
        //public List<SpiceCharacteristic> Vitamins { get; set; }
        //public List<SpiceCharacteristic> Minerals { get; set; }

        //public int GroupID { get; set; }
        //public int WeightUnitId { get; set; }
        //public int PriceUnitId { get; set; }
    }
}
