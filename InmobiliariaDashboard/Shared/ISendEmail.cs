namespace InmobiliariaDashboard.Shared
{
    public interface  ISendEmail
    {
        string ToEmail { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
    }
}
