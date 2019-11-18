using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransformer.Data.Model
{
    public class LoadProfileAggregated:IEntityAggregated
    {
        public string MeterCode { get; set; }
        public string Date { get; set; }
        public string DataType { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal Median { get; set; }
        
    }
}
