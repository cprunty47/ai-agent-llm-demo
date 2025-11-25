using System;
using ManagedCuda;
using MyConsoleApp.Builders;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the AI Prompt Console App!");
            Console.WriteLine("Type 'exit' to quit.");

            var services = ConfigureServices(new ServiceCollection()).BuildServiceProvider();

            var gpuManager = services.GetRequiredService<IGpuManager>();
            var isRunningOnGPU = gpuManager.IsRunningOnGPU();
            Console.WriteLine($"Running on GPU: {isRunningOnGPU}");

            Process(services);
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGpuManager, GpuManager>();
            // Use UncleBobProcessor by default
            services.AddSingleton<IProcessor, UncleBobProcessor>();
            return services;
        }   

        static void Process(IServiceProvider services)
        {
            var processor = services.GetRequiredService<IProcessor>();

            // Implementation goes here
            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine();

                if (userInput?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                // Check for Uncle Bob responses
                string response = processor.GetResponse(userInput);

                Console.WriteLine($"AI: {response}");
            }
        }


    }
}