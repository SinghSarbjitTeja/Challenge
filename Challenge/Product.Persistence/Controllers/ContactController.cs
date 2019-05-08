using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Product.Persistence.Domain.Contracts;
using Product.Persistence.Models;
using Product.Persistence.Repository;

namespace Product.Persistence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var contact = await _contactService.GetByIdAsync(id);
                return new OkObjectResult(contact);
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Message = "Error while Getting Contact", e });
            }
        }

        ///  EndPoint- GET: api/Contact
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var contacts = _contactService.GetContactList();
                return new OkObjectResult(contacts);
            }
            catch (Exception e)
            {

                return Json(new { Success = false, Message = "Error while getting the list", e });
            }
        }


        // POST: api/Contact     
        [HttpPost]
        public IActionResult Post([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Parameter can not be null" });
            }
            var result = _contactService.AddNewContact(contact);
            if (result)
            {
                return Json(new { Success = true, Message = "New Contact added succesfullly" });
            }
            else
            {
                return Json(new { Success = false, Message = "Error while adding new language" });
            }
        }



        //  PUT: api/Contact/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContactDTO contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Parameter can not be null" });
            }
            if (contact != null)
            {
                var res = await _contactService.UpdateContact(contact);
                if (res)
                {
                    return new OkObjectResult(new { Message = "updated successfully" });
                }
            }
            return new NoContentResult();
        }

        //DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _contactService.DeleteContact(id);
                if (res)
                {
                    return new OkObjectResult(new { Message = "Deleted Contact successfully" });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Could not delete" });
            }
            return new NoContentResult();
        }
    }
}