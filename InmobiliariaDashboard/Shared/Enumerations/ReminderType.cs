namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class ReminderType : BaseEnumeration
    {
        public static readonly ReminderType Weekly = new ReminderType(1, "S", "Semanal");
        public static readonly ReminderType BiWeekly = new ReminderType(2, "BS", "Catorcenal");
        public static readonly ReminderType Monthly = new ReminderType(3, "M", "Mensual");
        public static readonly ReminderType BiMonthly = new ReminderType(4, "BM", "Bimestral");
        public static readonly ReminderType Annually = new ReminderType(5, "A", "Anual");

        public ReminderType() { }
        public ReminderType(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}