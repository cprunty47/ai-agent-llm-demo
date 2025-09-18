using System;

namespace MyConsoleApp
{
    public class Processor : IProcessor
    {
        public void Process()
        {
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

                string response = GenerateResponse(userInput);
                Console.WriteLine($"AI: {response}");
            }

        }
        
        static string GenerateResponse(string input)
        {
            // Simple response logic (can be expanded)
            if (string.IsNullOrWhiteSpace(input))
            {
                return "I'm here! Feel free to ask me anything.";
            }
            else if (input.Contains("hello", StringComparison.OrdinalIgnoreCase))
            {
                return "Hello! How can I assist you today?";
            }
            else
            {
                return "That's interesting! Tell me more.";
            }
        }        
    }
}