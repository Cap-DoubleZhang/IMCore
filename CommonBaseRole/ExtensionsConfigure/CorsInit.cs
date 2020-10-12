using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonBaseRole.ExtensionsConfigure
{
    public static class CorsInit
    {
        /// <summary>
        /// 注入跨域
        /// </summary>
        /// <param name="services"></param>
        /// <param name="policyDefaultValue"></param>
        public static void AddCorsStartUp(this IServiceCollection services, string policyDefaultValue)
        {

            services.AddCors(op =>
            {
                op.AddPolicy(policyDefaultValue, x =>
                {
                    x.AllowAnyOrigin();
                    x.AllowAnyMethod();
                    x.AllowAnyHeader();
                });
            });
        }
    }
}
