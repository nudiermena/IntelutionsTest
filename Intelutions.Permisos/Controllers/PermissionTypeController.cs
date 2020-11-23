using Intelutions.Permisos.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeController(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _permissionTypeRepository.Get();
            return Ok(data);
        }
    }
}