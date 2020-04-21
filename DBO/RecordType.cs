using System.Collections.Generic;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class RecordType
    {
        public RecordType()
        {
            Record = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Record> Record { get; set; }
    }
}