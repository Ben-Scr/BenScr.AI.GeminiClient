using Google.GenAI;
using Google.GenAI.Types;

namespace BenScr.AI.Gemini;

using static GeminiUtility;

public class GeminiClient
{
    public Client Client { get; private set; }
    public string Model { get; private set; }

    public GeminiClient(string apiKey, string model)
    {
        Client = new Client(apiKey: apiKey);
        Model = model;
    }

    public async Task SetModelAsync(string model)
    {
        if (!await ModelExistsAsync(Client, model))
            throw new Exception($"Model doesn't exist: \"{model}\"");

        Model = model;
    }

    public async Task<bool> TrySetModelAsync(string model)
    {
        try
        {
            await SetModelAsync(model);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<GenerateContentResponse> RequestAsync(List<Content> contents)
    {
        if (contents == null || contents.Count == 0)
            throw new ArgumentNullException("Contents can't be null or empty");


        if (!await ModelExistsAsync(Client, Model))
            throw new ArgumentException($"Model doesn't exist: \"{Model}\"");

        GenerateContentResponse response = await Client.Models.GenerateContentAsync(model: Model, contents: contents);
        return response;
    }

    public async Task<GenerateContentResponse> RequestAsync(string contents)
        => await RequestAsync(ToContentList(contents, ContentRole.User));

    public async Task<(bool Success, GenerateContentResponse? Response, Exception Exception)> TryRequestAsync(List<Content> contents)
    {
        try
        {
           return (true, await RequestAsync(contents), null);
        }
        catch(Exception ex)
        {
            return (false, null, ex);
        }
    }
}

