using DataTransformer.Common;
using DataTransformer.Data.Model;
using DataTransformer.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransformer.API.Controllers
{
    [Route("api/[controller]")]
    [Route("api/lp")]
    [Route("api/loadprofile")]
    public class LoadProfilesController : ControllerBase
    {
        private readonly IGenericRepository<LoadProfileAggregated> _loadProfileRepository;


        public LoadProfilesController(IGenericRepository<LoadProfileAggregated> loadProfileRepository)
        {
            _loadProfileRepository = loadProfileRepository;
        }

       
        [HttpGet]
        public IEnumerable<LoadProfileAggregated> GetAggregatedLoadProfileData()
        {
            var loadProfiles = _loadProfileRepository.GetAggregatedData();
            return loadProfiles;
            
        }

    }
}
