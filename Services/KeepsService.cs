using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep GetKeepById(int Id, string UserId)
    {
      Keep exists = _repo.GetKeepById(Id);
      if (exists == null)
      {
        throw new Exception("Invalid ID");
      }
      if (exists.IsPrivate == true && exists.UserId != UserId)
      {
        throw new Exception("Unauthorized");
      }
      // NOTE Increases view count after keep is successfully retrieved
      _repo.UpKeepViews(exists);
      exists.Views += 1;
      return exists;
    }

    internal Keep GetPublicKeepById(int Id)
    {
      Keep exists = _repo.GetKeepById(Id);
      if (exists == null)
      {
        throw new Exception("Invalid ID");
      }
      if (exists.IsPrivate == true)
      {
        throw new Exception("Unauthorized");
      }
      // NOTE Increases view count after keep is successfully retrieved
      _repo.UpKeepViews(exists);
      exists.Views += 1;
      return exists;
    }

    internal void UpVaultCount(int KeepId)
    {
      _repo.UpKeepsCount(KeepId);
    }

    internal IEnumerable<Keep> GetKeepsByUserId(string userId)
    {
      return _repo.GetKeepsByUserId(userId);
    }

    internal Keep Edit(Keep Update)
    {
      Keep exists = _repo.GetKeepById(Update.Id);
      if (exists == null)
      {
        throw new Exception("Invalid Request");
      }
      if (exists.UserId != Update.UserId) { throw new Exception("Unauthorized"); }

      _repo.Edit(Update);
      return Update;
    }

    internal string Delete(int Id, string UserId)
    {
      Keep exists = _repo.GetKeepById(Id);
      if (exists == null)
      {
        throw new Exception("Invalid Request");
      }
      if (exists.UserId != UserId)
      {
        throw new Exception("Unauthorized");
      }
      _repo.Delete(Id);
      return "Successfully Deleted";
    }



    internal IEnumerable<Keep> GetKeepsByVaultId(int id, string userId)
    {
      return _repo.GetKeepsByVaultId(id, userId);
    }

  }
}