using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

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

    //GET ALL KEEPSS
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    //GET KEEPS BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE smoothie
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description)
        VALUES (@Name, @Description);
        SELECT LAST_INSERT_ID();", keep
      );
      keep.Id = id;
      return keep;
    }

    //UPDATE smoothie
    public Keep Update(Keep keep)
    {
      _db.Execute(@"
      UPDATE keeps SET (name, description) 
      VALUES (@Name, @Description)
      WHERE id = @Id
      ", keep);
      return keep;
    }

    //DELETE smoothie
    public Keep Delete(Keep keep)
    {
      _db.Execute("DELETE FROM keeps WHERE id = @Id", keep);
      return keep;
    }

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }


  }

}