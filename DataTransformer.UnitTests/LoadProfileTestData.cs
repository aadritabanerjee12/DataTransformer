using DataTransformer.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransformer.UnitTests
{
    public static class LoadProfileTestData
    {
        public static IEnumerable<LoadProfileAggregated> GetAggregatedTestData()
        {
            return new List<LoadProfileAggregated>()
            {
                new LoadProfileAggregated() {  MeterCode = "210095893",
                    Date = "31/08/2018",
                    DataType = "Import Wh Total",
                    MaxValue = 4,
                    MinValue = 0,
                    Median = 1},
                new LoadProfileAggregated() {  MeterCode = "210095893",
                    Date = "31/08/2018",
                    DataType = "Import Wh Total",
                    MaxValue = 3,
                    MinValue = 2,
                    Median = 2},
            };
        }
    }
}
