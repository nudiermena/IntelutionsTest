using Intelutions.Permisos.Models.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Repositories.Interface
{
    public interface IPermissionTypeRepository
    {
        Task<List<PermissionType>> Get();
    }
}
