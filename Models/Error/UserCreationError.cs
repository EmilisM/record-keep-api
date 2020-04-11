namespace record_keep_api.Models.Error
{
    public class UserCreationError : FormErrorBase
    {
        public UserCreationError(params string[] form) : base(form)
        {
        }
    }
}