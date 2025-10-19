using System;
using ManagedCuda;

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

            var processor = services.GetRequiredService<IProcessor>();
            processor.Process();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IProcessor, Processor>();
            services.AddSingleton<IGpuManager, GpuManager>();
            return services;
        }   


    }
}