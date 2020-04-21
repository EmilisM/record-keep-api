namespace record_keep_api.Services
{
    public static class StaticHelpers
    {
        public static string ToCamelCase(this string name)
        {
            return string.IsNullOrEmpty(name) ? name : $"{name.Substring(0, 1).ToLower()}{name.Substring(1)}";
        }
    }
}