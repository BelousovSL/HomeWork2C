using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Otus2.Data
{
    public class OtusDbContext : DbContext
    {
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<ClientTraining> ClientTrainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();

            var connectionString = Configuration.GetSection("ConnectionString").Value;

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}