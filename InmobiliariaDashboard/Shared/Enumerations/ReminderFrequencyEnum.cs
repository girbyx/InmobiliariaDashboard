namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class ReminderFrequencyEnum : BaseEnumeration
    {
        public static readonly ReminderFrequencyEnum Weekly = new ReminderFrequencyEnum(1, "S", "Semanal");
        public static readonly ReminderFrequencyEnum BiWeekly = new ReminderFrequencyEnum(2, "BS", "Catorcenal");
        public static readonly ReminderFrequencyEnum Monthly = new ReminderFrequencyEnum(3, "M", "Mensual");
        public static readonly ReminderFrequencyEnum BiMonthly = new ReminderFrequencyEnum(4, "BM", "Bimestral");
        public static readonly ReminderFrequencyEnum Annually = new ReminderFrequencyEnum(5, "A", "Anual");

        public ReminderFrequencyEnum() { }
        public ReminderFrequencyEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}