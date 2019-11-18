using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransformer.UnitTests
{
    public class LoadProfileRepositoryMocker : IGenericRepository<LoadProfileAggregated>
    {
        private readonly List<LoadProfileAggregated> __listLoadProfile;

        public LoadProfileRepositoryMocker()
        {
            __listLoadProfile = new List<LoadProfileAggregated>()
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

        public IEnumerable<LoadProfileAggregated> GetAggregatedData()
        {
            return __listLoadProfile;
        }

       
    }
}
