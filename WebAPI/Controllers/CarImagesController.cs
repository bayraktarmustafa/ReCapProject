using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Add(CarImages carImages)
        {
            if (carImages.ImagePath != null)
            {
                var extension = Path.GetExtension(carImages.ImagePath.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"WebAPI/Images/",newimagename);
                var stream = new FileStream(location, FileMode.Create);

                carImages.ImagePath.CopyTo(stream);

                var result = _carImagesService.Add(carImages);

                if (result.Success == true)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
        }
    }
}


