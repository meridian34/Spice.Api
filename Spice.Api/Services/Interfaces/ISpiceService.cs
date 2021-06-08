using Spice.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Services.Interfaces
{
    public interface ISpiceService
    {
        Task<IReadOnlyCollection<Models.Spice>> GetSpicesAsync();

        Task AddSpiceAsync(Models.Spice spice);

        Task DeleteSpiceAsync(int SpiceId);
    }
}
