using System;
using System.Collections.Generic;

namespace record_keep_api.DBO
{
    public partial class Record
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? RecordTypeId { get; set; }

        public virtual RecordType RecordType { get; set; }
    }
}
