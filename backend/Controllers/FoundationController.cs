using Microsoft.AspNetCore.Mvc;

using foundation.Models;
using foundation.Repositories;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoundationController : ControllerBase
    {
        private readonly IFoundationRepository repository;

        public FoundationController(IFoundationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var foundations = await this.repository.getFoundations();
            return foundations.Any()
            ? Ok(foundations)
            : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foundation = await this.repository.getFoundationById(id);
            return foundation != null
            ? Ok(foundation)
            : NotFound("Foundation Not Found!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Foundation foundation)
        {
            var foundations = await this.repository.getFoundations();
            foreach (Foundation f in foundations)
            {
                if (f.Cnpj == foundation.Cnpj)
                {
                    return BadRequest("Cnpj is already registered");
                }
            }

            this.repository.addFoundation(foundation);
            return await this.repository.saveChangesAsync()
            ? Ok("Foundation successfully saved")
            : BadRequest("Internal Error");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Foundation foundation)
        {
            var newFoundation = await this.repository.getFoundationById(id);
            if (newFoundation == null) return NotFound("Foundation Not Found!");

            newFoundation.Name = foundation.Name ?? newFoundation.Name;
            newFoundation.Cnpj = foundation.Cnpj ?? newFoundation.Cnpj;
            newFoundation.Email = foundation.Email ?? newFoundation.Email;
            newFoundation.PhoneNumber = foundation.PhoneNumber ?? newFoundation.PhoneNumber;
            newFoundation.SupportedInstitution = foundation.SupportedInstitution ?? newFoundation.SupportedInstitution;

            this.repository.updateFoundation(newFoundation);

            return await this.repository.saveChangesAsync()
            ? Ok("Foundation successfully updated")
            : BadRequest("Internal Error");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newFoundation = await this.repository.getFoundationById(id);
            if (newFoundation == null) return NotFound("Foundation Not Found!");

            this.repository.deleteFoundation(newFoundation);

            return await this.repository.saveChangesAsync()
            ? Ok("Foundation successfully deleted")
            : BadRequest("Internal Error");
        }
    }
}