using Microsoft.AspNetCore.Mvc;
using Phidelis.Entities.DTO;
using Phidelis.Service.Interfaces;
using System;

namespace Phidelis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrolmentController : ControllerBase
    {
        private readonly IEnrolmentService _service;

        public EnrolmentController(IEnrolmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("name={name}")]
        public IActionResult FindByName(string name)
        {
            try
            {
                return Ok(_service.FindByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Add(EnrolmentDTO obj)
        {
            try
            {
                _service.Add(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, EnrolmentDTO obj)
        {
            try
            {
                obj.Id = id;
                _service.Update(id, obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
