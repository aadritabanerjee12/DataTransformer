using DataTransformer.Common;
using DataTransformer.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransformer.Data.Repositories
{
    public class LoadProfileRepository : IGenericRepository<LoadProfileAggregated>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LoadProfileRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        

        public IEnumerable<LoadProfileAggregated> GetAggregatedData()
        {
            var LPs = _applicationDbContext.LoadProfiles.ToList();

            

            var aggregatedValues = (from item in LPs
                                    group item.DataValue by new { item.MeterCode, item.Date, item.DataType } into g
                                    select new LoadProfileAggregated
                                    {
                                        MeterCode = g.Key.MeterCode,
                                        Date = g.Key.Date.ToShortDateString(),
                                        DataType = g.Key.DataType,
                                        MinValue = g.Min(),
                                        MaxValue = g.Max(),
                                        Median = g.Median()
                                    });

            List<LoadProfileAggregated> list = aggregatedValues.ToList();

            return list;
            
        }

      
    }
}
