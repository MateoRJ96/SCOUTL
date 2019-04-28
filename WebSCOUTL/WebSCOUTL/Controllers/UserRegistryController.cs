using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSCOUTL.Models;
using WebSCOUTL.Services;

namespace WebSCOUTL.Controllers
{
    [Route("api/registry")]
    [ApiController]
    public class UserRegistryController : ControllerBase
    {
        private readonly UserRegistryService service;

        public UserRegistryController(UserRegistryService service)
        {
            this.service = service;
        }

        [HttpGet("{pageSize}", Name = "GetPaggingUserRegistry")]
        public async Task<ActionResult<List<UserRegistry>>> Get(int pageSize)
        {
            return await service.GetUserRegistries(pageSize, null);
        }

        [HttpGet("{id}", Name = "GetUserRegistryById")]
        public async Task<ActionResult<UserRegistry>> Get(string id)
        {
            var result = await service.GetUserRegistryById(id);

            if(result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<UserRegistry>> Create(UserRegistry registry)
        {
            UserRegistry result = await service.CreateUserRegistry(registry);
            return CreatedAtRoute("GetUserRegistryById", 
                new { id = registry.Id.ToString() }, registry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UserRegistry registry)
        {
            var search = await service.GetUserRegistryById(id);

            if (search == null)
            {
                return NotFound();
            }

            await service.UpdateUserRegistry(id, registry);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await service.GetUserRegistryById(id);

            if(result == null)
            {
                return NotFound();
            }

            await service.DeleteUserRegistry(result.Id);

            return NoContent();
        }
    }
}