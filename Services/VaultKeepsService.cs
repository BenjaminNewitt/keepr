using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _repo = vkr;
    }

    internal void Create(VaultKeep newData)
    {
      VaultKeep exists = _repo.Find(newData);
      if (exists != null)
      {
        return;
      }
      _repo.Create(newData);
    }

    internal string Delete(int VaultId, int KeepId, string UserId)
    {
      VaultKeep exists = _repo.FindToDelete(VaultId, KeepId, UserId);
      if (exists == null)
      {
        throw new Exception("Invalid ID Combination");
      }
      _repo.Delete(exists.Id);
      return "Successfully Deleted";
    }
  }
}