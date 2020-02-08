using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Create(Vault VaultData)
    {
      string sql = @"INSERT INTO vaults
      (name, description, userId)
      VALUES (@Name, @Description, @UserId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, VaultData);
      VaultData.Id = id;
      return VaultData;
    }

    internal Vault GetVaultById(int Id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @Id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { Id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id";
      _db.Execute(sql, new { id });
    }
  }
}