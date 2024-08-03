using Microsoft.EntityFrameworkCore;
using server_api.Entities;

namespace server_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<KioskMachine> KioskMachines { get; set; }
        public DbSet<IPTVMachine> IPTVMachines { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubService> SubServices { get; set; }
        public DbSet<BoxService> BoxServices { get; set; }
        public DbSet<DeskService> DeskServices { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<GeneratedCouponDetail> GeneratedCouponDetails {get ; set;}
        public DbSet<ValidateDeskBox> ValidateDeskBoxes {get ; set;}
        public DbSet<NextPendingCoupon> NextPendingCoupons {get ; set;}
        public DbSet<BoxServiceIPTV> BoxServicesIPTV {get ; set;}

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<IPTVMachine>()
            //     .Property(f => f.IPTVNo)
            //     .IsRequired();
        }
        #endregion
    }
}