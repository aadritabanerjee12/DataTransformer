using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DataTransformer.API.Controllers
{
    [Route("api")]
    public class TousController : ControllerBase
    {
        private readonly IGenericRepository<TouAggregated> _touRepository;

        public TousController(IGenericRepository<TouAggregated> touRepository)
        {
            _touRepository = touRepository;
        }

        [HttpGet]
        [Route("tou")]
        public IEnumerable<TouAggregated> GetAggregatedLTouData()
        {
            try
            {
                return _touRepository.GetAggregatedData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
