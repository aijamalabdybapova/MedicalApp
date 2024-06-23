public class Appointment
{
    public int IdAppointment { get; set; }
    public long? OMS { get; set; }
    public int IdDoctor { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan AppointmentTime { get; set; }
    public int? IdStatus { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public Status Status { get; set; }
    public List<AppointmentDocument> AppointmentDocuments { get; set; }
}
