
using BenScr.AI.Gemini;
using Google.GenAI.Types;

public static class Program
{
    public static async Task Main(string[] args)
    {
        string apiKey = null;
        string model = null;

        if (args.Length > 0)
            apiKey = args[0];
        if (args.Length > 1)
            model = args[1];

        if (apiKey == null)
        {
            GeminiApiKey geminiApiKey = GeminiApiKey.LoadFromEnvironment();
            apiKey = geminiApiKey.Key;
        }

        model ??= GeminiUtility.Models[0];

        GeminiClient client = new GeminiClient(apiKey, model);

        Console.Write("User: ");
        string input = Console.ReadLine();

        GenerateContentResponse response = await client.RequestResponseAsync(input);
        Console.WriteLine(client.Model + ": " + response.Text);
    }
}