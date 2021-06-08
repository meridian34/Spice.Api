using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spice.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpiceController : ControllerBase
    {
        private readonly ILogger<SpiceController> _logger;
        private readonly ISpiceService _spiceService;

        public SpiceController(ILogger<SpiceController> logger, ISpiceService spiceService)
        {
            _logger = logger;
            _spiceService = spiceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Spice>> Get()
        {
            _logger.LogDebug($"{DateTimeOffset.UtcNow} -- Http: HttpGet -- Method: {nameof(Get)}");
            return await _spiceService.GetSpicesAsync();            
        }


        [HttpGet]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> GetByDataFromRoute([FromRoute]int id)
        {
            _logger.LogDebug($"{DateTimeOffset.UtcNow} -- Http: HttpGet -- Method: {nameof(GetByDataFromRoute)}");
            _logger.LogDebug($"Input data: Id - {id}");
            return await GetSpiceById(id);
        }

        private async Task<IActionResult> GetSpiceById(int spiceId)
        {
            var spices = await _spiceService.GetSpicesAsync();
            var spice = spices.Where((s) => s.SpiceID == spiceId).FirstOrDefault();
            if (spice != null)
            {
                return Ok(spice);
            }
            else
            {
                return BadRequest(new { ErrorMessage = "Not found spice" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSpice([FromBody] Models.Spice spice)
        {
            _logger.LogDebug($"{DateTimeOffset.UtcNow} -- Http: HttpPost -- Method: {nameof(AddSpice)}");
            
            if (spice != null &&
                spice.Name != null &&
                spice.Price != 0 &&
                spice.PriceUnit != null &&
                spice.Weight != 0 &&
                spice.WeightUnit != null)
            {
                _logger.LogDebug($"Input data: spice - {spice.Name}");
                var spices = await _spiceService.GetSpicesAsync();
                var id = -1;
                foreach(var item in spices)
                {
                    if(item.SpiceID > id)
                    {
                        id = item.SpiceID;
                    }
                }
                spice.SpiceID = ++id;
                await _spiceService.AddSpiceAsync(spice);
                return Ok();
            }
            _logger.LogDebug($"Input data: spice = null");
            return BadRequest(new { ErrorMessage = "Add not posible. Bad spice properties!" });            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpice([FromBody] Models.Spice spice)
        {
            _logger.LogDebug($"{DateTimeOffset.UtcNow} -- Http: HttpPut -- Method: {nameof(UpdateSpice)}");
            if (spice != null &&
                spice.SpiceID != 0 &&
                spice.Name != null &&
                spice.Price != 0 &&
                spice.PriceUnit != null &&
                spice.Weight != 0 &&
                spice.WeightUnit != null)
            {
                _logger.LogDebug($"Input data: spice - {spice.Name}");
                var spices = await _spiceService.GetSpicesAsync();
                var sp = spices.Where((s) => s.SpiceID == spice.SpiceID).FirstOrDefault();
                if (sp != null)
                {
                    sp.Name = spice.Name;
                    sp.Photo = spice.Photo;
                    sp.Price = spice.Price;
                    sp.PriceUnit = spice.PriceUnit;
                    sp.Weight = spice.Weight;
                    sp.WeightUnit = spice.WeightUnit;
                    sp.Description = spice.Description;
                    return Ok();
                }
                else
                {
                    return BadRequest(new { ErrorMessage = "Not found spice for update" });
                }
            }
            _logger.LogDebug($"Input data: spice = null");
            return BadRequest(new { ErrorMessage = "Add not posible. Bad spice properties!" });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteSpice([FromBody] Models.Spice spice)
        {
            _logger.LogDebug($"{DateTimeOffset.UtcNow} -- Http: HttpPut -- Method: {nameof(UpdateSpice)}");
            if (spice != null &&
                spice.SpiceID != 0 )
            {
                await DeleteSpiceById(spice.SpiceID);
            }
            return BadRequest(new { ErrorMessage = "Add not posible. Bad spice properties!" });
        }

        private async Task<IActionResult> DeleteSpiceById(int id)
        {
            var spices = await _spiceService.GetSpicesAsync();
            var spice = spices.Where((s) => s.SpiceID == id).FirstOrDefault();
            if (spice != null)
            {
                _logger.LogDebug($"Delete data where: spiceId - {spice.SpiceID}");
                await _spiceService.DeleteSpiceAsync(id);
                return Ok(spice);
            }
            else
            {
                _logger.LogDebug($"Delete data: Not found spice for delete");
                return BadRequest(new { ErrorMessage = "Not found spice for delete" });
            }
        }


    }
}
