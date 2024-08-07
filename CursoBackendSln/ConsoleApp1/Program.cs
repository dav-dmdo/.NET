// See https://aka.ms/new-console-template for more information

using System;
using System.Net.Http;
using System.Threading.Tasks;

string url = "https://localhost:7062/api/people/all";
Console.WriteLine(url);
HttpClient client = new();
try
{
    var response = await client.GetAsync(url);
    var body = response.Content.ReadAsStringAsync();
    System.Console.WriteLine("Response body: "+body);
}
catch (System.Exception e)
{
    
    System.Console.WriteLine(e);
}



// using (HttpClient client = new HttpClient())
// {
    
//     HttpResponseMessage response = await client.GetAsync(url);

//     if (response.IsSuccessStatusCode)
//     {
//         string responseBody = await response.Content.ReadAsStringAsync();
//         Console.WriteLine("API Response: " + responseBody);
//     }
//     else
//     {
//         Console.WriteLine("Error: " + response.StatusCode);
//     }
// }