using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GrindingPlanner.Shared;

namespace GrindingPlanner.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<GrindingPlanner.Shared.TrainingPlan> TrainingPlan { get; set; } = default!;
    }
}
