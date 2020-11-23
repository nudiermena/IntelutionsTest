using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Intelutions.Permisos.Models.Contexts
{
    public class SeedData
    {
        public static void Initialize(DataContext context)
        {
            context.Database.Migrate();
            if (context.PermissionTypes.Count() == 0)
            {
                context.PermissionTypes.AddRange(new PermissionType { Description = "Enfermedad" }, new PermissionType { Description = "diligencias" }, new PermissionType { Description = "otros" });
            }

            context.SaveChanges();
        }
    }
}
