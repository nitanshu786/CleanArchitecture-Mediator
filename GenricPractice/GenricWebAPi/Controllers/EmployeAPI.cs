using Domain.Entity;
using InfraStructure.Data.DependencyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenricWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeAPI : ControllerBase
    {
        private readonly IUnitService _Service;

        public EmployeAPI(IUnitService service)
        {
            _Service = service;
        }

        [HttpPost]
        public IActionResult Get(Employe employe)
        {
            _Service.employee.Add(employe);
            return Ok( employe);
        }
    }
}
