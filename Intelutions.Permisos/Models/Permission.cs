

using System;

namespace Intelutions.Permisos.Models.Contexts
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }        
    }
}