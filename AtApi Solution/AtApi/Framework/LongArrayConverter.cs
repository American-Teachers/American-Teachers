using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AtApi.Framework
{
    public class LongArrayConverter : JsonConverter<long[]>
    {
        // A custom long[] converter as comma-delimited string "1,2,3".
        public LongArrayConverter() { }

        public override long[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string json = reader.GetString();

            var list = new List<long>();

            foreach (string str in json.Split(','))
            {
                if (!long.TryParse(str, out long l))
                {
                    throw new JsonException("Too big for a long");
                }

                list.Add(l);
            }

            return list.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, long[] value, JsonSerializerOptions options)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < value.Length; i++)
            {
                builder.Append(value[i].ToString());

                if (i != value.Length - 1)
                {
                    builder.Append(",");
                }
            }

            writer.WriteStringValue(builder.ToString());
        }
    }

}