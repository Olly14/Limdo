
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Limdo.Data;
using Limdo.Data.Infrastructure.Persistences;
using Limdo.Data.Infrastructure.Persistences.AppUSerRepository;
using Limdo.Data.Infrastructure.Persistences.AppUsers;
using Limdo.Data.Infrastructure.Persistences.DropDownLists;
using Limdo.Data.Infrastructure.Repositories;
using Limdo.Data.Infrastructure.Repositories.IAppUsers;
using Limdo.Data.Infrastructure.Repositories.IDropDownLists;
using Limdo.Domain;
using Limdo.Web.Api.EntityMappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Limdo.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                // base-address of your identityserver
                options.Authority = "https://localhost:44314/";
                options.RequireHttpsMetadata = true;

                // name of the API resource
                options.ApiName = "Limdo.Web.Api";
            });


            services.AddDbContextPool<LimdoDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("LimdoDbConnectionString"), b => b.MigrationsAssembly("Limdo.Web.Api"));
            });

            services.AddDbContextPool<UserIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("UserIdentityDbConnectionString"), b => b.MigrationsAssembly("Limdo.Web.Api"));
            });


            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IUnitOfWork<AppUser>, UnitOfWorkAppUserRepo>();
            services.AddScoped<IUserRepository, UserIdentityRepository>();
            services.AddScoped<IUnitOfWork<User>, UnitOfWorkUserRepo>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IPcoLicenceDetailRepository, PcoLicenceDetailRepository>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserAutoMapperProfile());
                mc.AddProfile(new DropDownListsAutoMapperProfile());

            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
