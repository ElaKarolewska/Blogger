﻿using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICosmosPostService, CosmosPostService>();

            return services;
        }

    }
}
