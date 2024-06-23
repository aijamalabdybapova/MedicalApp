public class ResearchDocument
{
    public int IdAppointment { get; set; }
    public string Name { get; set; }
    public string Rtf { get; set; }
    public byte[] Attachment { get; set; }
    public Appointment Appointment { get; set; }
}
