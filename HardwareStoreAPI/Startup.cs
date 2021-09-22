using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Internal;
using DataAccessLibrary.Services;
using HardwareStoreAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HardwareStoreAPI
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
            //Add DataAccess Containers
            services.AddTransient<ISqlQueries, SqlQueries>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<ICompaniesData, CompaniesData>();
            services.AddTransient<ICompanyContactsData, CompanyContactsData>();
            services.AddTransient<ICompanyOrdersData, CompanyOrdersData>();
            services.AddTransient<ICPIIndexData, CPIIndexData>();
            services.AddTransient<IDistrictSalesZonesData, DistrictSalesZonesData>();
            services.AddTransient<IICECATProductCatalogData, ICECATProductCatalogData>();
            services.AddTransient<IInventoryData, InventoryData>();
            services.AddTransient<IProductOrdersDetailsData, ProductOrdersDetailsData>();
            services.AddTransient<IProductsCatalogData, ProductsCatalogData>();
            services.AddTransient<IRegionalTerritoriesData, RegionalTerritoriesData>();
            services.AddTransient<ISalesData, SalesData>();
            services.AddTransient<ISalesDetailsData, SalesDetailsData>();
            services.AddTransient<IStoreLocationsData, StoreLocationsData>();
            services.AddTransient<IZoneDistributionCenterData, ZoneDistributionCenterData>();

            //Add Automapper
            services.AddAutoMapper(typeof(Startup));

            //Add Identity Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("HardwareIdentitydb")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //Add Authorization to all controllers
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
                endpoints.MapRazorPages();
            });
        }
    }
}
