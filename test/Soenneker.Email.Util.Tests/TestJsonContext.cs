using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.Messages.Base;

namespace Soenneker.Email.Util.Tests;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    ReadCommentHandling = JsonCommentHandling.Skip, UseStringEnumConverter = true)]
[JsonSerializable(typeof(Message))]
internal partial class TestJsonContext : JsonSerializerContext
{
}
