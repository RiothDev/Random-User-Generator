using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    internal class UserAPI
    {
        public static async Task<string> GetUser()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://random-data-api.com/api/v2/users");

                    if(response.IsSuccessStatusCode)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("> Request sent successfully...");
                        Console.ResetColor();

                        string json = await response.Content.ReadAsStringAsync();
                        return json;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Status code: " + response.StatusCode);
                    Console.ResetColor();

                    return "";

                } catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("> Error: " + ex.Message);
                    Console.ResetColor();

                    return "";
                }
            }
        }
    }
}