using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendorPortal.Models;

namespace VendorPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<VendorType>().ToTable("VendorType"); 
            modelBuilder.Entity<VendorCategory>().ToTable("VendorCategory");

            modelBuilder.Entity<Vendor>()
                .ToTable("Vendor")
                .HasOne<VendorType>(v => v.VendorType)
                .WithMany(vt => vt.Vendors)
                .HasForeignKey(v => v.VendorTypeID);

            modelBuilder.Entity<VendorCategoryMap>()
                .ToTable("VendorCategoryMap")
                .HasOne(x => x.Vendor)
                .WithMany(x => x.VendorCategoryMaps)
                .HasForeignKey(x => x.VendorId);
            modelBuilder.Entity<VendorCategoryMap>()
                .ToTable("VendorCategoryMap")
                .HasOne(x => x.VendorCategory)
                .WithMany(x => x.VendorCategoryMaps)
                .HasForeignKey(x => x.VendorCategoryId);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }
        public DbSet<VendorCategory> VendorCategories { get; set; }
    }
}
