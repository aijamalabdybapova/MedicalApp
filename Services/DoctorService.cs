public class DoctorService
{
    private readonly ApplicationContext _context;

    public DoctorService(ApplicationContext context)
    {
        _context = context;
    }

    public void CancelAppointment(int appointmentId)
    {
        var appointment = _context.Appointments.Find(appointmentId);
        if (appointment != null)
        {
            appointment.IdStatus = _context.Statuses.SingleOrDefault(s => s.Name == "Отменено").IdStatus;
            _context.SaveChanges();
        }
    }

    public void StartAppointment(int appointmentId)
    {
        var appointment = _context.Appointments.Find(appointmentId);
        if (appointment != null)
        {
            appointment.IdStatus = _context.Statuses.SingleOrDefault(s => s.Name == "Прием начат").IdStatus;
            _context.SaveChanges();
        }
    }

    public void AddAppointmentDetails(int appointmentId, string details)
    {
        var appointmentDocument = new AppointmentDocument
        {
            IdAppointment = appointmentId,
            Name = "Details",
            Rtf = details
        };
        _context.AppointmentDocuments.Add(appointmentDocument);
        _context.SaveChanges();
    }

    public void EndAppointment(int appointmentId, string details)
    {
        var appointment = _context.Appointments.Find(appointmentId);
        if (appointment != null)
        {
            appointment.IdStatus = _context.Statuses.SingleOrDefault(s => s.Name == "Завершено").IdStatus;
            var appointmentDocument = new AppointmentDocument
            {
                IdAppointment = appointmentId,
                Name = "EndDetails",
                Rtf = details
            };
            _context.AppointmentDocuments.Add(appointmentDocument);
            _context.SaveChanges();
        }
    }
}
