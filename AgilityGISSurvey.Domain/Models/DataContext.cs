using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AgilityGISSurvey.Domain.Models
{
    public partial class DataContext : DbContext 
    {
        private readonly string _connectionString;

        public DataContext()
        {

        }
        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && false == string.IsNullOrEmpty(_connectionString)) // if no default binding
            {
                optionsBuilder.UseSqlServer(_connectionString); //Use provider as SQL server and make connection through connection string.
            }
            base.OnConfiguring(optionsBuilder); //configure connection
        }

    }
}
