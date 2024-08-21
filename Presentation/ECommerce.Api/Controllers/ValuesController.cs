using ECommerce.Application.Interfaces.UnitOfWorks;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public ValuesController(IUnitOfWork unitOfWork)
        {
                this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            var product = await unitOfWork.GetReadRepostory<Product>().GetAllAsync();
            return Ok(product);
        }

    }
}
