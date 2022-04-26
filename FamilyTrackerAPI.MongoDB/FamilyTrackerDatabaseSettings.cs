namespace FamilyTrackerAPI.MongoDB;

public class FamilyTrackerDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string FamilyMembersCollectionName { get; set; } = null!;
}