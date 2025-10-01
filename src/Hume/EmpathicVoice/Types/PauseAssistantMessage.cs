using System.Text.Json;
using System.Text.Json.Serialization;
using Hume;
using Hume.Core;

namespace Hume.EmpathicVoice;

/// <summary>
/// Pause responses from EVI. Chat history is still saved and sent after resuming.
/// </summary>
[Serializable]
public record PauseAssistantMessage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Used to manage conversational state, correlate frontend and backend data, and persist conversations across EVI sessions.
    /// </summary>
    [JsonPropertyName("custom_session_id")]
    public string? CustomSessionId { get; set; }

    /// <summary>
    /// The type of message sent through the socket; must be `pause_assistant_message` for our server to correctly identify and process it as a Pause Assistant message.
    ///
    /// Once this message is sent, EVI will not respond until a [Resume Assistant message](/reference/speech-to-speech-evi/chat#send.ResumeAssistantMessage) is sent. When paused, EVI won't respond, but transcriptions of your audio inputs will still be recorded.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "pause_assistant_message";

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
