using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;
using System;

namespace keepr.Repositories
{

  public class KeepsRepository
  {
    private IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL KEEPS
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    //GET KEEPS BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE A KEEP
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, img)
        VALUES (@Name, @Description, @Img);
        SELECT LAST_INSERT_ID();", keep
      );
      keep.Id = id;
      return keep;
    }

    //UPDATE KEEP
    public Keep Update(int id, Keep keep)
    {
      _db.Execute(@"
      UPDATE keeps SET (name, description) 
      VALUES (@Name, @Description)
      WHERE id = @Id
      ", keep);
      return keep;
    }
      // Getting a keep by the Id of the vault
        internal IEnumerable<Keep> GetByVault(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE vaultId = @id;");
        }

        internal IEnumerable<Keep> GetByUserId(int id)
        {
            return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @id");
        }

        //DELETE smoothie
        //     public  Delete(Keep keep)
        // {
        //   _db.Execute("DELETE FROM keeps WHERE id = @Id", keep);
        //   return keep;
        // }

        public int DeleteKeep(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }


  }

}