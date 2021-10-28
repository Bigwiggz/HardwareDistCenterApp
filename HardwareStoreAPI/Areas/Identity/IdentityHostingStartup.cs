using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HardwareStoreAPI.Areas.Identity.IdentityHostingStartup))]
namespace HardwareStoreAPI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}