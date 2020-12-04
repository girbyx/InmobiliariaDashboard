namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class AccountType : BaseEnumeration
    {
        public static readonly AccountType Card = new AccountType(1, "C", "Card");
        public static readonly AccountType Account = new AccountType(2, "A", "Account");

        public AccountType(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}