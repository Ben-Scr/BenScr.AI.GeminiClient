using DotNetEnv;

namespace BenScr.AI.Gemini;

public sealed class GeminiApiKey
{
    public string Key { get; }

    private GeminiApiKey(string apiKey)
    {
        Key = apiKey;
    }

    public static GeminiApiKey LoadFromEnvironment()
    {
        Env.Load();

        string? apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException(
                "Required environment variable 'GEMINI_API_KEY' is missing.");

        return new GeminiApiKey(apiKey);
    }
}