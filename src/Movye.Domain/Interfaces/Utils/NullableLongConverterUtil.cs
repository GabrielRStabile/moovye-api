using Newtonsoft.Json;

namespace Movye.Domain.Interfaces.Utils
{
    public class NullableLongConverterUtil : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(long?);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                return (long)reader.Value;
            }

            throw new JsonSerializationException(
                $"Unexpected token type '{reader.TokenType}' when parsing nullable long."
            );
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value);
            }
        }
    }
}
