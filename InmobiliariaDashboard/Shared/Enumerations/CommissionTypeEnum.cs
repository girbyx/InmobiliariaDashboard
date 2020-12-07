namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class CommissionTypeEnum : BaseEnumeration
    {
        public static readonly CommissionTypeEnum FlatCash = new CommissionTypeEnum(1, "F", "Flat cash");
        public static readonly CommissionTypeEnum Percentage = new CommissionTypeEnum(2, "P", "Percentage");

        public CommissionTypeEnum() { }
        public CommissionTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}