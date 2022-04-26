using FamilyTrackerAPI.Core;
using FamilyTrackerAPI.Core.IServices;
using FamilyTrackerAPI.Domain.IRepositories;

namespace FamilyTrackerAPI.Domain.Services;

public class FamilyMemberService : IFamilyMemberService
{
    private readonly IFamilyMemberRepository _repository;

    public FamilyMemberService(IFamilyMemberRepository memberRepository)
    {
        _repository = memberRepository;
    }
    
    public FamilyMember CreateFamilyMember(FamilyMember familyMember)
    {
        return _repository.CreateFamilyMember(familyMember);
    }

    public FamilyMember GetFamilyMember(int id)
    {
        return _repository.GetFamilyMember(id);
    }

    public List<FamilyMember> GetFamilyMembers()
    {
        return _repository.GetFamilyMembers();
    }

    public void DeleteFamilyMember(int id)
    {
        _repository.DeleteFamilyMember(id);
    }

    public FamilyMember UpdateFamilyMember(FamilyMember familyMember)
    {
        return _repository.UpdateFamilyMember(familyMember);
    }
}