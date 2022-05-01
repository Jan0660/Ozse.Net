namespace Ozse.Results;

public class GitHubReleaseResult : IResult
{
    public long Id { get; set; }
    public string TagName { get; set; }
    public string Name { get; set; }
    public string Body { get; set; }
    public string AuthorName { get; set; }
    public string AuthorAvatar { get; set; }
    public string Url { get; set; }
    public string HtmlUrl { get; set; }
    public string Tarball { get; set; }

    public string Zipball { get; set; }

    // todo: to datetimeoffset
    public long CreatedAt { get; set; }
    public long PublishedAt { get; set; }
    public Asset[] Assets { get; set; }
    public bool Prerelease { get; set; }
    public string TargetCommitish { get; set; }
    public bool Draft { get; set; }
}

public class Asset
{
    // todo
}