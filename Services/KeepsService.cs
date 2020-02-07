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
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    internal Keep GetKeepById(int Id, string UserId)
    {
      Keep exists = _repo.GetKeepById(Id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      if (exists.UserId != exists.UserId || exists.IsPrivate == true) { throw new Exception("Unauthorized"); }
      return exists;
    }

    internal Keep Edit(Keep Update)
    {
      Keep exists = _repo.GetKeepById(Update.Id);
      if (exists == null) { throw new Exception("Invalid Request"); }
      if (exists.UserId != Update.UserId) { throw new Exception("Unauthorized"); }

      _repo.Edit(Update);
      return Update;
    }
  }
}