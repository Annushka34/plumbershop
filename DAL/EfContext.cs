using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class EfContext : DbContext
    {
        public EfContext() : base()
        {
        }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"workstation id=TestForStudents.mssql.somee.com;packet size=4096;user id=annushka_SQLLogin_1;pwd=96qgb37h6y;data source=TestForStudents.mssql.somee.com;persist security info=False;initial catalog=TestForStudents");
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
//}
