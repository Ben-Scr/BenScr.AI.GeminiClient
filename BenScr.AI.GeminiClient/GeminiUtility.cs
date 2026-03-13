using Google.GenAI;
using Google.GenAI.Types;

namespace BenScr.AI.Gemini;

public static class GeminiUtility
{
    public static string[] Models { get; } =
{
    "gemini-2.0-flash",
    "gemini-2.0-flash-001",
    "gemini-2.0-flash-lite",
    "gemini-2.0-flash-lite-001",
    "gemini-2.5-flash",
    "gemini-2.5-flash-lite",
    "gemini-2.5-pro",
    "gemini-3-flash-preview",
    "gemini-3.1-flash-lite-preview",
    "gemini-3.1-pro-preview",
};

    public static async Task<bool> ModelExistsAsync(Client client, string modelName)
    {
        try
        {
            Model model = await client.Models.GetAsync(model: modelName);
            return model != null;
        }
        catch
        {
            return false;
        }
    }

    public static List<Content> ToContentList(string input, ContentRole role = ContentRole.User)
    {
        return new List<Content>
            {
                new Content
                {
                    Role = role.AsString(),
                    Parts = new List<Part>
                    {
                        new Part
                        {
                            Text = input
                        }
                    }
                }
            };
    }

    public static string AsString(this ContentRole role) => role.ToString();
}

