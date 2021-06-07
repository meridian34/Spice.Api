using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Models
{
    public class SpiceCharacteristic
    {
        public int SpiceCharacteristicId { get; set; }
        public GroupCharacteristic CharacteristicGroup { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }        
        public Unit Unit { get; set; }

        //public Spice Spice { get; set; }
        //public int CharacteristicGroupId { get; set; }
        //public int SpiceId { get; set; }
        //public int UnitId { get; set; }
    }
}
