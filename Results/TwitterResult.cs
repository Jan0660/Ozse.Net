using Newtonsoft.Json;

namespace Ozse.Results;

public class TwitterResult : IResult
{
    [JsonProperty("tweet")] public Tweet Tweet { get; set; }
}

public class Tweet
{
    public string[] Hastags { get; set; }

    // HTML
    [JsonProperty("ID")] public string Id { get; set; }
    public Tweet InReplyToStatus { get; set; }
    public bool IsQuoted { get; set; }
    public bool IsPin { get; set; }
    public bool IsReply { get; set; }
    public bool IsRetweet { get; set; }
    public int Likes { get; set; }
    [JsonProperty("PermanentURL")] public string PermanentUrl { get; set; }

    public string[]? Photos { get; set; }

    // Place
    public Tweet QuotedStatus { get; set; }
    public int Replies { get; set; }
    public int Retweets { get; set; }
    public Tweet RetweetedStatus { get; set; }

    public string Text { get; set; }

    // TimeParsed?
    public long Timestamp { get; set; }
    [JsonProperty("URLs")] public string[] Urls { get; set; }
    [JsonProperty("UserID")] public string UserId { get; set; }

    public string UserName { get; set; }
    // Videos
}