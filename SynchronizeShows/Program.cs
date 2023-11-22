using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynchronizeShows.Extensions;
using SynchronizeShows.Services.Interfaces;

// Load the configuration
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = configurationBuilder.Build();

//Add services via dependency Injection
var serviceCollection = new ServiceCollection();
serviceCollection.AddSynchronizationServices(configuration);

var serviceProvider = serviceCollection.BuildServiceProvider();
var synchronizationService = serviceProvider.GetRequiredService<ISynchronizationService>();

synchronizationService.SynchronizeAsync();



