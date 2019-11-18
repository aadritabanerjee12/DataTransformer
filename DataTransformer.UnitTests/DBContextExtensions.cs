using DataTransformer.Data;
using DataTransformer.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransformer.UnitTests
{
    public static class DBContextExtensions
    {

        public static void Seed(this ApplicationDbContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID=1,
                FileID=1,
                MeterCode= "210095893",
                Date=Convert.ToDateTime("31/08/2018"),
                DataType= "Import Wh Total",
                DataValue=4,
                Unit="kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("31/08/2018"),
                DataType = "Import Wh Total",
                DataValue = 3,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("31/08/2018"),
                DataType = "Import Wh Total",
                DataValue = 2,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("30/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 5,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("30/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 3,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("30/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 1,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("31/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 4,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("31/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 0,
                Unit = "kwh"
            });
            dbContext.LoadProfiles.Add(new LoadProfile
            {
                ID = 1,
                FileID = 1,
                MeterCode = "210095893",
                Date = Convert.ToDateTime("31/08/2018"),
                DataType = "Export Wh Total",
                DataValue = 3,
                Unit = "kwh"
            });


            dbContext.SaveChanges();
        }
    }
}
