using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extentions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Musical.Services
{
   public static class ServiceModule
    {
        public static void LoadServiceModule(this IServiceCollection services,string connectionString)
        {
            var con = new DbContextOptionsBuilder<MusicalogContext>();

            con.UseSqlServer(connectionString);
            services.AddTransient<MusicalogContext, new MusicalogContext(con.Options)> ();
        }

    }
}
