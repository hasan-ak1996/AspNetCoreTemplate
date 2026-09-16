using AspNetCoreTemplate.Domain.Authorization.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTemplate.EntityFrameworkCore.EntityFrameworkCore
{
    public class AspNetCoreTemplateDbContext(DbContextOptions<AspNetCoreTemplateDbContext> options) : 
        IdentityDbContext<ApplicationUser>(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AspNetCoreTemplateDbContext).Assembly);
        }
    }
}
