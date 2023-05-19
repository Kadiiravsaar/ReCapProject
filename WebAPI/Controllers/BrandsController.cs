using Buisness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("add")]
        public IActionResult AddBrand(Brand brand)
        {
            var brandAny = _brandService.Add(brand);

            if (brandAny.Success)
            {
                return Ok(brandAny);
            }

            return BadRequest();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           var result = _brandService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
            
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _brandService.GetByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
