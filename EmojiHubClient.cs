namespace EmojiHubApi;

using Newtonsoft.Json;
using System.Text;

/// <summary>
/// An interface for the EmojiHubClient
/// </summary>
public interface IEmojiHubClient
{
    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/>
    /// </summary>
    public ValueTask<Emoji> GetRandomAsync();

    /// <summary>
    /// Fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    public IAsyncEnumerable<Emoji> GetAllAsync();

    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/> by a <see cref="Category"/>
    /// </summary>
    /// <param name="category">The category to search by</param>
    public ValueTask<Emoji> GetRandomByCategoryAsync(Category category);

    /// <summary>
    /// Asynchronously fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/> by a <see cref="Category"/>
    /// </summary>
    /// <param name="category">The category to search by</param>
    public IAsyncEnumerable<Emoji> GetAllByCategoryAsync(Category category);

    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/> by a <see cref="Group"/>
    /// </summary>
    /// <param name="group">The group to search by</param>
    public ValueTask<Emoji> GetRandomByGroupAsync(Group group);

    /// <summary>
    /// Asynchronously fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/> by a <see cref="Group"/>
    /// </summary>
    /// <param name="group">The group to search by</param>
    public IAsyncEnumerable<Emoji> GetAllByGroupAsync(Group group);

    /// <summary>
    /// Disposes the client
    /// </summary>
    public void Dispose();
}

/// <summary>
/// The EmojiHubClient to fetch data from the website
/// </summary>
public sealed class EmojiHubClient : IEmojiHubClient, IDisposable
{
    private const string BASE_URL = "https://emojihub.herokuapp.com/api";

    private HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the an <see cref="EmojiHubClient"/>
    /// </summary>
    public EmojiHubClient()
    {
        _client = new HttpClient();
    }

    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/>
    /// </summary>
    public async ValueTask<Emoji> GetRandomAsync()
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/random");

        return DecodeJEmoji(json);
    }

    /// <summary>
    /// Fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/>
    /// </summary>
    public async IAsyncEnumerable<Emoji> GetAllAsync()
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/all");

        foreach (var emoji in DecodeJEmojis(json))
        {
            yield return emoji;
        }
    }

    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/> by a <see cref="Category"/>
    /// </summary>
    /// <param name="category">The category to search by</param>
    public async ValueTask<Emoji> GetRandomByCategoryAsync(Category category)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/random/category_{category.Name}");

        return DecodeJEmoji(json);
    }

    /// <summary>
    /// Asynchronously fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/> by a <see cref="Category"/>
    /// </summary>
    /// <param name="category">The category to search by</param>
    public async IAsyncEnumerable<Emoji> GetAllByCategoryAsync(Category category)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/all/category_{category.Name}");

        if (json.StartsWith('['))
        {
            foreach (var emoji in DecodeJEmojis(json))
            {
                yield return emoji;
            }
        }
        else yield return DecodeJEmoji(json);
    }

    /// <summary>
    /// Asynchronously fetches a random <see cref="Emoji"/> by a <see cref="Group"/>
    /// </summary>
    /// <param name="group">The group to search by</param>
    public async ValueTask<Emoji> GetRandomByGroupAsync(Group group)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/random/group_{group.Name}");

        return DecodeJEmoji(json);
    }

    /// <summary>
    /// Asynchronously fetches all <see cref="Emoji"/> as <see cref="IAsyncEnumerable{T}"/> by a <see cref="Group"/>
    /// </summary>
    /// <param name="group">The group to search by</param>
    public async IAsyncEnumerable<Emoji> GetAllByGroupAsync(Group group)
    {
        string json = await _client.GetStringAsync($"{BASE_URL}/all/group_{group.Name}");

        if (json.StartsWith('['))
        {
            foreach (var emoji in DecodeJEmojis(json))
            {
                yield return emoji;
            }
        }
        else yield return DecodeJEmoji(json);
    }

    private static Emoji DecodeJEmoji(string json)
    {
        var jemoji = JsonConvert.DeserializeObject<JEmoji>(json);

        return jemoji is null
            ? throw new Exception("Something went wrong in decoding the Emoji")
            : new Emoji(jemoji.Name,
            Category.GetFromString(jemoji.Category),
            Group.GetFromString(jemoji.Group),
            string.Concat(jemoji.HtmlCodes),
            ToUnicode(jemoji.UniCodes));
    }

    private static IEnumerable<Emoji> DecodeJEmojis(string json)
    {
        var jemojis = JsonConvert.DeserializeObject<JEmoji[]>(json);

        if (jemojis is null || jemojis.Length == 0) throw new Exception("Something went wrong in decoding the Emojis");

        foreach (var jemoji in jemojis)
        {
            yield return new Emoji(jemoji.Name,
                Category.GetFromString(jemoji.Category),
                Group.GetFromString(jemoji.Group),
                string.Concat(jemoji.HtmlCodes),
                ToUnicode(jemoji.UniCodes));
        }
    }

    private static string ToUnicode(string[] unicodes)
    {
        var sb = new StringBuilder();

        foreach (var unicode in unicodes)
        {
            sb.Append(char.ConvertFromUtf32(Convert.ToInt32(unicode.Replace("U+", ""), 16)));
        }

        return sb.ToString();
    }

    /// <summary>
    /// Disposes the client
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}