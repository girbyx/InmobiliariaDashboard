using InmobiliariaDashboard.Shared.Interfaces;

namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class SendProjectInformationViewModel : IISendEmailWithAttachments
    {
        public int ProjectId { get; set; }
        public int ContactId { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}