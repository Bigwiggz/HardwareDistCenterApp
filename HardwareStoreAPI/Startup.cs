using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Internal;
using DataAccessLibrary.Services;
using HardwareStoreAPI.Data;
using HardwareStoreAPI.Services.Email.Sender;
using HardwareStoreBusinessLogicLibrary.ControllerLogic.DistributionCenter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Mail;

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

            //Add Business Logic Containers
            services.AddTransient<IDistributionCenterBuisnessLogic, DistributionCenterBuisnessLogic>();

            //Add Automapper
            services.AddAutoMapper(typeof(Startup));

            //Add Identity Database
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("HardwareIdentitydb")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
            });

            services.AddRazorPages();
            //Add Authorization to all controllers
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });

            //Add session data
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = "UserData.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMemoryCache();

            //Set inactivity timeout to 10 days for cookie
            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromDays(10);
                o.SlidingExpiration = true;
            });

            //Add Cookie Policy Options
            services.Configure<CookiePolicyOptions>(options =>
            {
                // consent required
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //TODO: Check to see if this JsonSerializer Configuration works with Net Topology Suite
            //Add GeoJSON Converter

            //Email Setup-Gmail
            var gmailSender = Configuration.GetSection("GmailEmailConfiguration")["Sender"];
            var gmailFrom = Configuration.GetSection("GmailEmailConfiguration")["From"];
            var gmailHost = Configuration.GetSection("GmailEmailConfiguration")["Host"];
            var gmailPort = Convert.ToInt32(Configuration.GetSection("GmailEmailConfiguration")["Port"]);
            var gmailPassword = Configuration.GetSection("GmailEmailConfiguration")["Password"];

            services
                .AddFluentEmail(gmailSender, gmailFrom)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient(gmailHost)
                {
                    UseDefaultCredentials = false,
                    Port = gmailPort,
                    Credentials = new NetworkCredential(gmailSender, gmailPassword),
                    EnableSsl = true,
                });


            //Email DI Mapping
            services.AddScoped<IEmailSender, EmailSender>();
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

            app.UseSession();

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
