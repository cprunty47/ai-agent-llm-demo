using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyConsoleApp.Builders
{
    public class AzureProcessor : IProcessor
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public string GetResponse(string userInput)
        {
            // Call Azure Web App API
            try
            {
                string azureWebAppUrl = "https://ai-agent-jde-fgducnggfad4ayaw.centralus-01.azurewebsites.net/agent/GenerateResponse";
                var jsonContent = $@"{{
                    ""Token"": ""00000000-0000-0000-0000-000000000000"",
                    ""Prompt"": ""{userInput}""
                }}";
                var response = httpClient.PostAsync(azureWebAppUrl,   
                    new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json")).Result;
                
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    
                    // Parse JSON response to extract the actual message
                    try
                    {
                        using JsonDocument doc = JsonDocument.Parse(responseContent);
                        if (doc.RootElement.TryGetProperty("response", out JsonElement responseElement))
                        {
                            return responseElement.GetString();
                        }
                        else if (doc.RootElement.TryGetProperty("message", out JsonElement messageElement))
                        {
                            return messageElement.GetString();
                        }
                        // If no specific property found, return the raw content
                        return responseContent;
                    }
                    catch
                    {
                        // If parsing fails, return the raw response
                        return responseContent;
                    }
                }
                else
                {
                    return "Sorry, I'm having trouble connecting to the service right now.";
                }
            }
            catch (Exception ex)
            {
                return $"Error connecting to Azure service: {ex.Message}";
            }
        }

    }
}