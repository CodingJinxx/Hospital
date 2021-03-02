using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hospital.Models
{
    public class HospitalContextFactory : IDesignTimeDbContextFactory<HospitalContext>
    {
        public HospitalContext CreateDbContext(string[] args)
        {
            var properties = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsbuilder = new DbContextOptionsBuilder<HospitalContext>();

            optionsbuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseMySql(properties["ConnectionStrings:DefaultConnection"], ServerVersion.FromString("8.0.23"), null);
            
            return new HospitalContext(optionsbuilder.Options);
        }
    }
}