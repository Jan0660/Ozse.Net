using Newtonsoft.Json;

namespace Ozse;

public class PubDevResult : IResult
{
    [JsonProperty("lastVersion")] public string LastVersion;
    public PubDevPackageVersion Package;
}

public class PubDevPackage
{
    public string Name;
    public PubDevPackageVersion Latest;
    public PubDevPackageVersion[] Versions;
}

public class PubDevPackageVersion
{
    public string Version;
    [JsonProperty("pubspec")] public PubDevPubSpec PubSpec;
    public string ArchiveUrl;
    public DateTime Published;
}

public class PubDevPubSpec
{
    public string Name;
    public string Description;
    public string Homepage;
    public string Version;
    public Dictionary<string, string> Environment;
    public Dictionary<string, string> Dependencies;
    public Dictionary<string, string> DevDependencies;
}