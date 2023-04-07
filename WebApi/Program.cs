var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration); // inject dependencies into IOC container.


var app = builder.Build();

ConfigureApp(app); // configure middleware

app.Run();


void ConfigureServices(IServiceCollection services, IConfiguration config)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // auto-mapper
    services.AddAutoMapper(typeof(AutoMapperProfile));

    // mediatr
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    // services
    services
        .AddTransient<IWeatherService, WeatherService>();
    //.AddTransient<IWeatherService, BetterWeatherService>();

    // repositories
    services.AddTransient<IWeatherRepository, WeatherRepository>();

    // cosmos sdk client
    services.AddSingleton(_ => new CosmosClient(config["DbConnStr"]).GetDatabase(CosmosConstants.DatabaseName));
}

void ConfigureApp(WebApplication webApp)
{
    webApp.UseSwagger();
    webApp.UseSwaggerUI();
    // @TODO: commented out because of port forwarding issues on codespaces
    // details: https://github.com/orgs/community/discussions/7116
    // webApp.UseHttpsRedirection();
    webApp.MapControllers();
}