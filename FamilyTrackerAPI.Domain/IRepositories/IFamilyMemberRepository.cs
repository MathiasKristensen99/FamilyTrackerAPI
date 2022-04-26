using FamilyTrackerAPI.Core;

namespace FamilyTrackerAPI.Domain.IRepositories;

public interface IFamilyMemberRepository
{
    FamilyMember CreateFamilyMember(FamilyMember familyMember);

    FamilyMember GetFamilyMember(int id);
    
    List<FamilyMember> GetFamilyMembers();

    void DeleteFamilyMember(int id);

    FamilyMember UpdateFamilyMember(FamilyMember familyMember);
}