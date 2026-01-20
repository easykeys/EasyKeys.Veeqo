using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyKeys.Veeqo.Abstractions.Serialization;

public sealed class SingleOrArrayJsonConverter<TItem> : JsonConverter<List<TItem>>
{
    public override List<TItem> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return [];
        }

        if (reader.TokenType == JsonTokenType.StartArray)
        {
            var list = JsonSerializer.Deserialize<List<TItem>>(ref reader, options);
            return list ?? [];
        }

        var item = JsonSerializer.Deserialize<TItem>(ref reader, options);
        return item is null ? [] : [item];
    }

    public override void Write(Utf8JsonWriter writer, List<TItem> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}
