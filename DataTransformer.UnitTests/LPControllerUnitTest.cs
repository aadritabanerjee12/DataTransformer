using DataTransformer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransformer.UnitTests
{
    public class LPControllerUnitTest
    {

        private LoadProfileRepositoryMocker repository;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=.;Database=PlaypenDB;UID=sa;PWD=xxxxxxxxxx;";

        static LPControllerUnitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
