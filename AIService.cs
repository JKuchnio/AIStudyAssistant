using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class AIService
{
    private readonly HttpClient client = new HttpClient();

    public async Task<string> Generate(string text)
    {
        string prompt = $"Summarize this text and generate 5 questions:\n{text}";

        var json = $@"{{
            ""model"": ""gpt-4.1-mini"",
            ""messages"": [
                {{ ""role"": ""user"", ""content"": ""{prompt}"" }}
            ]
        }}";

        var request = new HttpRequestMessage(HttpMethod.Post,
            "https://api.openai.com/v1/chat/completions");

        request.Headers.Add("Authorization", "Bearer YOUR_API_KEY");
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}