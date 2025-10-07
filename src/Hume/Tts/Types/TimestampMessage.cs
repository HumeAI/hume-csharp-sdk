using System.Text.Json;
using System.Text.Json.Serialization;
using Hume;
using Hume.Core;

namespace Hume.Tts;

/// <summary>
/// A word or phoneme level timestamp for the generated audio.
/// </summary>
[Serializable]
public record TimestampMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The generation ID of the parent snippet that this chunk corresponds to.
    /// </summary>
    [JsonPropertyName("generation_id")]
    public required string GenerationId { get; set; }

    /// <summary>
    /// ID of the initiating request.
    /// </summary>
    [JsonPropertyName("request_id")]
    public required string RequestId { get; set; }

    /// <summary>
    /// The ID of the parent snippet that this chunk corresponds to.
    /// </summary>
    [JsonPropertyName("snippet_id")]
    public required string SnippetId { get; set; }

    /// <summary>
    /// A word or phoneme level timestamp for the generated audio.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required Timestamp Timestamp { get; set; }

    [JsonPropertyName("type")]
    public string Type
    {
        get => "timestamp";
        set => value.Assert(value == "timestamp", "'Type' must be " + "timestamp");
    }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
