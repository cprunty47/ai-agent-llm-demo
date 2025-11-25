using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
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
                    return response.Content.ReadAsStringAsync().Result;
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