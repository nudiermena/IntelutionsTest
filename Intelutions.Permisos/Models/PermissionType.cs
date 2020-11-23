using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intelutions.Permisos.Models.Contexts
{
    public class PermissionType
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PermissionTypeId { get; set; }
        public string Description { get; set; }      
    }
}