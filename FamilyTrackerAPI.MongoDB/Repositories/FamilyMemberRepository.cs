﻿using FamilyTrackerAPI.Core;
using FamilyTrackerAPI.Domain.IRepositories;
using FamilyTrackerAPI.MongoDB.Entities;
using Microsoft.Extensions.Options;
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

    public FamilyMember GetFamilyMember(int id)
    {
        throw new NotImplementedException();
    }

    public List<FamilyMember> GetFamilyMembers()
    {
        throw new NotImplementedException();
    }

    public void DeleteFamilyMember(int id)
    {
        throw new NotImplementedException();
    }

    public FamilyMember UpdateFamilyMember(FamilyMember familyMember)
    {
        throw new NotImplementedException();
    }
}