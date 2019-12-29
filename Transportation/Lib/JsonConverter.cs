using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Transportation
{
  public class TransportConverter : JsonConverter<Transport>
  {
    public override Transport Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Transport value, JsonSerializerOptions options)
    {
      JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
  }

  public class TicketConverter : JsonConverter<Ticket>
  {
    public override Ticket Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      Ticket ticket = new Ticket();
      Type transportType = null;

      while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
      {
        string propertyName = reader.GetString();
        object propertyValue = null;

        if (propertyName == "Transport")
        {
          propertyValue = JsonSerializer.Deserialize(ref reader, transportType, options);
        }
        else
        {
          propertyValue = JsonSerializer.Deserialize<String>(ref reader, options);
          if (propertyName == "TransportType")
          {
            transportType = Type.GetType((string)propertyValue);
          }
        }

        PropertyInfo prop = ticket.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (null != prop && prop.CanWrite)
        {
          prop.SetValue(ticket, propertyValue, null);
        }
      }
      return ticket;
    }

    public override void Write(Utf8JsonWriter writer, Ticket value, JsonSerializerOptions options)
    {
      throw new NotImplementedException();
      // JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
  }

}