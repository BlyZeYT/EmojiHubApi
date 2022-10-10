namespace EmojiHubApi;

/// <summary>
/// A record with the data of a Category
/// </summary>
public sealed record Category
{
    internal string Name { get; init; }

    private Category(string name)
    {
        Name = name;
    }

    internal static Category GetFromString(string categoryStr)
    {
        Category[] categories = new Category[]
        {
            SmileysAndPeople,
            AnimalsAndNature,
            FoodAndDrink,
            TravelAndPlaces,
            Activities,
            Objects,
            Symbols,
            Flags
        };

        categoryStr = categoryStr.Replace(' ', '_');

        var category = categories.FirstOrDefault(x => x?.Name == categoryStr, null);

        return category is null ? throw new Exception("Can't find that category") : category;
    }

    /// <summary>
    /// Returns the Smileys and People category
    /// </summary>
    public static Category SmileysAndPeople { get; } = new("smileys_and_people");

    /// <summary>
    /// Returns the Animals and Nature category
    /// </summary>
    public static Category AnimalsAndNature { get; } = new("animals_and_nature");

    /// <summary>
    /// Returns the Food and Drink category
    /// </summary>
    public static Category FoodAndDrink { get; } = new("food_and_drink");

    /// <summary>
    /// Returns the Travel and Places category
    /// </summary>
    public static Category TravelAndPlaces { get; } = new("travel_and_places");

    /// <summary>
    /// Returns the Activities category
    /// </summary>
    public static Category Activities { get; } = new("activities");

    /// <summary>
    /// Returns the Objects category
    /// </summary>
    public static Category Objects { get; } = new("objects");

    /// <summary>
    /// Returns the Symbols category
    /// </summary>
    public static Category Symbols { get; } = new("symbols");

    /// <summary>
    /// Returns the Flags category
    /// </summary>
    public static Category Flags { get; } = new("flags");

    /// <summary>
    /// Returns the category as string
    /// </summary>
    public override string ToString() => Name.Replace('_', ' ');
}