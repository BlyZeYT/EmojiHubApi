namespace EmojiHubApi;

using Newtonsoft.Json;

[Serializable]
internal sealed record JEmoji
{
    [JsonRequired]
    [JsonProperty("name")]
    public string Name { get; init; }

    [JsonRequired]
    [JsonProperty("category")]
    public string Category { get; init; }

    [JsonRequired]
    [JsonProperty("group")]
    public string Group { get; init; }

    [JsonRequired]
    [JsonProperty("htmlCode")]
    public string[] HtmlCodes { get; init; }

    [JsonRequired]
    [JsonProperty("unicode")]
    public string[] UniCodes { get; init; }

    [JsonConstructor]
    internal JEmoji(string name, string category, string group, string[] htmlCodes, string[] uniCodes)
    {
        Name = name;
        Category = category;
        Group = group;
        HtmlCodes = htmlCodes;
        UniCodes = uniCodes;
    }
}