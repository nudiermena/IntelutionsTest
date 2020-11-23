using Intelutions.Permisos.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Repositories
{
    public class PermissionRepository : IPermissionsRepository
    {
        private static DataContext _dataContext;

        public PermissionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<int> Delete(int id)
        {
            var p = _dataContext.Permissions.Find(id);
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }

            _dataContext.Remove(p);
            await _dataContext.SaveChangesAsync();
            return p.PermissionId;

        }

        public async Task Edit(Permission permission)
        {
            if (permission is null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            if (permission.PermissionType != null && permission.PermissionType.PermissionTypeId != 0)
            {
                _dataContext.Attach(permission);
            }

            _dataContext.Update(permission);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Permission> GetById(int id)
        {
            var permission = await _dataContext.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id);
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            return permission;
        }


        public async Task<List<Permission>> Get()
        {
            return await _dataContext.Permissions.Include(p => p.PermissionType).ToListAsync();
        }


        public async Task<int> Create(Permission permission)
        {
            if (permission is null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            if (permission.PermissionType != null && permission.PermissionType.PermissionTypeId != 0)
            {
                _dataContext.Attach(permission);
            }

      

            _dataContext.Add(permission);
            await _dataContext.SaveChangesAsync();

            return permission.PermissionId;
        }


    }
}
