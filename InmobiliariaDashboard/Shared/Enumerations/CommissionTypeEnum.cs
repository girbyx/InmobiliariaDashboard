namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class CommissionTypeEnum : BaseEnumeration
    {
        public static readonly CommissionTypeEnum Money = new CommissionTypeEnum(1, "E", "Efectivo");
        public static readonly CommissionTypeEnum Percentage = new CommissionTypeEnum(2, "P", "Porcentaje");

        public CommissionTypeEnum() { }
        public CommissionTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}