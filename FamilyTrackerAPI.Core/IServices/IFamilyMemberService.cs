namespace FamilyTrackerAPI.Core.IServices;

public interface IFamilyMemberService
{
    FamilyMember CreateFamilyMember(FamilyMember familyMember);

    FamilyMember GetFamilyMember(int id);

    List<FamilyMember> GetFamilyMembers();

    void DeleteFamilyMember(int id);

    FamilyMember UpdateFamilyMember(FamilyMember familyMember);
}