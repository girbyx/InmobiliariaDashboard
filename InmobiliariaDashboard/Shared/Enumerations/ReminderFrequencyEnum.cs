namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class ReminderFrequencyEnum : BaseEnumeration
    {
        public static readonly ReminderFrequencyEnum WorkingDays = new ReminderFrequencyEnum(1, "W", "Dias laborales");
        public static readonly ReminderFrequencyEnum Daily = new ReminderFrequencyEnum(2, "D", "Diario");
        public static readonly ReminderFrequencyEnum Weekly = new ReminderFrequencyEnum(3, "S", "Semanal");
        public static readonly ReminderFrequencyEnum Monthly = new ReminderFrequencyEnum(5, "M", "Mensual");
        public static readonly ReminderFrequencyEnum Annually = new ReminderFrequencyEnum(7, "A", "Anual");

        public ReminderFrequencyEnum() { }
        public ReminderFrequencyEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}