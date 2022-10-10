namespace EmojiHubApi;

/// <summary>
/// A record with the data of a Group
/// </summary>
public sealed record Group
{
    internal string Name { get; init; }

    private Group(string name)
    {
        Name = name;
    }

    internal static Group GetFromString(string groupStr)
    {
        Group[] groups = new Group[]
        {
            Body,
            CatFace,
            Clothing,
            CreatureFace,
            Emotion,
            FaceNegative,
            FaceNeutral,
            FacePositive,
            FaceRole,
            FaceSick,
            Family,
            MonkeyFace,
            Person,
            PersonActivity,
            PersonGesture,
            PersonRole,
            SkinTone,
            AnimalAmphibian,
            AnimalBird,
            AnimalBug,
            AnimalMammal,
            AnimalMarine,
            AnimalReptile,
            PlantFlower,
            PlantOther,
            Dishware,
            Drink,
            FoodAsian,
            FoodFruit,
            FoodPrepared,
            FoodSweat,
            FoodVegetable,
            TravelAndPlaces,
            Activities,
            Objects,
            Symbols,
            Flags
        };

        groupStr = groupStr.Replace(' ', '_');

        var group = groups.FirstOrDefault(x => x?.Name == groupStr, null);

        return group is null ? throw new Exception("Can't find that group") : group;
    }

    /// <summary>
    /// Returns the Body Group
    /// </summary>
    public static Group Body { get; } = new("body");

    /// <summary>
    /// Returns the Cat Face Group
    /// </summary>
    public static Group CatFace { get; } = new("cat_face");

    /// <summary>
    /// Returns the Clothing Group
    /// </summary>
    public static Group Clothing { get; } = new("clothing");

    /// <summary>
    /// Returns the Creature Face Group
    /// </summary>
    public static Group CreatureFace { get; } = new("creature_face");

    /// <summary>
    /// Returns the Emotion Group
    /// </summary>
    public static Group Emotion { get; } = new("emotion");

    /// <summary>
    /// Returns the Face Negative Group
    /// </summary>
    public static Group FaceNegative { get; } = new("face_negative");

    /// <summary>
    /// Returns the Face Neutral Group
    /// </summary>
    public static Group FaceNeutral { get; } = new("face_neutral");

    /// <summary>
    /// Returns the Face Positive Group
    /// </summary>
    public static Group FacePositive { get; } = new("face_positive");

    /// <summary>
    /// Returns the Face Role Group
    /// </summary>
    public static Group FaceRole { get; } = new("face_role");

    /// <summary>
    /// Returns the Face Sick Group
    /// </summary>
    public static Group FaceSick { get; } = new("face_sick");

    /// <summary>
    /// Returns the Family Group
    /// </summary>
    public static Group Family { get; } = new("family");

    /// <summary>
    /// Returns the Monkey Face Group
    /// </summary>
    public static Group MonkeyFace { get; } = new("monkey_face");

    /// <summary>
    /// Returns the Person Group
    /// </summary>
    public static Group Person { get; } = new("person");

    /// <summary>
    /// Returns the Person Activity Group
    /// </summary>
    public static Group PersonActivity { get; } = new("person_activity");

    /// <summary>
    /// Returns the Person Gesture Group
    /// </summary>
    public static Group PersonGesture { get; } = new("person_gesture");

    /// <summary>
    /// Returns the Person Role Group
    /// </summary>
    public static Group PersonRole { get; } = new("person_role");

    /// <summary>
    /// Returns the Skin Tone Group
    /// </summary>
    public static Group SkinTone { get; } = new("skin_tone");


    /// <summary>
    /// Returns the Animal Amphibian Group
    /// </summary>
    public static Group AnimalAmphibian { get; } = new("animal_amphibian");

    /// <summary>
    /// Returns the Animal Bird Group
    /// </summary>
    public static Group AnimalBird { get; } = new("animal_bird");

    /// <summary>
    /// Returns the Animal Bug Group
    /// </summary>
    public static Group AnimalBug { get; } = new("animal_bug");

    /// <summary>
    /// Returns the Animal Mammal Group
    /// </summary>
    public static Group AnimalMammal { get; } = new("animal_mammal");

    /// <summary>
    /// Returns the Animal Marine Group
    /// </summary>
    public static Group AnimalMarine { get; } = new("animal_marine");

    /// <summary>
    /// Returns the Animal Reptile Group
    /// </summary>
    public static Group AnimalReptile { get; } = new("animal_reptile");

    /// <summary>
    /// Returns the Plant Flower Group
    /// </summary>
    public static Group PlantFlower { get; } = new("plant_flower");

    /// <summary>
    /// Returns the Plant Other Group
    /// </summary>
    public static Group PlantOther { get; } = new("plant_other");


    /// <summary>
    /// Returns the Dishware Group
    /// </summary>
    public static Group Dishware { get; } = new("dishware");

    /// <summary>
    /// Returns the Drink Group
    /// </summary>
    public static Group Drink { get; } = new("drink");

    /// <summary>
    /// Returns the Food Asian Group
    /// </summary>
    public static Group FoodAsian { get; } = new("food_asian");

    /// <summary>
    /// Returns the Food Fruit Group
    /// </summary>
    public static Group FoodFruit { get; } = new("food_fruit");

    /// <summary>
    /// Returns the Food Prepared Group
    /// </summary>
    public static Group FoodPrepared { get; } = new("food_prepared");

    /// <summary>
    /// Returns the Food Sweat Group
    /// </summary>
    public static Group FoodSweat { get; } = new("food_sweat");

    /// <summary>
    /// Returns the Food Vegetable Group
    /// </summary>
    public static Group FoodVegetable { get; } = new("food_vegetable");


    /// <summary>
    /// Returns the Travel and Places Group
    /// </summary>
    public static Group TravelAndPlaces { get; } = new("travel_and_places");


    /// <summary>
    /// Returns the Activities Group
    /// </summary>
    public static Group Activities { get; } = new("activities");


    /// <summary>
    /// Returns the Objects Group
    /// </summary>
    public static Group Objects { get; } = new("objects");


    /// <summary>
    /// Returns the Symbols Group
    /// </summary>
    public static Group Symbols { get; } = new("symbols");


    /// <summary>
    /// Returns the Flags Group
    /// </summary>
    public static Group Flags { get; } = new("flags");

    /// <summary>
    /// Returns the group as string
    /// </summary>
    public override string ToString() => Name.Replace('_', ' ');
}