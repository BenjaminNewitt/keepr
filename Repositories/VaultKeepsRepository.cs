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

    internal VaultKeep Find(VaultKeep vk)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (keepId = @KeepId AND vaultId = @VaultId AND userId = @UserId)";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, vk);
    }

    internal VaultKeep Create(VaultKeep newData)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (keepId, vaultId, userId)
      VALUES
      (@KeepId, @VaultId, @UserId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newData);
      newData.Id = id;
      return newData;
    }

    internal void Delete(int Id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id =@Id";
      _db.Execute(sql, new { Id });
    }
  }
}