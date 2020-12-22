namespace InmobiliariaDashboard.Shared.Interfaces
{
    public interface  IISendEmail
    {
        string ToEmail { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
    }
}
