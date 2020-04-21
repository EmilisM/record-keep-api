namespace record_keep_api.DBO
{
    public partial class CollectionRecords
    {
        public int CollectionId { get; set; }
        public int RecordId { get; set; }

        public Collection Collection { get; set; }
        public Collection Record { get; set; }
    }
}