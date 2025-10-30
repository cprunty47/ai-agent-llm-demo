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
            else if (input.Contains("is it necessary for clean code in order for all your functions to be 3 lines long", StringComparison.OrdinalIgnoreCase))
            {
                return "When reviewing smaller code, it can be deemed as more organized. When your excuse is you don't have time to make it smaller and more organized then your functions probably have too many lines of code.";
            }
            else if (input.Contains("do you recommend two line functions", StringComparison.OrdinalIgnoreCase))
            {
                return "I like small functions having between 2-6 lines of code.";
            }
            else if (input.Contains("when is a function too small", StringComparison.OrdinalIgnoreCase))
            {
                return "When a function is too small, it typically means the function doesn't provide meaningful value - for example, when it just calls the next function in line without adding any logic, validation, or abstraction.";
            }
            else
            {
                return "That's interesting! Tell me more.";
            }
        }        
    }
}