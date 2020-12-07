namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class AccountTypeEnum : BaseEnumeration
    {
        public static readonly AccountTypeEnum FlatCash = new AccountTypeEnum(2, "F", "Flat cash");
        public static readonly AccountTypeEnum Card = new AccountTypeEnum(2, "C", "Card");
        public static readonly AccountTypeEnum Account = new AccountTypeEnum(3, "A", "Account");

        public AccountTypeEnum() { }
        public AccountTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}