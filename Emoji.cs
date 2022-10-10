namespace EmojiHubApi;

/// <summary>
/// A record with the data of an Emoji
/// </summary>
public sealed record Emoji
{
    /// <summary>
    /// Returns the Emoji name
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Returns the Emoji category
    /// </summary>
    public Category Category { get; init; }

    /// <summary>
    /// Returns the Emoji group
    /// </summary>
    public Group Group { get; init; }

    /// <summary>
    /// Returns the Emoji Html Code
    /// </summary>
    public string HtmlCode { get; init; }

    /// <summary>
    /// Returns the Emoji Unicode
    /// </summary>
    public string Unicode { get; init; }

    internal Emoji(string name, Category category, Group group, string htmlCode, string unicode)
    {
        Name = name;
        Category = category;
        Group = group;
        HtmlCode = htmlCode;
        Unicode = unicode;
    }
}