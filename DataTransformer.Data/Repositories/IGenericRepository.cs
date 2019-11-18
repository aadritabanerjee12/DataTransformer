using DataTransformer.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataTransformer.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntityAggregated
    {
        //Task<IEnumerable<TEntity>> GetAllData();
        IEnumerable<TEntity> GetAggregatedData();
    }
}
