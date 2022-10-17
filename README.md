# EmojiHubApi
Library for the EmojiHub Website (No API Key needed)
## How to use
### Create a new instance of the EmojiHubClient
```
var client = new EmojiHubClient();
```
### Get all Emojis from the Website
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAllAsync();
```
### Get a random Emoji from the Website asynchronously
```
Emoji randomEmojis = await client.GetRandomAsync();
```
### Get Emojis by a category
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAllByCategoryAsync(Category.Objects);

Emoji randomEmoji = await client.GetRandomByCategoryAsync(Category.Objects);
```
### Get Emojis by a group
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAllByGroupAsync(Group.Activities);

Emoji randomEmoji = await client.GetRandomByGroupAsync(Group.Activities);
```
### Dispose the EmojiHubClient
```
client.Dispose();
```
## Dependency Injection Support
```
private readonly IEmojiHubClient _client;

public Program(IEmojiHubClient client)
{
    _client = client;
}
```
