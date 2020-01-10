using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Practice
{
    public class ConfiguringDbContext
    {
        public void DbContextCheck()
        {
            CrudOpeartion crudOpeartion = new CrudOpeartion();
            crudOpeartion.Operation();
        }

        /**
         * //Using DbContext with dependency injection
         * public void ConfigureServices(IServiceCollection services)
           {
           services.AddDbContext<BloggingContext>(options => options.UseSqlite("Data Source=blog.db"));
           }
         **/
    }
}
