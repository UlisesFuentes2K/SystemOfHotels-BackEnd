using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SOH.MAIN.Models.Audit;
using SOH.MAIN.Models.Booking;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Employee;
using SOH.MAIN.Models.Payments;
using SOH.MAIN.Models.Users;
using System.Reflection;

namespace SOH.PERSISTENCE.Data
{
    public class AplicationDbContext : IdentityDbContext<SR_Users>
    {
        // Customer
        public DbSet<SR_Person> SRH_Person { get; set; }
        public DbSet<SR_Country> SRH_Country { get; set; }
        public DbSet<SR_City> SRH_Cities { get; set; }
        public DbSet<SR_TypePerson> SRH_TypePerson { get; set; }
        public DbSet<SR_Contacts> SRH_Contacts { get; set; }

        //Employee
        public DbSet<SR_Employee> SRH_Employee { get; set; }
        public DbSet<SR_TypeEmployee> SRH_TypeEmployee { get; set; }

        //Booking
        public DbSet<SR_Booking> SRH_Booking { get; set; }
        public DbSet<SR_CalendarDetail> SRH_CalendarDetail { get; set; }
        public DbSet<SR_Calendar> SRH_Calendar { get; set; }
        public DbSet<SR_Room> SRH_Room { get; set; }
        public DbSet<SR_RoomDetail> SRH_RoomDetail { get; set; }
        public DbSet<SR_CategoryRoom> SRH_CategoryRoom { get; set; }
        public DbSet<SR_Promotion> SRH_Promotion { get; set; }
        public DbSet<SR_Binnacle> SRH_Binnacle { get; set; }

        //Payments
        public DbSet<SR_Bill> SRH_Bill { get; set; }
        public DbSet<SR_TypePay> SRH_TypePay { get; set; }
        public DbSet<SR_Recharge> SRH_Recharge { get; set; }

        //Audit
        public DbSet<SR_AuditLog> SRH_AuditLog { get; set; }

        public AplicationDbContext(){ }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<SR_Users>().ToTable("SRH_Users");
            builder.Entity<IdentityUserClaim<string>>().ToTable("SRH_UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("SRH_UserLogin");
            builder.Entity<IdentityUserRole<string>>().ToTable("SRH_UserRole");
            builder.Entity<IdentityUserToken<string>>().ToTable("SRH_UserToken");
            builder.Entity<IdentityRole>().ToTable("SRH_Role");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("SRH_RoleClaim");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
