using System;

namespace record_keep_api.Services
{
    public static class StaticHelpers
    {
        public static bool IsBase64(string value)
        {
            try
            {
                var output = Convert.FromBase64String(value);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}