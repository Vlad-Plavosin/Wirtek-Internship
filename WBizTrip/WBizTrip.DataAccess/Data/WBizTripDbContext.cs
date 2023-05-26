using Microsoft.EntityFrameworkCore;
using WBizTrip.Domain.Enums;
using WBizTrip.Domain.Model;

namespace WBizTrip.API.Data
{
    public class WBizTripDbContext : DbContext
    {
        public WBizTripDbContext(DbContextOptions<WBizTripDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
            .HasOne(c => c.Client)
            .WithMany(t => t.Trips);

            modelBuilder.Entity<TripSuggestion>()
            .HasOne(t => t.Trip)
            .WithMany(ts => ts.TripSuggestions);

            //modelBuilder.Entity<Client>()
            //.HasOne(tl => tl.TeamLeader)
            //.WithMany(c => c.Clients);

            modelBuilder.Entity<User>()
            .HasOne(tl => tl.TeamLeader)
            .WithOne(u => u.User)
            .HasForeignKey<TeamLeader>(tl => tl.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasData(new Client
            {
                Id = 1,
                Name = "Universitatea Babes Bolyai",
                Address = "Hasdeu 1",
                PhoneNumber = "0711111111",
                AnnualBudget = 10000
            }, new Client
            {
                Id = 2,
                Name = "Universitatea Politehnica",
                Address = "Observatory street 1",
                PhoneNumber = "0722222222",
                AnnualBudget = 10000.99f
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Gabriel Mircea",
                Email = "mircea.gabriel@gmail.com",
                Password = "passwordmircea",
                Role = UserRole.Admin,
            }, new User
            {
                Id = 2,
                Name = "Mircea Ivan",
                Email = "ivanmircea06@gmail.ro",
                Password = "passwordivan",
                Role = UserRole.Admin,
            }, new User
            {
                Id = 3,
                Name = "Dani Moga",
                Email = "dmoga@yahoo.com",
                Password = "passwordmoga",
                Role = UserRole.HR,
            }, new User
            {
                Id = 4,
                Name = "Daniela Lupea",
                Email = "danielalupea1975@hotmail.com",
                Password = "passwordlupea",
                Role = UserRole.HR,
            });
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripSuggestion> TripSuggestions { get; set; }
    }
}
