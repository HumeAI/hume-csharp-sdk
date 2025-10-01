using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using Hume.Core;
using Hume.Core.Async;
using Hume.Core.Async.Events;
using Hume.Core.Async.Models;
using OneOf;

namespace Hume.EmpathicVoice;

public partial class ChatApi : AsyncApi<ChatApi.Options>
{
    public readonly Event<AssistantEnd> AssistantEnd = new();

    public readonly Event<AssistantMessage> AssistantMessage = new();

    public readonly Event<AssistantProsody> AssistantProsody = new();

    public readonly Event<AudioOutput> AudioOutput = new();

    public readonly Event<ChatMetadata> ChatMetadata = new();

    public readonly Event<WebSocketError> WebSocketError = new();

    public readonly Event<UserInterruption> UserInterruption = new();

    public readonly Event<UserMessage> UserMessage = new();

    public readonly Event<ToolCallMessage> ToolCallMessage = new();

    public readonly Event<ToolResponseMessage> ToolResponseMessage = new();

    public readonly Event<ToolErrorMessage> ToolErrorMessage = new();

    /// <summary>
    /// Default constructor
    /// </summary>
    public ChatApi()
        : this(new ChatApi.Options()) { }

    /// <summary>
    /// Constructor with options
    /// </summary>
    public ChatApi(ChatApi.Options options)
        : base(options) { }

