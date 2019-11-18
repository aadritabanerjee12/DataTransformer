

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransformer.Data.Model
{
    [Table("tblToU", Schema = "dbo")]
    public class ToU : IEntity
    {
        public int ID { get; set; }
        public int FileID { get; set; }

        [Column("MeterCode")]
        public string MeterCode { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("DataType")]
        public string DataType { get; set; }

        [Column("Energy")]
        public decimal Energy { get; set; }

        [Column("Units")]
        public string Unit { get; set; }
    }
}
