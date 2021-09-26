using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        /// <summary>
        /// Add car image
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="carImage"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(formFile, carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Delete car image
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="carImage"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.DeleteCarImage(formFile, carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Update car image
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="carImage"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(formFile, carImage);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Get car images
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpPost("get")]
        public IActionResult Get(int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
