namespace Ozse.Results;

public class TwitchResult : IResult
{
    /// <summary>
    /// "goOnline" or "goOffline"
    /// </summary>
    public string Type { get; set; }

    public TwitchResultStream Item { get; set; }
}

public class TwitchResultStream
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string UserLogin { get; set; }
    public string UserName { get; set; }
    public string GameId { get; set; }
    public string GameName { get; set; }
    public string TagIds { get; set; }
    public string IsMature { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }

    public int ViewerCount { get; set; }

    // time.Time started_at
    public DateTime StartedAt { get; set; }
    public string Language { get; set; }
    public string ThumbnailUrl { get; set; }
}