using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        static void Print(string message, string content)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"> {message}: ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(content + "\n");

            Console.ResetColor();
        }

        static async Task _Init()
        {
            Console.Clear();
            string json = await UserAPI.GetUser();

            if (!string.IsNullOrEmpty(json))
            {
                JsonDocument jsonDoc = JsonDocument.Parse(json);
                Random random = new Random();

                string[] sexs = { "Female", "Male" };

                Print("First name", jsonDoc.RootElement.GetProperty("first_name").GetString());
                Print("Last name", jsonDoc.RootElement.GetProperty("last_name").GetString());
                Print("Sex", sexs[random.Next(0, 2)]);
                Print("Email", jsonDoc.RootElement.GetProperty("email").GetString());
                Print("Phone number", jsonDoc.RootElement.GetProperty("phone_number").GetString());
                Print("Username", jsonDoc.RootElement.GetProperty("username").GetString());
                Print("Password", jsonDoc.RootElement.GetProperty("password").GetString());

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("> Continue? (Y/N): ");

                ConsoleKeyInfo key = Console.ReadKey();
                char opt = key.KeyChar;

                if (char.ToLower(opt) == 'y')
                {
                    await _Init();
                }
            }
        }

        static async Task Main(string[] args)
        {
            await _Init();
        }
    }
}