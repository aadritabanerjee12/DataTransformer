using DataTransformer.Common;
using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransformer.API.Controllers
{
    [Route("api/[controller]")]
    [Route("api/tou")]
    public class TousController : ControllerBase
    {
        private readonly IGenericRepository<TouAggregated> _tousRepository;

        public TousController(IGenericRepository<TouAggregated> tousRepository)
        {
            _tousRepository = tousRepository;
        }

        // GET api/tous
        [HttpGet]
        public IEnumerable<TouAggregated> GetAggregatedLTouData()
        {
            var tous = _tousRepository.GetAggregatedData();
            return tous;

            //return Ok(ToUs);
        }


    }
}
