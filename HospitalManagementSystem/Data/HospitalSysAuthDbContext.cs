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
             var userRoleId = "9eb172c6-a4c1-49b0-8193-0e62ce89f69f";
             var mainAdminRoleId = "92243373-b7d8-45da-aee9-4b77a8149697";

            var roles = new List<IdentityRole>{
                new IdentityRole
                {
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId,
                    Name="Admin",
                    NormalizedName="ADMIN"
                },

                new IdentityRole
                {
                    Id=mainAdminRoleId,
                    ConcurrencyStamp=mainAdminRoleId,
                    Name="MainAdmin",
                    NormalizedName="MAINADMIN"
                }
            };





            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(roles);  
        }
    }
}
