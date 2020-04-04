namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class CollectionRecords
    {
        public int CollectionId { get; set; }
        public int RecordId { get; set; }

        public virtual Collection Collection { get; set; }
        public virtual Collection Record { get; set; }
    }
}
