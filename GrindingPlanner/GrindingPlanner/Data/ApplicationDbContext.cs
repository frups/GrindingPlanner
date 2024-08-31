using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GrindingPlanner.Shared;

namespace GrindingPlanner.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<GrindingPlanner.Shared.TrainingPlan> TrainingPlan { get; set; } = default!;
        public DbSet<GrindingPlanner.Shared.WeekPlan> WeekPlan { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeekPlan>()
                .HasOne(b => b.TrainingPlan)
                .WithMany(a => a.WeekPlans)
                .HasForeignKey(b => b.TrainingPlanId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
