using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicMarketETicaret.Models.DbModels;

namespace MusicMarketETicaret.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //entityleri ekliyoruz.
        public DbSet<Category> Category { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }

    }
}
