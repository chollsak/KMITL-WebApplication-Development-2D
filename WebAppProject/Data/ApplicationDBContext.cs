using Microsoft.EntityFrameworkCore;
using WebAppProject.Models;

namespace WebAppProject.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ }
        public DbSet<Party> Partys { get; set; }
        public DbSet<UserData> UsersData { get; set; }
    }
}
