# EmojiHubApi
Library for the EmojiHub Website (No API Key needed)
## How to use
### Create a new instance of the EmojiHubClient
```
var client = new EmojiHubClient();
```
### Get all Emojis from the Website
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAll();
```
### Get a random Emoji from the Website asynchronously
```
Emoji randomEmojis = await client.GetRandom();
```
### Get Emojis by a category
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAllByCategory(Category.Objects);

Emoji randomEmoji = await client.GetRandomByCategory(Category.Objects);
```
### Get Emojis by a group
```
IAsyncEnumerable<Emoji> allEmojis = client.GetAllByGroup(Group.Activities);

Emoji randomEmoji = await client.GetRandomByGroup(Group.Activities);
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
