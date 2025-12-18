using System;
using System.Text.RegularExpressions;

namespace MyConsoleApp.Builders
{
    public class UncleBobProcessor : IProcessor
    {
        public string GetResponse(string input)
        {
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
            else if (Regex.IsMatch(input, @"\b(how many|how much|what.*(number|amount)).*(lines|code).*(function|method)\b", RegexOptions.IgnoreCase))
            {
                return "Functions should be very small - ideally 2-3 lines of code per function. The smaller the function, the easier it is to understand, test, and maintain.";
            }
            else if (input.Contains("do you recommend two line functions", StringComparison.OrdinalIgnoreCase))
            {
                return "I like small functions having between 2-6 lines of code.";
            }
            else if (input.Contains("when is a function too small", StringComparison.OrdinalIgnoreCase))
            {
                return "When a function is too small, it typically means the function doesn't provide meaningful value - for example, when it just calls the next function in line without adding any logic, validation, or abstraction.";
            }
            else if (input.Contains("what is bundling", StringComparison.OrdinalIgnoreCase))
            {
                return "It's a test driven development concept which relaxes the discipline and allows you to write 50-100 lines of code before you seriously do some organized unit test development.";
            }
            else if (input.Contains("AI replace my job", StringComparison.OrdinalIgnoreCase))
            {
                return "Details, details, details. AI is really good at some of them, and bad at others. Supervision is essential. You really need to know what you're doing.";
            }

            return "I'm sorry, I don't have a response for that.";
        }
    }
}