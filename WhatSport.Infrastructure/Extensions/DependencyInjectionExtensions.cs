using Microsoft.Extensions.DependencyInjection;
using WhatSport.Domain.Repositories;
using WhatSport.Infrastructure.Repositories;

namespace WhatSport.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ILevelRepository, LevelRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMatchRepository, MatchRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IScoreRepository, ScoreRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();

            return services;
        }
    }
}
