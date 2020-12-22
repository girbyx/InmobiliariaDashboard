namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class ProjectTypeEnum : BaseEnumeration
    {
        public static readonly ProjectTypeEnum FixedAsset = new ProjectTypeEnum(1, "I", "Inmueble");
        public static readonly ProjectTypeEnum MovableAsset = new ProjectTypeEnum(2, "M", "Mueble");
        public static readonly ProjectTypeEnum Office = new ProjectTypeEnum(3, "O", "Oficina");
        public static readonly ProjectTypeEnum Other = new ProjectTypeEnum(4, "X", "Otro");

        public ProjectTypeEnum() { }
        public ProjectTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}