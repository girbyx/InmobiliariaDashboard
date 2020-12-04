namespace InmobiliariaDashboard.Server.Models.Enumerations
{
    public class CommissionType : BaseEnumeration
    {
        public static readonly CommissionType Flat = new CommissionType(1, "F", "Flat");
        public static readonly CommissionType Percentage = new CommissionType(2, "P", "Percentage");

        public CommissionType(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}