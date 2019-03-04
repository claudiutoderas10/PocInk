using Microsoft.EntityFrameworkCore;
using PocInkDataLayer.Models;

namespace PocInkDataLayer
{
    public class PocInkDBContext:DbContext
    {
        public DbSet<InkDrawing> InkDrawings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PocInkDB;Trusted_Connection=True;");
        }
    }
}
