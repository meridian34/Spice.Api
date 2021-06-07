using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Services
{
    public class SpiceService
    {
        private readonly List<Models.Spice> _spices;
        public SpiceService()
        {
            _spices = new List<Models.Spice>();
        }
    }
}
