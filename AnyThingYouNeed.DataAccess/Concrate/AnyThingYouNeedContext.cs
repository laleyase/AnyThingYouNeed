using AnyThingYouNeed.Entities.Concrate;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = AnyThingYouNeed.Entities.Concrate.Request;

namespace AnyThingYouNeed.DataAccess.Concrate
{
    public class AnyThingYouNeedContext : DbContext
    {
        public AnyThingYouNeedContext(DbContextOptions<AnyThingYouNeedContext> options) : base(options)
        {
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Veritabanı bağlantı dizesi ve diğer ayarlar burada yapılır
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;initial catalog=AnyThingYouNeed;integrated security=SSPI", options =>
                {
                    options.UseRelationalNulls();
                    options.MigrationsHistoryTable("__EFMigrationsHistory");
                    options.EnableRetryOnFailure();
                    options.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                });
            }
        }
    }
}
