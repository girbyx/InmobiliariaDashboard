namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class BankAccountTypeEnum : BaseEnumeration
    {
        public static readonly BankAccountTypeEnum Cash = new BankAccountTypeEnum(1, "E", "Efectivo");
        public static readonly BankAccountTypeEnum Bank = new BankAccountTypeEnum(2, "B", "Bancario");
        public static readonly BankAccountTypeEnum Other = new BankAccountTypeEnum(3, "X", "Otro");

        public BankAccountTypeEnum() { }
        public BankAccountTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}