using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPhones.API.Models;
using SmartPhones.API.Repository;

namespace SmartPhones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartPhonesController : ControllerBase
    {
        ISmartPhoneRepository _smartPhoneRepository;
        public SmartPhonesController(ISmartPhoneRepository smartPhoneRepository)
        {
            _smartPhoneRepository = smartPhoneRepository;
        }
        [HttpGet]
        public IActionResult GetAllSmartPhones()
        {
            var smartphones = _smartPhoneRepository.GetAllSmartPhones();
            if (smartphones == null) return NotFound("There are No SmartPhones Currently!!");
            return Ok(smartphones);
        }

        [HttpGet("{id}")]
        public IActionResult GetSmartPhonesById(int id)
        {
            var smartphone = _smartPhoneRepository.GetSmartPhoneById(id);
            if (smartphone == null) return NotFound($"Requested SmartPhone with id = {id} is Not Found");
            return Ok(smartphone);
        }

        [HttpGet]
        [Route("GetMinAndAvgPrice")]
        public IActionResult GetMinAndAvgPrice()
        {
            string message=_smartPhoneRepository.GetMinAndAvgPrice();
            return Ok(message);
        }

        [HttpGet]
        [Route("search/{Price}")]
        public IActionResult FilterByLaunchDateAndPrice(double Price)
        {
            var filteredPhones = _smartPhoneRepository.FilterByLaunchDateAndPrice(Price);
            if (filteredPhones == null) return NotFound("The requested smart phones are not found!!");
            else return Ok(filteredPhones);
        }

        [HttpPost]
        public IActionResult AddSmartPhone([FromBody] SmartPhone smartPhone)
        {
            var isSmartphoneAdded = _smartPhoneRepository.AddSmartPhone(smartPhone);
            if (isSmartphoneAdded)
            {
                return Ok("SmartPhone added Successfully!!");
            }
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateSmartPhone(int id, [FromBody] SmartPhone smartPhone)
        {
            var updateSmartphone = _smartPhoneRepository.UpdateSmartPhone(id, smartPhone);
            if (updateSmartphone == null) return NotFound($"The requested Smart Phone is Not Found");
            return Ok(updateSmartphone);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSmartPhone(int id)
        {
            var smartPhone = _smartPhoneRepository.DeleteSmartPhone(id);
            if (smartPhone == null) return NotFound($"The requested Smart Phone is Not Found");
            return Ok("SmartPhone Deleted Successfully!!");
        }
    }
}
