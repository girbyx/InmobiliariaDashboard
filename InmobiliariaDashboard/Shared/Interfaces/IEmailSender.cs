namespace InmobiliariaDashboard.Shared.Interfaces
{
    public interface  IEmailSender
    {
        string ToEmail { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
    }
}
