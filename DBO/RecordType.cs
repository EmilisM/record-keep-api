using System;
using System.Collections.Generic;

namespace record_keep_api.DBO
{
    public partial class RecordType
    {
        public RecordType()
        {
            Record = new HashSet<Record>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Record> Record { get; set; }
    }
}
