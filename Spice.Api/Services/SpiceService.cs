using Spice.Api.Models;
using Spice.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Services
{
    public class SpiceService : ISpiceService
    {
        private readonly List<Models.Spice> _spices;
        public SpiceService()
        {
            var priceUnit = new Unit { UnitId = 0, Value = "UAH" };
            var weightUnit = new Unit { UnitId = 1, Value = "Kg" };
            _spices = new List<Models.Spice>();
            _spices.Add(new Models.Spice { Name = "Соль", Price = 12, PriceUnit = priceUnit, Weight = 1, WeightUnit = weightUnit, SpiceID = 1 });
        }

        public async Task<IReadOnlyCollection<Models.Spice>> GetSpicesAsync()
        {   
            return await Task.FromResult(_spices);
        }

        public async Task AddSpiceAsync(Models.Spice spice)
        {
            _spices.Add(spice);
            await Task.FromResult(true);
        }

        public async Task DeleteSpiceAsync(int SpiceId)
        {
            var res = _spices.Find((spice) => { return spice.SpiceID == SpiceId; });
            _spices.Remove(res);
            await Task.FromResult(true);
        }
    }
}
