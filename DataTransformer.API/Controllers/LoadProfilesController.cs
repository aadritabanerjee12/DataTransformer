using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DataTransformer.API.Controllers
{
    [Route("api")]
    public class LoadProfilesController : ControllerBase
    {
        private readonly IGenericRepository<LoadProfileAggregated> _loadProfileRepository;


        public LoadProfilesController(IGenericRepository<LoadProfileAggregated> loadProfileRepository)
        {
            _loadProfileRepository = loadProfileRepository;
        }


        [HttpGet]
        [Route("loadProfile")]
        public IEnumerable<LoadProfileAggregated> GetAggregatedLoadProfileData()
        {
            try
            {
                return _loadProfileRepository.GetAggregatedData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
