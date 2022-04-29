using System.Collections.Generic;

namespace FamilyTrackerAPI.Core.IServices;

public interface IFamilyMemberService
{
    FamilyMember CreateFamilyMember(FamilyMember familyMember);

    FamilyMember GetFamilyMember(string id);

    List<FamilyMember> GetFamilyMembers();

    void DeleteFamilyMember(string id);

    FamilyMember UpdateFamilyMember(FamilyMember familyMember);
}