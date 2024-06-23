using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Speciality> Specialities { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<AppointmentDocument> AppointmentDocuments { get; set; }
    public DbSet<AnalysisDocument> AnalysisDocuments { get; set; }
    public DbSet<ResearchDocument> ResearchDocuments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Your_Connection_String_Here");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.OMS);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.IdDoctor);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Status)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.IdStatus);

        modelBuilder.Entity<AppointmentDocument>()
            .HasKey(ad => ad.IdAppointment);

        modelBuilder.Entity<AnalysisDocument>()
            .HasKey(ad => ad.IdAppointment);

        modelBuilder.Entity<ResearchDocument>()
            .HasKey(rd => rd.IdAppointment);
    }
}
