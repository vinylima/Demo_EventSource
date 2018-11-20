
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DemoRepository.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:52452")
                .UseStartup<Startup>();
    }
}