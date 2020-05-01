namespace record_keep_api.DBO
{
    public class RecordStyles
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}