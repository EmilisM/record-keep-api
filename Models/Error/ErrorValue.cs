namespace record_keep_api.Models.Error
{
    public class ErrorValue
    {
        public int Status { get; set; }

        public object Errors { get; set; }
    }
}