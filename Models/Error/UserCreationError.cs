namespace record_keep_api.Models.Error
{
    public class UserCreationError : ErrorBase
    {
        public UserCreationError(params string[] form) : base(form)
        {
        }
    }
}