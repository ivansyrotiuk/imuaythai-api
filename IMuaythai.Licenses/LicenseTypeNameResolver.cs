using IMuaythai.DataAccess.Models;

namespace IMuaythai.Licenses
{
    public class LicenseTypeNameResolver
    {
        public static string ResolveLicenseTypeName(LicenseType src)
        {
            var ownership = string.Empty;
            switch (src.Kind)
            {
                case LicenseKinds.Fighter:
                    ownership = "zawodnika";
                    break;
                case LicenseKinds.Coach:
                    ownership = "trenera";
                    break;
                case LicenseKinds.Judge:
                    ownership = "sędziego";
                    break;
                case LicenseKinds.Gym:
                    ownership = "klubowa";
                    break;
            }

            var duration = src.OneOff ? "jednorazowa" : $"na {src.Duration} dni";

            return $"Licencja {ownership} {duration}";
        }
    }
}