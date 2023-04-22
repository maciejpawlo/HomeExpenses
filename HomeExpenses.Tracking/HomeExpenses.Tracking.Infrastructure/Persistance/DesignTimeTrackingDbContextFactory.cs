using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Infrastructure.Persistance
{
    public class DesignTimeTrackingDbContextFactory : IDesignTimeDbContextFactory<TrackingDbContext>
    {
        public TrackingDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.db.json")
                   .Build();

            var builder = new DbContextOptionsBuilder<TrackingDbContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);
            return new TrackingDbContext(builder.Options);
        }
    }
}
