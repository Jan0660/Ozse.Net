namespace Ozse.Results;

public class YouTubeResult : IResult
{
    public string Etag { get; set; }
    public YouTubeResultResourceId Id { get; set; }

    public string Kind { get; set; }
    // no snippet yet
}

public class YouTubeResultResourceId
{
    public string Kind { get; set; }
    public string? VideoId { get; set; }
    public string? ChannelId { get; set; }
    public string? PlaylistId { get; set; }
}