    /// <summary>
    /// Access token used for authenticating the client. If not provided, an `api_key` must be provided to authenticate.
    ///
    /// The access token is generated using both an API key and a Secret key, which provides an additional layer of security compared to using just an API key.
    ///
    /// For more details, refer to the [Authentication Strategies Guide](/docs/introduction/api-key#authentication-strategies).
    /// </summary>
    public string? AccessToken
    {
        get => ApiOptions.AccessToken;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.AccessToken),
                ApiOptions.AccessToken = value
            );
    }

    /// <summary>
    /// The unique identifier for an EVI configuration.
    ///
    /// Include this ID in your connection request to equip EVI with the Prompt, Language Model, Voice, and Tools associated with the specified configuration. If omitted, EVI will apply [default configuration settings](/docs/speech-to-speech-evi/configuration/build-a-configuration#default-configuration).
    ///
    /// For help obtaining this ID, see our [Configuration Guide](/docs/speech-to-speech-evi/configuration).
    /// </summary>
    public string? ConfigId
    {
        get => ApiOptions.ConfigId;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.ConfigId),
                ApiOptions.ConfigId = value
            );
    }

    /// <summary>
    /// The version number of the EVI configuration specified by the `config_id`.
    ///
    /// Configs, as well as Prompts and Tools, are versioned. This versioning system supports iterative development, allowing you to progressively refine configurations and revert to previous versions if needed.
    ///
    /// Include this parameter to apply a specific version of an EVI configuration. If omitted, the latest version will be applied.
    /// </summary>
    public int? ConfigVersion
    {
        get => ApiOptions.ConfigVersion;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.ConfigVersion),
                ApiOptions.ConfigVersion = value
            );
    }

    /// <summary>
    /// The maximum number of chat events to return from chat history. By default, the system returns up to 300 events (100 events per page × 3 pages). Set this parameter to a smaller value to limit the number of events returned.
    /// </summary>
    public int? EventLimit
    {
        get => ApiOptions.EventLimit;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.EventLimit),
                ApiOptions.EventLimit = value
            );
    }

    /// <summary>
    /// The unique identifier for a Chat Group. Use this field to preserve context from a previous Chat session.
    ///
    /// A Chat represents a single session from opening to closing a WebSocket connection. In contrast, a Chat Group is a series of resumed Chats that collectively represent a single conversation spanning multiple sessions. Each Chat includes a Chat Group ID, which is used to preserve the context of previous Chat sessions when starting a new one.
    ///
    /// Including the Chat Group ID in the `resumed_chat_group_id` query parameter is useful for seamlessly resuming a Chat after unexpected network disconnections and for picking up conversations exactly where you left off at a later time. This ensures preserved context across multiple sessions.
    ///
    /// There are three ways to obtain the Chat Group ID:
    ///
    /// - [Chat Metadata](/reference/speech-to-speech-evi/chat#receive.ChatMetadata): Upon establishing a WebSocket connection with EVI, the user receives a Chat Metadata message. This message contains a `chat_group_id`, which can be used to resume conversations within this chat group in future sessions.
    ///
    /// - [List Chats endpoint](/reference/speech-to-speech-evi/chats/list-chats): Use the GET `/v0/evi/chats` endpoint to obtain the Chat Group ID of individual Chat sessions. This endpoint lists all available Chat sessions and their associated Chat Group ID.
    ///
    /// - [List Chat Groups endpoint](/reference/speech-to-speech-evi/chat-groups/list-chat-groups): Use the GET `/v0/evi/chat_groups` endpoint to obtain the Chat Group IDs of all Chat Groups associated with an API key. This endpoint returns a list of all available chat groups.
    /// </summary>
    public string? ResumedChatGroupId
    {
        get => ApiOptions.ResumedChatGroupId;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.ResumedChatGroupId),
                ApiOptions.ResumedChatGroupId = value
            );
    }

    public int? SessionSettingsAudioChannels
    {
        get => ApiOptions.SessionSettingsAudioChannels;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsAudioChannels),
                ApiOptions.SessionSettingsAudioChannels = value
            );
    }

    public string? SessionSettingsAudioEncoding
    {
        get => ApiOptions.SessionSettingsAudioEncoding;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsAudioEncoding),
                ApiOptions.SessionSettingsAudioEncoding = value
            );
    }

    public int? SessionSettingsAudioSampleRate
    {
        get => ApiOptions.SessionSettingsAudioSampleRate;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsAudioSampleRate),
                ApiOptions.SessionSettingsAudioSampleRate = value
            );
    }

    public string? SessionSettingsContextText
    {
        get => ApiOptions.SessionSettingsContextText;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsContextText),
                ApiOptions.SessionSettingsContextText = value
            );
    }

    public string? SessionSettingsContextType
    {
        get => ApiOptions.SessionSettingsContextType;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsContextType),
                ApiOptions.SessionSettingsContextType = value
            );
    }

    public string? SessionSettingsCustomSessionId
    {
        get => ApiOptions.SessionSettingsCustomSessionId;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsCustomSessionId),
                ApiOptions.SessionSettingsCustomSessionId = value
            );
    }

    public int? SessionSettingsEventLimit
    {
        get => ApiOptions.SessionSettingsEventLimit;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsEventLimit),
                ApiOptions.SessionSettingsEventLimit = value
            );
    }

    public string? SessionSettingsLanguageModelApiKey
    {
        get => ApiOptions.SessionSettingsLanguageModelApiKey;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(
                    ApiOptions.SessionSettingsLanguageModelApiKey
                ),
                ApiOptions.SessionSettingsLanguageModelApiKey = value
            );
    }

    public string? SessionSettingsSystemPrompt
    {
        get => ApiOptions.SessionSettingsSystemPrompt;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsSystemPrompt),
                ApiOptions.SessionSettingsSystemPrompt = value
            );
    }

    public string? SessionSettingsVariables
    {
        get => ApiOptions.SessionSettingsVariables;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsVariables),
                ApiOptions.SessionSettingsVariables = value
            );
    }

    public string? SessionSettingsVoiceId
    {
        get => ApiOptions.SessionSettingsVoiceId;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.SessionSettingsVoiceId),
                ApiOptions.SessionSettingsVoiceId = value
            );
    }

    /// <summary>
    /// A flag to enable verbose transcription. Set this query parameter to `true` to have unfinalized user transcripts be sent to the client as interim UserMessage messages. The [interim](/reference/speech-to-speech-evi/chat#receive.UserMessage.interim) field on a [UserMessage](/reference/speech-to-speech-evi/chat#receive.UserMessage) denotes whether the message is "interim" or "final."
    /// </summary>
    public bool? VerboseTranscription
    {
        get => ApiOptions.VerboseTranscription;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.VerboseTranscription),
                ApiOptions.VerboseTranscription = value
            );
    }

    /// <summary>
    /// The name or ID of the voice from the `Voice Library` to be used as the speaker for this EVI session. This will override the speaker set in the selected configuration.
    /// </summary>
    public string? VoiceId
    {
        get => ApiOptions.VoiceId;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.VoiceId),
                ApiOptions.VoiceId = value
            );
    }

    /// <summary>
    /// API key used for authenticating the client. If not provided, an `access_token` must be provided to authenticate.
    ///
    /// For more details, refer to the [Authentication Strategies Guide](/docs/introduction/api-key#authentication-strategies).
    /// </summary>
    public string? ApiKey
    {
        get => ApiOptions.ApiKey;
        set =>
            NotifyIfPropertyChanged(
                EqualityComparer<string>.Default.Equals(ApiOptions.ApiKey),
                ApiOptions.ApiKey = value
            );
    }

    protected override Uri CreateUri()
    {
        return new UriBuilder(BaseUrl.TrimEnd('/') + "/chat")
        {
            Query = new Query()
            {
                { "access_token", AccessToken },
                { "config_id", ConfigId },
                { "config_version", ConfigVersion },
                { "event_limit", EventLimit },
                { "resumed_chat_group_id", ResumedChatGroupId },
                { "session_settings[audio][channels]", SessionSettingsAudioChannels },
                { "session_settings[audio][encoding]", SessionSettingsAudioEncoding },
                { "session_settings[audio][sample_rate]", SessionSettingsAudioSampleRate },
                { "session_settings[context][text]", SessionSettingsContextText },
                { "session_settings[context][type]", SessionSettingsContextType },
                { "session_settings[custom_session_id]", SessionSettingsCustomSessionId },
                { "session_settings[event_limit]", SessionSettingsEventLimit },
                { "session_settings[language_model_api_key]", SessionSettingsLanguageModelApiKey },
                { "session_settings[system_prompt]", SessionSettingsSystemPrompt },
                { "session_settings[variables]", SessionSettingsVariables },
                { "session_settings[voice_id]", SessionSettingsVoiceId },
                { "verbose_transcription", VerboseTranscription },
                { "voice_id", VoiceId },
                { "api_key", ApiKey },
            },
        }.Uri;
    }

    protected override void SetConnectionOptions(ClientWebSocketOptions options) { }

    protected override async System.Threading.Tasks.Task OnTextMessage(Stream stream)
    {
        var json = await JsonSerializer.DeserializeAsync<JsonDocument>(stream);
        if (json == null)
        {
            await ExceptionOccurred
                .RaiseEvent(new Exception("Invalid message - Not valid JSON"))
                .ConfigureAwait(false);
            return;
        }

        // deserialize the message to find the correct event

        try
        {
            var message = json.Deserialize<AssistantEnd>();
            if (message != null)
            {
                await AssistantEnd.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not AssistantEnd, continue
        }

        try
        {
            var message = json.Deserialize<AssistantMessage>();
            if (message != null)
            {
                await AssistantMessage.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not AssistantMessage, continue
        }

        try
        {
            var message = json.Deserialize<AssistantProsody>();
            if (message != null)
            {
                await AssistantProsody.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not AssistantProsody, continue
        }

        try
        {
            var message = json.Deserialize<AudioOutput>();
            if (message != null)
            {
                await AudioOutput.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not AudioOutput, continue
        }

        try
        {
            var message = json.Deserialize<ChatMetadata>();
            if (message != null)
            {
                await ChatMetadata.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not ChatMetadata, continue
        }

        try
        {
            var message = json.Deserialize<WebSocketError>();
            if (message != null)
            {
                await WebSocketError.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not WebSocketError, continue
        }

        try
        {
            var message = json.Deserialize<UserInterruption>();
            if (message != null)
            {
                await UserInterruption.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not UserInterruption, continue
        }

        try
        {
            var message = json.Deserialize<UserMessage>();
            if (message != null)
            {
                await UserMessage.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not UserMessage, continue
        }

        try
        {
            var message = json.Deserialize<ToolCallMessage>();
            if (message != null)
            {
                await ToolCallMessage.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not ToolCallMessage, continue
        }

        try
        {
            var message = json.Deserialize<ToolResponseMessage>();
            if (message != null)
            {
                await ToolResponseMessage.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not ToolResponseMessage, continue
        }

        try
        {
            var message = json.Deserialize<ToolErrorMessage>();
            if (message != null)
            {
                await ToolErrorMessage.RaiseEvent(message).ConfigureAwait(false);
                return;
            }
        }
        catch (Exception)
        {
            // message is not ToolErrorMessage, continue
        }

        await ExceptionOccurred
            .RaiseEvent(new Exception($"Unknown message: {json.ToString()}"))
            .ConfigureAwait(false);
    }

    protected override void DisposeEvents()
    {
        AssistantEnd.Dispose();
        AssistantMessage.Dispose();
        AssistantProsody.Dispose();
        AudioOutput.Dispose();
        ChatMetadata.Dispose();
        WebSocketError.Dispose();
        UserInterruption.Dispose();
        UserMessage.Dispose();
        ToolCallMessage.Dispose();
        ToolResponseMessage.Dispose();
        ToolErrorMessage.Dispose();
    }

    public async System.Threading.Tasks.Task Send(
        OneOf<
            AudioInput,
            SessionSettings,
            UserInput,
            AssistantInput,
            ToolResponseMessage,
            ToolErrorMessage,
            PauseAssistantMessage,
            ResumeAssistantMessage
        > message
    )
    {
        await SendInstant(JsonUtils.Serialize(message)).ConfigureAwait(false);
    }

    public class Options : AsyncApiOptions
    {
        /// <summary>
        /// The Websocket URL for the API connection.
        /// </summary>
        override public string BaseUrl { get; set; } = "wss://api.hume.ai/v0/evi";

        /// <summary>
        /// Access token used for authenticating the client. If not provided, an `api_key` must be provided to authenticate.
        ///
        /// The access token is generated using both an API key and a Secret key, which provides an additional layer of security compared to using just an API key.
        ///
        /// For more details, refer to the [Authentication Strategies Guide](/docs/introduction/api-key#authentication-strategies).
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// The unique identifier for an EVI configuration.
        ///
        /// Include this ID in your connection request to equip EVI with the Prompt, Language Model, Voice, and Tools associated with the specified configuration. If omitted, EVI will apply [default configuration settings](/docs/speech-to-speech-evi/configuration/build-a-configuration#default-configuration).
        ///
        /// For help obtaining this ID, see our [Configuration Guide](/docs/speech-to-speech-evi/configuration).
        /// </summary>
        public string? ConfigId { get; set; }

        /// <summary>
        /// The version number of the EVI configuration specified by the `config_id`.
        ///
        /// Configs, as well as Prompts and Tools, are versioned. This versioning system supports iterative development, allowing you to progressively refine configurations and revert to previous versions if needed.
        ///
        /// Include this parameter to apply a specific version of an EVI configuration. If omitted, the latest version will be applied.
        /// </summary>
        public int? ConfigVersion { get; set; }

        /// <summary>
        /// The maximum number of chat events to return from chat history. By default, the system returns up to 300 events (100 events per page × 3 pages). Set this parameter to a smaller value to limit the number of events returned.
        /// </summary>
        public int? EventLimit { get; set; }

        /// <summary>
        /// The unique identifier for a Chat Group. Use this field to preserve context from a previous Chat session.
        ///
        /// A Chat represents a single session from opening to closing a WebSocket connection. In contrast, a Chat Group is a series of resumed Chats that collectively represent a single conversation spanning multiple sessions. Each Chat includes a Chat Group ID, which is used to preserve the context of previous Chat sessions when starting a new one.
        ///
        /// Including the Chat Group ID in the `resumed_chat_group_id` query parameter is useful for seamlessly resuming a Chat after unexpected network disconnections and for picking up conversations exactly where you left off at a later time. This ensures preserved context across multiple sessions.
        ///
        /// There are three ways to obtain the Chat Group ID:
        ///
        /// - [Chat Metadata](/reference/speech-to-speech-evi/chat#receive.ChatMetadata): Upon establishing a WebSocket connection with EVI, the user receives a Chat Metadata message. This message contains a `chat_group_id`, which can be used to resume conversations within this chat group in future sessions.
        ///
        /// - [List Chats endpoint](/reference/speech-to-speech-evi/chats/list-chats): Use the GET `/v0/evi/chats` endpoint to obtain the Chat Group ID of individual Chat sessions. This endpoint lists all available Chat sessions and their associated Chat Group ID.
        ///
        /// - [List Chat Groups endpoint](/reference/speech-to-speech-evi/chat-groups/list-chat-groups): Use the GET `/v0/evi/chat_groups` endpoint to obtain the Chat Group IDs of all Chat Groups associated with an API key. This endpoint returns a list of all available chat groups.
        /// </summary>
        public string? ResumedChatGroupId { get; set; }

        public int? SessionSettingsAudioChannels { get; set; }

        public string? SessionSettingsAudioEncoding { get; set; }

        public int? SessionSettingsAudioSampleRate { get; set; }

        public string? SessionSettingsContextText { get; set; }

        public string? SessionSettingsContextType { get; set; }

        public string? SessionSettingsCustomSessionId { get; set; }

        public int? SessionSettingsEventLimit { get; set; }

        public string? SessionSettingsLanguageModelApiKey { get; set; }

        public string? SessionSettingsSystemPrompt { get; set; }

        public string? SessionSettingsVariables { get; set; }

        public string? SessionSettingsVoiceId { get; set; }

        /// <summary>
        /// A flag to enable verbose transcription. Set this query parameter to `true` to have unfinalized user transcripts be sent to the client as interim UserMessage messages. The [interim](/reference/speech-to-speech-evi/chat#receive.UserMessage.interim) field on a [UserMessage](/reference/speech-to-speech-evi/chat#receive.UserMessage) denotes whether the message is "interim" or "final."
        /// </summary>
        public bool? VerboseTranscription { get; set; }

        /// <summary>
        /// The name or ID of the voice from the `Voice Library` to be used as the speaker for this EVI session. This will override the speaker set in the selected configuration.
        /// </summary>
        public string? VoiceId { get; set; }

        /// <summary>
        /// API key used for authenticating the client. If not provided, an `access_token` must be provided to authenticate.
        ///
        /// For more details, refer to the [Authentication Strategies Guide](/docs/introduction/api-key#authentication-strategies).
        /// </summary>
        public string? ApiKey { get; set; }
    }
}
