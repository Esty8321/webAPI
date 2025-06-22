using Microsoft.EntityFrameworkCore;
using repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class DbFixure : IDisposable
    {
        public webApiServerContext Context { get; private set; }
        public DbFixure()
        {
            var options = new DbContextOptionsBuilder<webApiServerContext>()
                        //options.UseSqlServer("Data Source=DESKTOP-IN2P6D4;Initial Catalog=IceCreamStore;Integrated Security=True;TrustServerCertificate=True"));

                .UseSqlServer("Data Source=DESKTOP-IN2P6D4;Initial Catalog=TestIceCreamStore;Integrated Security=True;TrustServerCertificate=True")
                .Options;
            Context=new webApiServerContext(options);
            try
            {
                Context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
