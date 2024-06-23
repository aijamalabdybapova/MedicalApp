class Program
{
    static void Main()
    {
        using (var context = new ApplicationContext())
        {
            var doctorService = new DoctorService(context);

            // Создание новой записи (пример)
            var appointment = new Appointment
            {
                OMS = 123456,
                IdDoctor = 1,
                AppointmentDate = DateTime.Now,
                AppointmentTime = TimeSpan.FromHours(10),
                IdStatus = context.Statuses.SingleOrDefault(s => s.Name == "Запланировано").IdStatus
            };
            context.Appointments.Add(appointment);
            context.SaveChanges();

            // Отмена записи
            doctorService.CancelAppointment(appointment.IdAppointment);

            // Начало приема
            doctorService.StartAppointment(appointment.IdAppointment);

            // Добавление информации о приеме
            doctorService.AddAppointmentDetails(appointment.IdAppointment, "Пациент сдал анализы");

            // Завершение приема
            doctorService.EndAppointment(appointment.IdAppointment, "Прием завершен. Диагноз: здоров.");
        }
    }
}
