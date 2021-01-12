namespace InmobiliariaDashboard.Shared.Enumerations
{
    public class ProjectTypeEnum : BaseEnumeration
    {
        public static readonly ProjectTypeEnum FixedAsset = new ProjectTypeEnum(1, "I", "Inmueble");
        public static readonly ProjectTypeEnum MovableAsset = new ProjectTypeEnum(2, "M", "Mueble");
        public static readonly ProjectTypeEnum Other = new ProjectTypeEnum(3, "X", "Otro");

        public ProjectTypeEnum() { }
        public ProjectTypeEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}