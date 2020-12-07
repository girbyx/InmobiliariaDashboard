namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class AccountType : BaseEnumeration
    {
        public static readonly AccountType FlatCash = new AccountType(2, "F", "Flat cash");
        public static readonly AccountType Card = new AccountType(2, "C", "Card");
        public static readonly AccountType Account = new AccountType(3, "A", "Account");

        public AccountType(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}