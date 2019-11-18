using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransformer.Data.Model
{
    [Table("tblLoadProfile", Schema = "dbo")]
    public class LoadProfile : IEntity
    {
        public int ID { get; set; }
        public int FileID { get; set; }

        [Column("MeterPoint Code")]
        public string MeterCode { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Data Type")]
        public string DataType { get; set; }

        [Column("Data Value")]
        public decimal DataValue { get; set; }

        [Column("Units")]
        public string Unit { get; set; }

    }
}
