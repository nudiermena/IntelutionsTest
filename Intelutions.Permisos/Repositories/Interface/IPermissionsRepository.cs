using Intelutions.Permisos.Models.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Repositories
{
    public interface IPermissionsRepository
    {
        Task<int> Delete(int id);

       Task<Permission> GetById(int id);

        Task<List<Permission>> Get();

        Task<int> Create(Permission permission);

        Task Edit(Permission permission);
    }
}
