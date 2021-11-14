using System;
using Microsoft.Extensions.Configuration;
using Otus2.Blocks;
using Otus2.Data;

namespace Otus2
{
    class Program
    {
        static void Main(string[] args)
        {

            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var connectionString = Configuration.GetSection("ConnectionString").Value;

            using (var context = new OtusDbContext(connectionString))
            {
                var manager = new ManagerBlock(context);

                var res = "";
                do
                {
                    manager.ShowSelect();
                    res = Console.ReadLine();

                    manager.Action(res);
                }
                while (res != "1");

            }

        }
    }
}
