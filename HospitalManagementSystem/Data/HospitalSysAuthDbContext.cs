using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class HospitalSysAuthDbContext:IdentityDbContext
    {
        public HospitalSysAuthDbContext(DbContextOptions<HospitalSysAuthDbContext>options) :base(options)
        {
            
        }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Seed Roles into Database
            var userRoleId = "d4174388-82fb-43e8-a968-275d38764128";
            var superAdminRoleId = "a850b2de-7d03-4915-993f-6a722e3f350y";

            var roles = new List<IdentityRole>{
                new(){
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId,
                    Name="User",
                    NormalizedName="USER"
                },

                new(){
                    Id=superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN"
                }
            };





            base.OnModelCreating(modelBuilder);
            //builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
