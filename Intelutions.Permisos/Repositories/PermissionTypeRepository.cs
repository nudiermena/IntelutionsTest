using Intelutions.Permisos.Models.Contexts;
using Intelutions.Permisos.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Repositories
{
    public class PermissionTypeRepository: IPermissionTypeRepository
    {

        private static DataContext _dataContext;

        public PermissionTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PermissionType>> Get()
        {
            return await _dataContext.PermissionTypes.ToListAsync();
        }

    }
}
