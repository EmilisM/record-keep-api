using System.Collections.Generic;

namespace record_keep_api.DBO
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Record> Records { get; set; }
    }
}