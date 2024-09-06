using HospitalManagementSystem.Models.AppointmentManagement;
using HospitalManagementSystem.Models.Billing_Management;
using HospitalManagementSystem.Models.DoctorManagement;
using HospitalManagementSystem.Models.LabManagement;
using HospitalManagementSystem.Models.PatientManagement;
using HospitalManagementSystem.Models.PharmacyManagement;
using HospitalManagementSystem.Models.StaffManagement;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data
{
    public class HospitalSysDbContext:DbContext
    {
        public HospitalSysDbContext(DbContextOptions<HospitalSysDbContext> options) : base(options) 
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<BillingInvoice> BillingInvoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


           
        }



    }
}
