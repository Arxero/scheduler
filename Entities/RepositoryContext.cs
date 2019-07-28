using Entities.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 UserId = 1,
                 Username = "Maverick",
                 FirstName = "Maverick",
                 LastName = "Cloud",
                 PhoneNumber = "088-61-62-835",
                 Email = "feruchio599@gmail.com",
                 CreatedAt = new DateTime(2019, 07, 25),
                 UpdatedAt = new DateTime(2019, 07, 25),
                 Gender = "Male",
             },
            new User
            {
                UserId = 2,
                Username = "Saad",
                FirstName = "Saad",
                LastName = "Salim",
                PhoneNumber = "999-888-7777",
                Email = "saad@gmail.com",
                CreatedAt = new DateTime(2019, 07, 25),
                UpdatedAt = new DateTime(2019, 07, 25),
                Gender = "Male",
            },
            new User
            {
                UserId = 3,
                Username = "Xinored",
                FirstName = "Xinored",
                LastName = "Deronix",
                PhoneNumber = "939-858-7977",
                Email = "xinoredm@gmail.com",
                CreatedAt = new DateTime(2019, 07, 25),
                UpdatedAt = new DateTime(2019, 07, 25),
                Gender = "Male",
            },
            new User
            {
                UserId = 4,
                Username = "Badboy",
                FirstName = "Badboy",
                LastName = "Boy",
                PhoneNumber = "989-158-7877",
                Email = "badboy@gmail.com",
                CreatedAt = new DateTime(2019, 07, 25),
                UpdatedAt = new DateTime(2019, 07, 25),
                Gender = "Male",
            },
            new User
            {
                UserId = 5,
                Username = "Mr.Roller",
                FirstName = "Roller",
                LastName = "Rolls",
                PhoneNumber = "039-855-7927",
                Email = "roller@gmail.com",
                CreatedAt = new DateTime(2019, 07, 25),
                UpdatedAt = new DateTime(2019, 07, 25),
                Gender = "Male",
            });
        }
    }
}
