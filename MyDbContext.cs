using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAbsolut.Model;

namespace TestAbsolut
{
    internal class MyDbContext : DbContext
    {
        public static string connectionString = @"Data Source = ANASTASIA_NOTEB\SQLEXPRESS; Initial Catalog = TestAbsolut; Integrated Security = True";
        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<MyDbContext>(), connectionString).Options;
        }
        public static DbContext db = new DbContext(GetOptions());
        public DbSet<Person> Persons { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}
