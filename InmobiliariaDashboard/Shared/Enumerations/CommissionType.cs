namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class CommissionType : BaseEnumeration
    {
        public static readonly CommissionType FlatCash = new CommissionType(1, "F", "Flat cash");
        public static readonly CommissionType Percentage = new CommissionType(2, "P", "Percentage");

        public CommissionType() { }
        public CommissionType(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}