using Microsoft.EntityFrameworkCore;
using PocInkDataLayer.Models;
using System;
using System.Security.Cryptography;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "William",
                    Email = "Shakespeare@yahoo.com",
                    Role="Admin",
                    HashedPassword=CalculateHash("12345","William")
                },
                 new User
                 {
                     Id = Guid.NewGuid(),
                     UserName = "John",
                     Email = "John@yahoo.com",
                     Role = "",
                     HashedPassword = CalculateHash("12345", "John")
                 }
            );
        }


        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
