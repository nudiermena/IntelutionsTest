using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intelutions.Permisos.Models.BindingTargets
{
    public class PermisoViewModel
    {
        
        public string Name { get; set; } = string.Empty;

        
        public string LastName { get; set; } = string.Empty;

        public int PermissionType { get; set; }

        public DateTime PermissionDate { get; set; } = DateTime.Now;
    }
}
