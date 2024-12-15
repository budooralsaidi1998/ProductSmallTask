using Microsoft.EntityFrameworkCore;
using ProductSmallTask.Models;
using System;

namespace ProductSmallTask
{
    public class ApplicationDbContexr:DbContext
    {

        public ApplicationDbContexr(DbContextOptions<ApplicationDbContexr> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<User> users { get; set; }

    }


}

