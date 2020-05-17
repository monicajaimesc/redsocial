using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // database
            // host is gonna store what is retorn from createdefaulbuilder method
            var host = CreateWebHostBuilder(args).Build();
            //get datacontext services INJECTION
            // using (anything is inside is gonna clean up after it's complety)
            using (var scope = host.Services.CreateScope())
            {
                // bring services
                var services = scope.ServiceProvider;
                try 
                {
                    // to get the database and migrate the database
                    // type data context from persistence where datacontext is defined
                    var context = services.GetRequiredService<DataContext>();
                    // once we have acces to our datacontext
                    // migrate using entityframeworkcore
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // reference to the logger service<Iloggger<specify the class>>
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error ocurred durung migration");
                }
            }
            // the next time we run our application it's gonna create a database base on a migration
            // and we should see is a new database file called reactivities.db and it should be created in API project
            host.Run();
        }
        // return IHostBuilder, a program initialization abstraction
           public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
