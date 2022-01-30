using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Logging;
using NetCoreJenkinsDocker.Api.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NetCoreJenkinsDocker.Api.DataAccess
{
    //public  class Mirror1DbContext : NCJDDbContext
    //{
    //    public Mirror1DbContext(IServiceProvider serviceProvider) : base serviceProvider
    //    { 
        
    //    }
    //}

    public partial class NCJDDbContext : DbContext
    { 
        private readonly string _connectionString;
        public NCJDDbContext(DbContextOptions<NCJDDbContext> options) : base(options) 
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
         
        public virtual DbSet<SampleDataModel> SampleDatas { get; set; }
        public virtual DbSet<ItemModel> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleDataModel>(entity =>
            {
                entity.ToTable("SampleData");
                entity.HasKey(k => new { k.Id });
               
            });

            modelBuilder.Entity<ItemModel>(entity =>
            {
                entity.ToTable("Item");
                entity.HasKey(k => new { k.Id });
                entity.HasOne(o => o.SampleData)
                .WithMany(o => o.Items)
                .HasForeignKey(f=> f.SampleDataId);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
