﻿namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class MonetaryAgentTypeEnum : BaseEnumeration
    {
        public static readonly MonetaryAgentTypeEnum Money = new MonetaryAgentTypeEnum(1, "E", "Efectivo");
        public static readonly MonetaryAgentTypeEnum Card = new MonetaryAgentTypeEnum(2, "T", "Tarjeta");
        public static readonly MonetaryAgentTypeEnum Account = new MonetaryAgentTypeEnum(3, "C", "Cuenta");
        public static readonly MonetaryAgentTypeEnum Other = new MonetaryAgentTypeEnum(3, "X", "Otro");

        public MonetaryAgentTypeEnum() { }
        public MonetaryAgentTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}