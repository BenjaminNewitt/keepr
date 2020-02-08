using System;
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

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal Vault GetVaultById(int Id, string userId)
    {
      Vault exists = _repo.GetVaultById(Id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      if (exists.UserId != exists.UserId) { throw new Exception("Unauthorized"); }
      return exists;
    }
  }
}