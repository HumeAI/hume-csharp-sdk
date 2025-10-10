using System.Text.Json;
using System.Text.Json.Serialization;
using Hume;
using Hume.Core;
using OneOf;

namespace Hume.Tts;

[Serializable]
public record PostedTts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Utterances to use as context for generating consistent speech style and prosody across multiple requests. These will not be converted to speech output.
    /// </summary>
    [JsonPropertyName("context")]
    public OneOf<PostedContextWithGenerationId, PostedContextWithUtterances>? Context { get; set; }

    /// <summary>
    /// Specifies the output audio file format.
    /// </summary>
    [JsonPropertyName("format")]
    public OneOf<FormatMp3, FormatPcm, FormatWav>? Format { get; set; }

    /// <summary>
    /// The set of timestamp types to include in the response.
    /// </summary>
    [JsonPropertyName("include_timestamp_types")]
    public IEnumerable<TimestampType>? IncludeTimestampTypes { get; set; }

    /// <summary>
    /// Number of generations of the audio to produce.
    /// </summary>
    [JsonPropertyName("num_generations")]
    public int? NumGenerations { get; set; }

    /// <summary>
    /// Controls how audio output is segmented in the response.
    ///
    /// - When **enabled** (`true`), input utterances are automatically split into natural-sounding speech segments.
    ///
    /// - When **disabled** (`false`), the response maintains a strict one-to-one mapping between input utterances and output snippets.
    ///
    /// This setting affects how the `snippets` array is structured in the response, which may be important for applications that need to track the relationship between input text and generated audio segments. When setting to `false`, avoid including utterances with long `text`, as this can result in distorted output.
    /// </summary>
    [JsonPropertyName("split_utterances")]
    public bool? SplitUtterances { get; set; }

    /// <summary>
    /// If enabled, the audio for all the chunks of a generation, once concatenated together, will constitute a single audio file. Otherwise, if disabled, each chunk's audio will be its own audio file, each with its own headers (if applicable).
    /// </summary>
    [JsonPropertyName("strip_headers")]
    public bool? StripHeaders { get; set; }

    /// <summary>
    /// A list of **Utterances** to be converted to speech output.
    ///
    /// An **Utterance** is a unit of input for [Octave](/docs/text-to-speech-tts/overview), and includes input `text`, an optional `description` to serve as the prompt for how the speech should be delivered, an optional `voice` specification, and additional controls to guide delivery for `speed` and `trailing_silence`.
    /// </summary>
    [JsonPropertyName("utterances")]
    public IEnumerable<PostedUtterance> Utterances { get; set; } = new List<PostedUtterance>();

    /// <summary>
    /// The version of the Octave Model to use. 1 for the legacy model, 2 for the new model.
    /// </summary>
    [JsonPropertyName("version")]
    public OctaveVersion? Version { get; set; }

    /// <summary>
    /// Enables ultra-low latency streaming, significantly reducing the time until the first audio chunk is received. Recommended for real-time applications requiring immediate audio playback. For further details, see our documentation on [instant mode](/docs/text-to-speech-tts/overview#ultra-low-latency-streaming-instant-mode).
    /// - A [voice](/reference/text-to-speech-tts/synthesize-json-streaming#request.body.utterances.voice) must be specified when instant mode is enabled. Dynamic voice generation is not supported with this mode.
    /// - Instant mode is only supported for streaming endpoints (e.g., [/v0/tts/stream/json](/reference/text-to-speech-tts/synthesize-json-streaming), [/v0/tts/stream/file](/reference/text-to-speech-tts/synthesize-file-streaming)).
    /// - Ensure only a single generation is requested ([num_generations](/reference/text-to-speech-tts/synthesize-json-streaming#request.body.num_generations) must be `1` or omitted).
    /// </summary>
    [JsonPropertyName("instant_mode")]
    public bool? InstantMode { get; set; }

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
