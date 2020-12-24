namespace InmobiliariaDashboard.Shared
{
    public static class Constants
    {
        public static string ExcelMimeType = "application/vnd.ms-excel";

        public static string UsernameConfigPath = "MegaClientApi:Credentials:Username";
        public static string PasswordConfigPath = "MegaClientApi:Credentials:Password";

        public static string ProjectFolderPath = "ProjectUploads_ProjectID_";
        public static string CostFolderPath = "CostUploads_CostID_";
        public static string GainFolderPath = "GainUploads_GainID_";
        public static string LossFolderPath = "LossUploads_LossID_";

        public static string SendGridApiKey = "SendGrid:SENDGRID_API_KEY";
        public static string ReplyEmail = "SendGrid:ReplyEmail";
        public static string ReplyName = "SendGrid:ReplyName";

        public static string MaxDaysToNextOccurrence = "Notifications:MaxDaysToNextOccurrence";
        public static string MaxHoursToNextOccurrence = "Notifications:MaxHoursToNextOccurrence";
        public static string MaxMinutesToNextOccurrence = "Notifications:MaxMinutesToNextOccurrence";
    }
}
