namespace record_keep_api.Models.Error.User
{
    public class UserCreationError : FormErrorBase
    {
        public UserCreationError(params string[] form) : base(form)
        {
        }
    }
}