using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Hume;
using Hume.Core;

namespace Hume.EmpathicVoice;

public partial class ChatsClient
{
    private RawClient _client;

    internal ChatsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Fetches a paginated list of **Chats**.
    /// </summary>
    private async System.Threading.Tasks.Task<ReturnPagedChats> ListChatsInternalAsync(
        ChatsListChatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.PageNumber != null)
        {
            _query["page_number"] = request.PageNumber.Value.ToString();
        }
        if (request.PageSize != null)
        {
            _query["page_size"] = request.PageSize.Value.ToString();
        }
        if (request.AscendingOrder != null)
        {
            _query["ascending_order"] = JsonUtils.Serialize(request.AscendingOrder.Value);
        }
        if (request.ConfigId != null)
        {
            _query["config_id"] = request.ConfigId;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v0/evi/chats",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ReturnPagedChats>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new HumeClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new HumeClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Fetches a paginated list of **Chat** events.
    /// </summary>
    private async System.Threading.Tasks.Task<ReturnChatPagedEvents> ListChatEventsInternalAsync(
        string id,
        ChatsListChatEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.PageSize != null)
        {
            _query["page_size"] = request.PageSize.Value.ToString();
        }
        if (request.PageNumber != null)
        {
            _query["page_number"] = request.PageNumber.Value.ToString();
        }
        if (request.AscendingOrder != null)
        {
            _query["ascending_order"] = JsonUtils.Serialize(request.AscendingOrder.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v0/evi/chats/{0}",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ReturnChatPagedEvents>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new HumeClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new HumeClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Fetches a paginated list of **Chats**.
    /// </summary>
    /// <example><code>
    /// await client.EmpathicVoice.Chats.ListChatsAsync(
    ///     new ChatsListChatsRequest
    ///     {
    ///         PageNumber = 0,
    ///         PageSize = 1,
    ///         AscendingOrder = true,
    ///     }
    /// );
    /// </code></example>
    public async System.Threading.Tasks.Task<Pager<ReturnChat>> ListChatsAsync(
        ChatsListChatsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ChatsListChatsRequest,
            RequestOptions?,
            ReturnPagedChats,
            int?,
            object,
            ReturnChat
        >
            .CreateInstanceAsync(
                request,
                options,
                ListChatsInternalAsync,
                request => request?.PageNumber ?? 0,
                (request, offset) =>
                {
                    request.PageNumber = offset;
                },
                null,
                response => response?.ChatsPage?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Fetches a paginated list of **Chat** events.
    /// </summary>
    /// <example><code>
    /// await client.EmpathicVoice.Chats.ListChatEventsAsync(
    ///     "470a49f6-1dec-4afe-8b61-035d3b2d63b0",
    ///     new ChatsListChatEventsRequest
    ///     {
    ///         PageNumber = 0,
    ///         PageSize = 3,
    ///         AscendingOrder = true,
    ///     }
    /// );
    /// </code></example>
    public async System.Threading.Tasks.Task<Pager<ReturnChatEvent>> ListChatEventsAsync(
        string id,
        ChatsListChatEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        request = request with { };
        var pager = await OffsetPager<
            ChatsListChatEventsRequest,
            RequestOptions?,
            ReturnChatPagedEvents,
            int?,
            object,
            ReturnChatEvent
        >
            .CreateInstanceAsync(
                request,
                options,
                (request, options, cancellationToken) =>
                    ListChatEventsInternalAsync(id, request, options, cancellationToken),
                request => request?.PageNumber ?? 0,
                (request, offset) =>
                {
                    request.PageNumber = offset;
                },
                null,
                response => response?.EventsPage?.ToList(),
                null,
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Fetches the audio of a previous **Chat**. For more details, see our guide on audio reconstruction [here](/docs/speech-to-speech-evi/faq#can-i-access-the-audio-of-previous-conversations-with-evi).
    /// </summary>
    /// <example><code>
    /// await client.EmpathicVoice.Chats.GetAudioAsync("470a49f6-1dec-4afe-8b61-035d3b2d63b0");
    /// </code></example>
    public async System.Threading.Tasks.Task<ReturnChatAudioReconstruction> GetAudioAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v0/evi/chats/{0}/audio",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ReturnChatAudioReconstruction>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new HumeClientException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(
                            JsonUtils.Deserialize<ErrorResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new HumeClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
