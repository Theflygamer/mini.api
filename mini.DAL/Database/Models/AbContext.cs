using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.DAL.Database.Models
{
    public class Abcontext : DbContext
    {
        public Abcontext() { }
        public Abcontext(DbContextOptions<Abcontext> options) : base(options) { }
        public DbContextOptions<Abcontext> test { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=FTF-LAPTOP;Database=torsdag; Trusted_Connection=True");
        //}
        public DbSet<Author> Author { get; set; }
        public DbSet<book> Books { get; set; }
    }
}
