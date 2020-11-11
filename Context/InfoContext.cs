using Microsoft.EntityFrameworkCore;
using StudentInfoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfoAPI.Context
{
    public class InfoContext:DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Subject> Subject { get; set; }

        public InfoContext(DbContextOptions<InfoContext> options):base(options)
        {

        }
    }
}
