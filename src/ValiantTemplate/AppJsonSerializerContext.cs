using System.Text.Json.Serialization;
using ValiantTemplate.Endpoints;

namespace ValiantTemplate;

// JSON source generation is required for AOT compilation.
// See: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation
// If you don't want to deal with the hassle of source generation, you can just turn off the AOT stuff...
// But, personally, I feel that much of the appeal of this template is how well it works with AOT compilation.

[JsonSerializable(typeof(DemoResponseModel))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
