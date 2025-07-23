using System.Text.Json;
using System.Text.Json.Serialization;
using HumeApi;
using HumeApi.Core;

namespace HumeApi.EmpathicVoice;

/// <summary>
/// A paginated list of chat reconstructions for a particular chatgroup
/// </summary>
[Serializable]
public record ReturnChatGroupPagedAudioReconstructions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifier for the chat group. Formatted as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Identifier for the user that owns this chat. Formatted as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    /// <summary>
    /// Total number of chats in this chatgroup
    /// </summary>
    [JsonPropertyName("num_chats")]
    public required int NumChats { get; set; }

    /// <summary>
    /// The page number of the returned list.
    ///
    /// This value corresponds to the `page_number` parameter specified in the request. Pagination uses zero-based indexing.
    /// </summary>
    [JsonPropertyName("page_number")]
    public required int PageNumber { get; set; }

    /// <summary>
    /// The maximum number of items returned per page.
    ///
    /// This value corresponds to the `page_size` parameter specified in the request.
    /// </summary>
    [JsonPropertyName("page_size")]
    public required int PageSize { get; set; }

    /// <summary>
    /// The total number of pages in the collection.
    /// </summary>
    [JsonPropertyName("total_pages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// Indicates the order in which the paginated results are presented, based on their creation date.
    ///
    /// It shows `ASC` for ascending order (chronological, with the oldest records first) or `DESC` for descending order (reverse-chronological, with the newest records first). This value corresponds to the `ascending_order` query parameter used in the request.
    /// </summary>
    [JsonPropertyName("pagination_direction")]
    public required ReturnChatGroupPagedAudioReconstructionsPaginationDirection PaginationDirection { get; set; }

    /// <summary>
    /// List of chat audio reconstructions returned for the specified page number and page size.
    /// </summary>
    [JsonPropertyName("audio_reconstructions_page")]
    public IEnumerable<ReturnChatAudioReconstruction> AudioReconstructionsPage { get; set; } =
        new List<ReturnChatAudioReconstruction>();

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
