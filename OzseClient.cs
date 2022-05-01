using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Ozse.Results;
using BclJsonSerializer = System.Text.Json.JsonSerializer;

namespace Ozse;

public class OzseClient
{
    public string Url { get; }
    public HttpClient Http { get; }

    private static readonly JsonSerializerSettings JsonOptions = new()
    {
        ContractResolver = new CaseInsensitiveContractResolver()
    };

    public OzseClient(string url)
    {
        Url = url;
        Http = new()
        {
            BaseAddress = new Uri(Url)
        };
    }

    public async Task<Job> CreateJobAsync(Job job)
    {
        var mem = new MemoryStream();
        await BclJsonSerializer.SerializeAsync(mem, job);
        mem.Position = 0;
        var res = await Http.PostAsync("/jobs/new", new StreamContent(mem));
        return (JsonConvert.DeserializeObject<Job>(await res.Content.ReadAsStringAsync(), JsonOptions))!;
    }

    public Task<Result[]> GetResultsAsync()
        => _getAsync<Result[]>("/results");

    public Task<Job> GetJobAsync(string id)
        => _getAsync<Job>($"/jobs/get/{id}");

    public Task DeleteResultAsync(string id)
        => Http.DeleteAsync($"/results/{id}");

    private async Task<T> _getAsync<T>(string path)
    {
        var res = await Http.GetAsync(path);
        return (JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync(), JsonOptions))!;
    }
}

public class Job
{
    [JsonPropertyName("_id")]
    [JsonProperty("_id")]
    public string Id { get; set; }

    public string Name { get; set; }
    public uint Timer { get; set; }
    public bool AllowTaskDuplicates { get; set; }
    public Dictionary<string, object> Data { get; set; }
}

public class Result
{
    [JsonProperty("_id")] public string Id { get; set; }
    public string TaskId { get; set; }
    public string JobId { get; set; }
    public string JobName { get; set; }
    public JObject Data { get; set; }

    private static JsonSerializer _snakeCaseSerializer = new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };

    private static JsonSerializer _camelCaseSerializer = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };

    public IResult? ParseData()
    {
        switch (JobName)
        {
            case "github":
                return Data.ToObject<GitHubReleaseResult>()!;
            case "npm":
                return Data.ToObject<NpmResult>(_camelCaseSerializer)!;
            case "pubdev":
                return Data.ToObject<PubDevResult>(_snakeCaseSerializer)!;
            case "reddit":
                return Data.ToObject<RedditResult>()!;
            case "twitter":
                return Data.ToObject<TwitterResult>()!;
            case "youtube":
                return Data.ToObject<YouTubeResult>(_camelCaseSerializer)!;
            case "twitch":
                return Data.ToObject<TwitchResult>()!;
        }

        return null;
    }
}

public interface IResult
{
}