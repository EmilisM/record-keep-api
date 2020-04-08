namespace record_keep_api.Models
{
    public class ErrorValue
    {
        public int Status { get; set; }

        public object Errors { get; set; }
    }
}