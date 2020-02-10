using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"INSERT INTO keeps
            (name, description, userId, img, isPrivate)
            VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;
    }

    internal Keep GetKeepById(int Id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { Id });
    }

    internal void Edit(Keep Update)
    {
      string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description
      WHERE id = @Id;
      ";
      _db.Execute(sql, Update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      string sql = @"
      SELECT k.* FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultId AND vk.userId = @userId);
      ";
      return _db.Query<Keep>(sql, new { userId });
    }
  }
}