using AspNetCoreTemplate.EntityFrameworkCore.EntityFrameworkCore.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.EntityFrameworkCore.EntityFrameworkCore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreTemplateEntityFrameworkCore(
            this IServiceCollection services)
        {
            services.AddScoped<AuditingSaveChangesInterceptor>();

            return services;
        }
    }
}
