﻿using Authentication.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure.DI.Installers
{
    public static class ServiceInstaller
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
