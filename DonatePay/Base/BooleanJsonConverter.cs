using Newtonsoft.Json;

namespace DonatePay.Base
{
    internal class BooleanJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(String) || objectType == typeof(Boolean)) return true;
            else return false;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            if (value == null || String.IsNullOrWhiteSpace(value.ToString()))
            {
                return null;
            }

            if (value.ToString() == "1") return true;
            else return false;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString());
        }
    }
}
