using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

  public class VaultsRepository
  {
    private IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL VAULTS
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM vaults;");
    }

    //GET VAULT BY ID
    public Vault GetById(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id;", new { id }).FirstOrDefault();
    }
    public IEnumerable<Vault> GetByUserId(string id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @id", new {id});
    }
    public IEnumerable<Vault> GetByVaultId(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new {id});
    }
    //CREATE A VAULT
    public Vault Create(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, userId)
        VALUES (@Name, @Description, @UserId);
        SELECT LAST_INSERT_ID();", vault
      );
      vault.Id = id;
      return vault;
    }

    //UPDATE a vault
    public Vault Update(Vault vault)
    {
      _db.Execute(@"
      UPDATE vaults SET (name, description) 
      VALUES (@Name, @Description)
      WHERE id = @Id
      ", vault);
      return vault;
    }

    //DELETE smoothie
    public Vault Delete(Vault vault)
    {
      _db.Execute("DELETE FROM vaults WHERE id = @Id", vault);
      return vault;
    }

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
    }


  }

}