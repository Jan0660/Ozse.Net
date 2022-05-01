namespace Ozse.Results;

public class RedditResult : IResult
{
    public string Content { get; set; }
    public string ContentText { get; set; }
    public string ContentUrl { get; set; }
    public string Id { get; set; }
    public bool Nsfw { get; set; }
    public string Published { get; set; }
    public string Updated { get; set; }
    public bool Spoiler { get; set; }
    public string Author { get; set; }
    public string Link { get; set; }
    public string Title { get; set; }
    public string SubredditName { get; set; }
}