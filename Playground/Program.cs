
using BenScr.AI.Gemini;
using Google.GenAI.Types;

public static class Program
{
    public static async Task Main(string[] args)
    {
        GeminiApiKey geminiApiKey = GeminiApiKey.LoadFromEnvironment();
        GeminiClient client = new GeminiClient(geminiApiKey.Key, GeminiUtility.Models[0]);

        string input = Console.ReadLine();

        GenerateContentResponse response = await client.RequestAsync(input);
        Console.WriteLine(response.Text);
    }
}