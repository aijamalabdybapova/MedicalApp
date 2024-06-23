public class Doctor
{
    public int IdDoctor { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public int IdSpeciality { get; set; }
    public string EnterPassword { get; set; }
    public string WorkAddress { get; set; }
    public Speciality Speciality { get; set; }
}
