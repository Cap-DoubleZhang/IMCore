using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Common;
using Autofac;
using System.IO;
using System.Reflection;
using Autofac.Extras.DynamicProxy;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Common.RedisHelper;
using CommonBaseRole.ExtensionsConfigure;
using IServices.BaseRole;
using Model.EntityModel.BaseRole;

namespace CommonBaseRole
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string _PolicyDefaultValue = "IMCore";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //ע�� Redis ����
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();

            #region ����
            services.AddCorsStartUp(_PolicyDefaultValue);
            #endregion

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,//�Ƿ���֤��Կ
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.SecurityKey)),

                        ValidateIssuer = true,//�Ƿ���֤������
                        ValidIssuer = Consts.Issuer,

                        ValidateAudience = true,//�Ƿ���֤������
                        ValidAudience = Consts.Audience,

                        ValidateLifetime = true,//�Ƿ���֤����ʱ��
                        ClockSkew = TimeSpan.Zero,

                    };
                });

            #region Swagger
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "CommonBaseRole API",
                    Description = "��Ŀ�ӿ�˵����",
                    Contact = new OpenApiContact { },
                    License = new OpenApiLicense { },
                });
                c.OrderActionsBy(o => o.RelativePath);

                var xmlPath = Path.Combine(basePath, "CommonBaseRole.xml");
                c.IncludeXmlComments(xmlPath, true);//Ĭ�ϵڶ�������ΪFalse�������controller��ע��
            });
            #endregion
        }

        #region Autofac
        /// <summary>
        /// ʹ��Autofacע������
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //ֱ��ע��ĳһ����ͽӿ�
            //��ߵ���ʵ���࣬�ұߵ�AS�ǽӿ�
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            //builder.RegisterType<WebSiteServices>().As<IWebSiteServices>();


            //ע��Ҫͨ�����䴴�������
            var serviceDllFile = Path.Combine(basePath, "Services.dll");
            var assemblysServices = Assembly.LoadFile(serviceDllFile);

            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors();

            var repositoryDllFile = Path.Combine(basePath, "Repository.dll");
            var assemblysRepository = Assembly.LoadFile(repositoryDllFile);

            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //#region Swagger
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                //{
                //    c.SwaggerEndpoint($"/swagger/v1/swagger.json", ".NET Core 3.1 V1");
                //});
                //#endregion
                app.UseDeveloperExceptionPage();
            }

            //#region Swagger
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint($"/swagger/v1/swagger.json", ".NET Core 3.1 V1");
            //});
            //#endregion

            #region Cors
            app.UseCors(_PolicyDefaultValue);
            #endregion

            app.UseStatusCodePages();//�Ѵ����뷵�ص�ǰ̨

            app.UseRouting();

            app.UseAuthentication();//������֤�м��

            app.UseAuthorization();

            ImHelper.Initialization(new ImClientOptions
            {
                Redis = new CSRedis.CSRedisClient("62.234.194.83,poolsize=5"),
                Servers = new[] { CommonHelper.app(new string[] { "IMCore", "Servers" }),
        }
            });

            ImHelper.EventBus(
                async t =>
                {
                    SystemUser systemUser = await app.ApplicationServices.GetService<ISystemUserService>().GetSystemUserByID(t.clientId.ToString());
                    systemUser.IsOnline = 1;
                    systemUser.LastLoginIP = "";
                    systemUser.LastLoginTime = DateTime.Now;
                    systemUser.LoginTimes += 1;
                    await app.ApplicationServices.GetService<ISystemUserService>().SaveEntityInfo(systemUser);
                    Console.WriteLine(t.clientId + "������");


                },
                async t =>
                {
                    SystemUser systemUser = await app.ApplicationServices.GetService<ISystemUserService>().GetSystemUserByID(t.clientId.ToString());
                    systemUser.IsOnline = 0;
                    await app.ApplicationServices.GetService<ISystemUserService>().SaveEntityInfo(systemUser);
                    Console.WriteLine(t.clientId + "������");
                });

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
