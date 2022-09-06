using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace backend.Models
{
    public class NovelPlansContext : DbContext
    {
        public NovelPlansContext(DbContextOptions<NovelPlansContext> options)
            : base(options)
        {
        }

        public DbSet<NovelPlan> NovelPlans { get; set; } = null!;
    }
}