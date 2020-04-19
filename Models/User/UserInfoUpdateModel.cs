using record_keep_api.Models.Image;

namespace record_keep_api.Models.User
{
    public class UserInfoUpdateModel
    {
        public string DisplayName { get; set; }

        public ImageOptionsModel Image { get; set; }
    }
}