using Newtonsoft.Json.Serialization;

namespace NeoPoc.Write
{
    public class PreserveCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName;
        }
    }
}