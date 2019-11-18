using DataTransformer.Common;
using DataTransformer.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransformer.Data.Repositories
{
    public class TouRepository : IGenericRepository<TouAggregated>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TouRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public IEnumerable<TouAggregated> GetAggregatedData()
        {
            var ToUs =  _applicationDbContext.ToUs.ToList();
           
            var aggregatedValues = (from item in ToUs
                                    group item.Energy by new { item.MeterCode, item.Date, item.DataType } into g
                                    select new TouAggregated
                                    {
                                        MeterCode = g.Key.MeterCode,
                                        Date = g.Key.Date.ToShortDateString(),
                                        DataType = g.Key.DataType,
                                        MinValue = g.Min(),
                                        MaxValue = g.Max(),
                                        Median = g.Median()
                                    });

            List<TouAggregated> list = aggregatedValues.ToList();

            return list;
        }
        
    }
}
