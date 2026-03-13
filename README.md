# BenScr.AI.GeminiClient
A C# library that simplifies communication between client and the Gemini API

## Setup
Follow these steps to get started after cloning the repository.

### 1. Get a Gemini API Key
Create an API key in [``Google AI Studio``](https://aistudio.google.com/api-keys)

### 2. Configure Environment Variables

Create a `.env` file containing your `GEMINI_API_KEY`.  
The file must be located in the working directory so it can be loaded by **DotNetEnv**.

Example `.env` file:

```env
GEMINI_API_KEY=YOUR_API_KEY
```
## How to use
### Include
```csharp
using BenScr.AI.Gemini
```
### Generate Response
```csharp
 GeminiClient client = new GeminiClient(apiKey, modelName);
 string input = Console.ReadLine();
 GenerateContentResponse response = await client.RequestAsync(input);
```

## Example Output
```cmd
User: Hello
gemini-2.5-flash-lite: Hello! How can I help you today?
```
