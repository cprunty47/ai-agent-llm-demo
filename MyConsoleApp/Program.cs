using System;
using ManagedCuda;
using MyConsoleApp.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the AI Prompt Console App!");
            Console.WriteLine("Type 'exit' to quit, '/switch' to change processor.");

            var services = ConfigureServices(new ServiceCollection()).BuildServiceProvider();

            var gpuManager = services.GetRequiredService<IGpuManager>();
            var isRunningOnGPU = gpuManager.IsRunningOnGPU();
            Console.WriteLine($"Running on GPU: {isRunningOnGPU}");

            Process(services);
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGpuManager, GpuManager>();
            services.AddSingleton<UncleBobProcessor>();
            services.AddSingleton<AzureProcessor>();
            services.AddSingleton<IProcessor, AzureProcessor>(); // Default
            return services;
        }   

        static void Process(IServiceProvider services)
        {
            IProcessor currentProcessor = services.GetRequiredService<IProcessor>();
            Console.WriteLine($"Using: {currentProcessor.GetType().Name}");

            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine();

                if (userInput?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (userInput?.ToLower() == "/switch")
                {
                    if (currentProcessor is UncleBobProcessor)
                    {
                        currentProcessor = services.GetRequiredService<AzureProcessor>();
                    }
                    else
                    {
                        currentProcessor = services.GetRequiredService<UncleBobProcessor>();
                    }
                    Console.WriteLine($"Switched to: {currentProcessor.GetType().Name}");
                    continue;
                }

                string response = currentProcessor.GetResponse(userInput);
                Console.WriteLine($"AI: {response}");
            }
        }
    }
}