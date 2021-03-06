using FamilyTrackerAPI.Core;
using FamilyTrackerAPI.Domain.IRepositories;
using FamilyTrackerAPI.MongoDB.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FamilyTrackerAPI.MongoDB.Repositories;

public class FamilyMemberRepository : IFamilyMemberRepository
{
    private readonly IMongoCollection<FamilyMemberEntity> _familyMembersCollection;

    public FamilyMemberRepository(IOptions<FamilyTrackerDatabaseSettings> options)
    {
        var mongoClient = new MongoClient(
            options.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            options.Value.DatabaseName);

        _familyMembersCollection = mongoDatabase.GetCollection<FamilyMemberEntity>(
            options.Value.FamilyMembersCollectionName);
    }
    
    public FamilyMember CreateFamilyMember(FamilyMember familyMember)
    {
        FamilyMemberEntity familyMemberEntity = new FamilyMemberEntity
        {
            Id = familyMember.Id,
            Name = familyMember.Name,
            Phone = familyMember.Phone,
            Location = familyMember.Location,
            Picture = familyMember.Picture
        };
        
        _familyMembersCollection.InsertOne(familyMemberEntity);

        return new FamilyMember
        {
            Id = familyMemberEntity.Id,
            Name = familyMemberEntity.Name,
            Phone = familyMemberEntity.Phone,
            Location = familyMemberEntity.Location,
            Picture = familyMemberEntity.Picture
        };
    }

    public FamilyMember GetFamilyMember(string id)
    {
        var member = _familyMembersCollection.Find(Builders<FamilyMemberEntity>.Filter.Eq("_id", ObjectId.Parse(id)))
            .FirstOrDefault();
        
        return new FamilyMember
        {
            Id = member.Id,
            Name = member.Name,
            Phone = member.Phone,
            Picture = member.Picture,
            Location = member.Location
        };
    }

    public List<FamilyMember> GetFamilyMembers()
    {
        var query = _familyMembersCollection.AsQueryable<FamilyMemberEntity>()
            .Select(entity => new
            {
                entity.Id, entity.Name, entity.Location, entity.Phone,
                entity.Picture
            });

        List<FamilyMember> list = new List<FamilyMember>();
        
        foreach (var member in query)
        {
            list.Add(new FamilyMember() {Id = member.Id, Name = member.Name, Phone = member.Phone, Picture = member.Picture, Location = member.Location});
        }

        return list;
    }

    public void DeleteFamilyMember(string id)
    {
        _familyMembersCollection.DeleteOne(entity => entity.Id == id);
        
    }

    public FamilyMember UpdateFamilyMember(FamilyMember familyMember)
    {
        var filter = Builders<FamilyMemberEntity>.Filter.Eq("_id", ObjectId.Parse(familyMember.Id));

        var entity = new FamilyMemberEntity
        {
            Id = familyMember.Id,
            Name = familyMember.Name,
            Phone = familyMember.Phone,
            Picture = familyMember.Picture,
            Location = familyMember.Location
        };
        
        _familyMembersCollection.ReplaceOne(filter, entity);

        return new FamilyMember
        {
            Id = entity.Id,
            Name = entity.Name,
            Phone = entity.Phone,
            Picture = entity.Picture,
            Location = entity.Location
        };
    }
}