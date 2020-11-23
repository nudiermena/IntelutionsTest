using Intelutions.Permisos.Models.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Models.BindingTargets
{
    public class PermissionData
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
   
        public int PermissionType { get; set; }

        public DateTime PermissionDate { get; set; } = DateTime.Now;
             
        public Permission Permission => new Permission
        {   
            Name = Name,
            LastName = LastName,            
            PermissionType = PermissionType == 0 ? null : new PermissionType { PermissionTypeId = PermissionType }
        };
    }
}
