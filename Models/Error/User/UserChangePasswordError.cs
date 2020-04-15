namespace record_keep_api.Models.Error.User
{
    public class UserChangePasswordError : FormErrorBase
    {
        public UserChangePasswordError(params string[] form) : base(form)
        {
        }
    }
}