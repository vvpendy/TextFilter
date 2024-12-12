
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TextFilter.Filters;
using TextFilter.Interfaces;
using TextFilter.Processors;

namespace TextFilter{
    class Program{
        static void Main(string[] args){

            // Retrieve config info from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) 
                .Build();

            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection,config);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var textfileProcessor = serviceProvider.GetService<IProcessor>();
            
            // Process the text using filters
            var filteredWords  = textfileProcessor.Process();

            // Display the result
            Console.WriteLine("Filtered Text:");
                Console.WriteLine(string.Join(" ",filteredWords));
        }
        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration){
            services.AddSingleton(configuration);
            services.AddSingleton<IFilter,VowelFilter>();
            services.AddSingleton<IFilter,LengthFilter>();
            services.AddSingleton<IFilter,LetterFilter>();
            services.AddSingleton<StreamReader>(s=> new StreamReader(configuration["TextFilePath"]));
            services.AddSingleton<IProcessor,TextFileProcessor>();
        }
    }
}