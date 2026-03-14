using BenScr.Serialization;
using System.Text.Json.Serialization;
using Google.GenAI.Types;

namespace BenScr.AI.Gemini;



public sealed class Chat
{
    public string Topic { get; set; }

    public List<Content> History = new List<Content>();

    [JsonIgnore]
    public GeminiClient Client { get; set; }

    public Chat(GeminiClient geminiClient)
    {
        Client = geminiClient;
    }

    public void AddContent(string input, ContentRole contentRole)
    {
        History.Add(new Content
        {
            Role = contentRole.AsString(),
            Parts = new List<Part>
                {
                  new Part { Text = input }
                }
        });
    }

    public void RemoveLastContent()
    {
        if (History.Count == 0) throw new Exception("History is empty");

        History.RemoveAt(History.Count - 1);
    }

    public async Task GenerateTopic()
    {
        RangeInt rangeInt = new RangeInt(2, 5);

        GenerateContentResponse response = await Client.RequestAsync($"Write a short topic about this chat within {rangeInt} words.");
        Topic = response?.Text ?? "Topic generation failed!";
    }

    public override string ToString() => Topic;
    

    public string FromJson(bool isFormated = false)
        => Json.Serialize(this, isFormated ? Json.FormatedJson : null);
}
