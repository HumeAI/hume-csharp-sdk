using System.Text.Json.Serialization;
using Hume.Core;

namespace Hume.EmpathicVoice;

[Serializable]
public record PromptsListPromptVersionsRequest
{
    /// <summary>
    /// Specifies the page number to retrieve, enabling pagination.
    ///
    /// This parameter uses zero-based indexing. For example, setting `page_number` to 0 retrieves the first page of results (items 0-9 if `page_size` is 10), setting `page_number` to 1 retrieves the second page (items 10-19), and so on. Defaults to 0, which retrieves the first page.
    /// </summary>
    [JsonIgnore]
    public int? PageNumber { get; set; }

    /// <summary>
    /// Specifies the maximum number of results to include per page, enabling pagination. The value must be between 1 and 100, inclusive.
    ///
    /// For example, if `page_size` is set to 10, each page will include up to 10 items. Defaults to 10.
    /// </summary>
    [JsonIgnore]
    public int? PageSize { get; set; }

    /// <summary>
    /// By default, `restrict_to_most_recent` is set to true, returning only the latest version of each prompt. To include all versions of each prompt in the list, set `restrict_to_most_recent` to false.
    /// </summary>
    [JsonIgnore]
    public bool? RestrictToMostRecent { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
