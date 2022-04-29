using FamilyTrackerAPI.Core;

namespace FamilyTrackerAPI.Domain.IRepositories;

public interface IFamilyMemberRepository
{
    FamilyMember CreateFamilyMember(FamilyMember familyMember);

    FamilyMember GetFamilyMember(string id);
    
    List<FamilyMember> GetFamilyMembers();

    void DeleteFamilyMember(string id);

    FamilyMember UpdateFamilyMember(FamilyMember familyMember);
}