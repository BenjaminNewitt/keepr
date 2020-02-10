using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Find(VaultKeep newData)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @KeepId AND vaultId = @VaultId AND userId = @UserId)";
      return _db.QueryFirstOrDefault(sql, newData);
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (keepId, vaultId)
      VALUES
      (@KeepId, @VaultId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }
  }
}