# DataTransformer
WebAPI that fetches data from azure sql database and aggregates them

There is a blob triggered azure function that executes whenever a file is dropped in the Azure blob storage ('import'). 
This function load the file data to sql azure. DataTransformer is a .NET core Web API hosted in azure that fetches the loaded data 
and aggregates them to find the max, min and median based on MeterCode, Date (not time) and DataType.

# Project architecture
Used Entity Framework together with ASP .NET Core Web API project created in the Microsoft Visual Studio. For the solution to have clear structure, created 4 separate projects:
1) ASP .NET Core Web API called “DataTransformer.WebAPI”
2) .NET Core Class Library project – for Entity Framework related code called “DataTransformer.Data”
3) .NET Core Class Library project – for common code shared between two above projects called “DataTransformer.Common”
4) .NET Core xUnit Test project – for wrting the unit test cases called “DataTransformer.Tests”
Added minimal NuGet packages in each project

DbContext
=============================
Setup “ApplicationDbContext” class which inherits from DbContext and is located in the “DataTransformer.Data” project. There are two DbSets: LoadProfile and Tou:
In the constructor of ApplicationDbContext, there is parameter “DbContextOptions<ApplicationDbContext>”. This is required to inject connection string to SQL Database located in Microsoft Azure cloud.
In the Web API project in the “Startup” class, the usage of Entity Framework and database connection are indicated:
services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("ApplicationDbContext")
              )
          );

Repositories
=============================
The repositories LoadProfileRepository and TouRepository have been used fetch data from the database and aggregate them to find max, min and median based on MeterCode, Date (not time) and DataType.
'max' and 'min' are available LINQ methods. To find the median, the extension method namely Median (written in LinqExtensions.cs class) has been used 
public static class QueryableExtensions
    {
        public static decimal Median(this IEnumerable<decimal> source)
        {
            if (source.Count() == 0)
            {
                throw new InvalidOperationException("Cannot compute median for an empty set.");
            }

            var sortedList = from number in source
                             orderby number
                             select number;

            int itemIndex = (int)sortedList.Count() / 2;

            if (sortedList.Count() % 2 == 0)
            {
                // Even number of items.
                return (sortedList.ElementAt(itemIndex) + sortedList.ElementAt(itemIndex - 1)) / 2;
            }
            else
            {
                // Odd number of items.
                return sortedList.ElementAt(itemIndex);
            }
        }

    }
The repositories implement the generic interface called “IGenericRepository. The repositories are registered in the IoC container in the “Startup” class:
services.AddScoped<IGenericRepository<TouAggregated>, TouRepository>();
services.AddScoped<IGenericRepository<LoadProfileAggregated>, LoadProfileRepository>();

Controllers
=============================
In the “DataTransformer.WebAPI” project there two separate controllers responsible for handling the HTTP get requests. A repository object is injected into the controller's constructor
<Brief description of Azure Function and SQL Azure DB>

Unit Tests
=============================
The controller's logic is testes by the unit tests written using xUnit, Autofixture and NSubstitute. 
public LoadProfileControllerUnitTest()
{
    _fixture = new Fixture();
    _repo = Substitute.For<IGenericRepository<LoadProfileAggregated>>();
    _controller = new LoadProfilesController(_repo);
}
    
[Fact]
public void GetAggregatedLoadProfileData_WhenCalled_ReturnsAggregatedItems()
{
    //arrange 
    _repo.GetAggregatedData().Returns(LoadProfileTestData.GetAggregatedTestData());

    //act
    var response = _controller.GetAggregatedLoadProfileData();

    // Assert
    response.Should().HaveCount(2);
}
        

# Assumptions
1) File format will be same
2) File name will follow the same pattern as provided
3) Blob storage container name should be ‘import’


# Scope for improvement
Only unit tests for a single controller login have been written. For complete code coverage, the other classes as well as the data layer needs to be tested. Integration tests need to be added.
In-memory DB or Autofixture could be used for automated test data creation
Tools like Resharper or Stylecop could be used for best standard coding and convention
File validation, data validation(e.g. wrong data type and unit combination, null values etc.) should be handled while loading the data. This will minimize the risk of data related exception in the API
Azure data factory could be used for data loading from csv files, instead of Stored procedure

