namespace WebApi.Repositories.Implementations;

public class WeatherRepository : CosmosGenericRepositoryBase<WeatherDao>, IWeatherRepository
{
    public WeatherRepository(Database cosmosDatabase) : base(cosmosDatabase, CosmosConstants.ContainerName)
    {
    }
}