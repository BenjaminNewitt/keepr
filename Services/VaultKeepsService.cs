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
      var exists = _repo.Find(newData);
      if (exists != null)
      {
        throw new Exception("Keep already in Vault");
      }
      _repo.Create(newData);
    }
  }
}