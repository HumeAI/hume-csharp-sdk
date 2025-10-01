using System.Text.Json;
using System.Text.Json.Serialization;
using Hume;
using Hume.Core;

namespace Hume.EmpathicVoice;

[Serializable]
public record Context : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The context to be injected into the conversation. Helps inform the LLM's response by providing relevant information about the ongoing conversation.
    ///
    /// This text will be appended to the end of [user_messages](/reference/speech-to-speech-evi/chat#receive.UserMessage.message.content) based on the chosen persistence level. For example, if you want to remind EVI of its role as a helpful weather assistant, the context you insert will be appended to the end of user messages as `{Context: You are a helpful weather assistant}`.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    /// <summary>
    /// The persistence level of the injected context. Specifies how long the injected context will remain active in the session.
    ///
    /// - **Temporary**: Context that is only applied to the following assistant response.
    ///
    /// - **Persistent**: Context that is applied to all subsequent assistant responses for the remainder of the Chat.
    /// </summary>
    [JsonPropertyName("type")]
    public ContextType? Type { get; set; }

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
