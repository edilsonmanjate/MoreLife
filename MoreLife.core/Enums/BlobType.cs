using System.Text.Json.Serialization;

namespace MoreLife.core.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BloodType
{
    A,
    B,
    AB,
    O
}
