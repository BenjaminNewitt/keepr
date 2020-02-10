using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);

    }

    internal IEnumerable<Vault> GetVaults(string UserId)
    {
      // Vault exists = _repo.GetVaultById(Id);
      // if (exists == null) { throw new Exception("Invalid ID"); }
      // if (exists.UserId != UserId) { throw new Exception("Unauthorized"); }
      // return exists;

      return _repo.GetVaults(UserId);
    }

    internal string Delete(int Id, string UserId)
    {
      Vault exists = _repo.GetVaultById(Id);
      if (exists == null) { throw new Exception("Invalid Request"); }
      if (exists.UserId != UserId) { throw new Exception("Unauthorized"); }
      _repo.Delete(Id);
      return "Successfully Deleted";
    }
  }
}