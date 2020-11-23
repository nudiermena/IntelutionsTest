using Intelutions.Permisos.Models.BindingTargets;
using Intelutions.Permisos.Models.Contexts;
using Intelutions.Permisos.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionsRepository _permissionsRepository;


        public PermissionController(IPermissionsRepository permissionsRepository)
        {
            this._permissionsRepository = permissionsRepository;
        }

        [DisableCors]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _permissionsRepository.Get();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] PermisoViewModel permissionData, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pe = new Permission { Name = permissionData.Name, LastName = permissionData.LastName, PermissionTypeId = permissionData.PermissionType, PermissionDate = permissionData.PermissionDate };            
            pe.PermissionId = id;

            _permissionsRepository.Edit(pe);
            return Ok();
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> Get(int id)
        {
            var data = await _permissionsRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PermisoViewModel permissionData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (permissionData == null)
            {
                return BadRequest();
            }

            var pe = new Permission { Name = permissionData.Name, LastName = permissionData.LastName, PermissionTypeId = permissionData.PermissionType, PermissionDate = permissionData.PermissionDate };
            
            int data = await _permissionsRepository.Create(pe);
            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            if (id == 0)

                return BadRequest();

            var data = await _permissionsRepository.Delete(id);
            return Ok(data);
        }
    }
}
