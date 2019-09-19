using EDI.In.Poller.Messages.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EDI.In.Poller.Repositories
{
    public sealed class DBHelper : DbContext, IDisposable
    {
        private readonly string _connectionString;
        public DBHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Order> Orders { get; set; }
    }
}
