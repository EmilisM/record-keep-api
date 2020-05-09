using System;
using System.ComponentModel.DataAnnotations;

namespace record_keep_api.Models.Record
{
    public class UpdateRecordModel
    {
        [Required] public string Artist { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        [Required] public DateTime Year { get; set; }
        [Required] public string Label { get; set; }
        public decimal? Rating { get; set; }
        public string RecordLength { get; set; }

        public int? ImageId { get; set; }

        [Required] public int RecordTypeId { get; set; }
        [Required] public int RecordFormatId { get; set; }
        [Required] public int[] StyleIds { get; set; }
    }
}