using ApartmentRental.BLL.Services.Interfaces;
using ApartmentRental.Common;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartamentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        public ApartamentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] SearchApartmentsRequest request)
        {
            return Ok(await _apartmentService.GetApartmentsAsync(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _apartmentService.GetApartmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateApartmentDto request)
        {
            var result = await _apartmentService.CreateApartmentAsync(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApartment([FromBody] UpdateApartmentDto request)
        {
            var result = await _apartmentService.UpdateApartmentAsync(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _apartmentService.DeleteApartmentAsync(id);

            return Ok(result);
        }
    }
}
