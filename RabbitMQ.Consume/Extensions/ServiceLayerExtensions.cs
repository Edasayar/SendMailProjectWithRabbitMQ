
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Consume.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Consume.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            
            services.AddScoped<RabbitMQHelper>();
            services.AddScoped<IDataModel<User>, DataModel>();

            return services;
        }
    }
}
