using Microsoft.EntityFrameworkCore;

namespace Otus2.Data
{
    public class OtusDbContext : DbContext
    {

        private string _connectionString;
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<ClientTraining> ClientTrainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public OtusDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

    }
}