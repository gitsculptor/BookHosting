
using BookHosting.Application.Common.Interfaces.Authentication;
using BookHosting.Application.Common.Interfaces.Persistence;
using BookHosting.Application.Common.Interfaces.Services;
using BookHosting.Infrastructure.Authentication;
using BookHosting.Infrastructure.Persistence;
using BookHosting.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHosting.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<IUserRepository, userRepository>();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;

        }
    }
}
