
using System;
using System.Net.Http;
using System.Threading.Tasks;

class ApiCaller
{
    static async Task Main(string[] args)
    {
        string url = "https://localhost:7062/api/people/all ";

        using (HttpClient client = new HttpClient())
        {
            
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("API Response: " + responseBody);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }
    }
}