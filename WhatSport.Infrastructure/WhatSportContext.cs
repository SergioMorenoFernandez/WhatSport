using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WhatSport.Domain;
using WhatSport.Domain.Models;
using WhatSport.Infrastructure.EntityConfigurations;
using WhatSport.Infrastructure.Seed;

namespace WhatSport.Infrastructure
{
    public class WhatSportContext : DbContext, IUnitOfWork
    {
        public WhatSportContext(DbContextOptions<WhatSportContext> options)
           : base(options)
        {
        }

        public DbSet<City> Cities => Set<City>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Equipment> Equipments => Set<Equipment>();
        public DbSet<Level> Levels => Set<Level>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Score> Scores => Set<Score>();
        public DbSet<ScoreConfirmation> ScoreConfirmations => Set<ScoreConfirmation>();
        public DbSet<Sport> Sports => Set<Sport>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClubEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClubSportEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FriendEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LevelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MatchEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfirmationEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SportEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            // Data seed
            CountrySeeder.Seed(modelBuilder);
            CitySeeder.Seed(modelBuilder);
            UserSeeder.Seed(modelBuilder);
            SportSeeder.Seed(modelBuilder);
            MatchSeeder.Seed(modelBuilder);
            PlayerSeeder.Seed(modelBuilder);
            ScoreSeeder.Seed(modelBuilder);
            ScoreConfirmationSeeder.Seed(modelBuilder);
        }

        async Task<bool> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
