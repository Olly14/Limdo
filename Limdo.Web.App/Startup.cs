using AutoMapper;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Limdo.Web.App.ApiClients;
using Limdo.Web.App.ModelMappers.AppUsers;
using Limdo.Web.App.ModelMappers.DropDownLists;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;

namespace Limdo.Web.App
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

            services.AddControllersWithViews()
                .AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "LimdoWebAppCookies";
                options.DefaultChallengeScheme = "oidc";
            })
             .AddCookie("LimdoWebAppCookies", options =>
             {
                 options.AccessDeniedPath = "/Authentication/AccessDenied";
             })
             .AddOpenIdConnect("oidc", options =>
             {
                 options.Authority = "https://localhost:44314/";
                 options.RequireHttpsMetadata = true;
                 options.ClientId = "LimdoWebAppClientId";
                 options.Scope.Add("openid");
                 options.Scope.Add("profile");
                 options.Scope.Add("address");
                 options.Scope.Add("roles");
                 options.Scope.Add("Limdo.Web.Api");
                 //TODO: why add offline access
                 options.Scope.Add("offline_access");
                 options.ClientSecret = "secret";
                 options.ResponseType = "code id_token";
                 options.SignInScheme = "LimdoWebAppCookies";
                 options.SignOutScheme = "oidc";
                 //options.SignOutScheme = "LimdoWebAppCookies";
                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;
                 //options.CallbackPath = new PathString(".....");
                 options.SignedOutCallbackPath = new PathString();
                 options.Events = new OpenIdConnectEvents()
                 {
                     OnTokenValidated = TokenValidatedContext =>
                     {
                         var identity = TokenValidatedContext.Principal.Identity as ClaimsIdentity;

                         var subjectClaims = identity.Claims.FirstOrDefault(c => c.Type.Equals("sub"));


                         var newClaimsIdentity = new ClaimsIdentity("AuthenticationScheme",
                             "given_name",
                             "role");

                         newClaimsIdentity.AddClaim(subjectClaims);


                         var ticket = new AuthenticationTicket(
                             new ClaimsPrincipal(newClaimsIdentity),
                             TokenValidatedContext.Properties,
                             authenticationScheme: "LimdoWebAppCookies");
                         return Task.FromResult(0);
                     },

                     OnUserInformationReceived = userInformationReceivedContext =>
                     {
                            //userInformationReceivedContext.User.Remove("address");
                            return Task.FromResult(0);
                     }
                 };
             });
            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy("Admin", options =>
                {
                    options.RequireAuthenticatedUser();
                    options.RequireClaim("country", "uk");
                    options.RequireClaim("region", "all");
                    options.RequireClaim("branch", "all");
                    options.RequireClaim("ownerGroup", "employee");
                    options.RequireClaim("ownerGroupLevel", "admin");
                });
                authorizationOptions.AddPolicy("Customer", options =>
                {
                    options.RequireAuthenticatedUser();
                    options.RequireClaim("country", "uk");
                    options.RequireClaim("region", "kent");
                    options.RequireClaim("branch", "maidstone");
                    options.RequireClaim("ownerGroup", "customer");
                    options.RequireClaim("ownerGroupLevel", "saving", "current");
                });
            });


            services.AddScoped<IApiClient, ApiClient>();
            services.AddHttpContextAccessor();
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AppUserViewModelAutoMapperProfile());
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
