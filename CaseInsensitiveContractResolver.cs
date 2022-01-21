using Newtonsoft.Json.Serialization;

namespace Ozse;

internal class CaseInsensitiveContractResolver : DefaultContractResolver
{
    protected override string ResolvePropertyName(string propertyName)
    {
        var name = string.Concat(propertyName[0].ToString().ToUpper(), propertyName.Substring(1).ToLower());
        return base.ResolvePropertyName(name);
    }
}