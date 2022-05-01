using Newtonsoft.Json;

namespace Ozse.Results;

public class NpmResult : IResult
{
    [JsonProperty("previousVersion")] public string PreviousVersion { get; set; }
    [JsonProperty("package")] public NpmPackageVersion Package { get; set; }
    [JsonProperty("previous")] public NpmPackageVersion Previous { get; set; }
}

// public class NpmFullSearchResult
// {
//     public NpmSearchResult[] objects;
//     public int total;
//     public string time;
// }
//
// public class NpmsSearchResult
// {
//     public NpmPackage package;
// }
public class NpmSearchResult
{
    public NpmPackage Package;
}

public class NpmPackage
{
    public string Name;
    [JsonProperty("dist-tags")] public NpmDistTags DistTags;
    public string Description;
    public string[] Keywords;
    public string Scope;
    public string Date;
    public string Version;
    public NpmPackageLinks Links = new();
    public NpmPackageAuthor Author;
    public NpmPackagePublisher Publisher;
    public NpmPackagePublisher[] Maintainers;
}

public class NpmPackageAuthor
{
    public string Name;
}

public class NpmPackagePublisher
{
    public string Username;
    public string Email;
}

public class NpmPackageLinks
{
    public string Npm;
    public string Homepage;
    public string Repository;
    public string Bugs;
}

public class NpmPackageMetadata
{
    [JsonProperty("_id")] public string Id;
    [JsonProperty("_rev")] public string Rev;
    public string Name;
    [JsonProperty("dist-tags")] public NpmDistTags DistTags;
    public Dictionary<string, NpmPackageVersion> Versions;
    public Dictionary<string, string> Time;

    // [JsonIgnore]
    // public Dictionary<string, DateTime> Times
    // {
    //     get
    //     {
    //         var res = new Dictionary<string, DateTime>();
    //         CultureInfo provider = CultureInfo.InvariantCulture;
    //         foreach (var timeKey in time)
    //         {
    //             res.Add(timeKey.Key, DateTime.ParseExact(timeKey.Value, "yyyy-MM-ddTHH:mm:ss.fffZ", provider));
    //         }
    //
    //         return res;
    //     }
    // }
    public NpmHuman[] Maintainers;
    public string Description;
    public string Homepage;
    public string[] Keywords;
    public NpmRepository Repository;
    public NpmPackageAuthor Author;
    public NpmBugs Bugs;
    public string License;
    public string Readme;
    public string ReadmeFilename;
}

public class NpmPackageVersion
{
    public string Name;
    public string Version;
    public string Description;
    public string Main;
    public NpmPackageAuthor Author;
    public string[] Keywords;
    public string License;
    public NpmRepository Repository;
    [JsonProperty("private")] public bool Private;

    public Dictionary<string, string> Scripts;
    public Dictionary<string, string> Dependencies;
    public string GitHead;
    public NpmBugs Bugs;
    public string Homepage;
    [JsonProperty("_id")] public string Id;
    [JsonProperty("_nodeVersion")] public string NodeVersion;
    [JsonProperty("_npmVersion")] public string NpmVersion;
    public NpmDist Dist;
    public NpmHuman[] Maintainers;

    [JsonProperty("_npmUser")] public NpmHuman NpmUser;
    // directories
    // _npmOperationalInternal
    // _hasShrinkwrap
}

public class NpmDist
{
    public string Integrity;
    [JsonProperty("shasum")] public string ShaSum;
    public string Tarball;
    public int FileCount;
    public int UnpackedSize;
    [JsonProperty("npm-signature")] public string NpmSignature;
}

public class NpmBugs
{
    public string Url;
}

public class NpmRepository
{
    public string Url;
    public string Type;
}

public class NpmHuman
{
    public string Name;
    public string Email;
}

public class NpmDistTags
{
    public string Latest;
}