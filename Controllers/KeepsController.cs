using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : Controller
  {
    KeepsRepository _repo;

    public KeepsController(KeepsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Keep> GetAll()
    {
      return _repo.GetAll();
    }

    [HttpPost]
     [Authorize]
    public Keep Post([FromBody] Keep keep)
    {
      if (ModelState.IsValid)
      {
        keep = new Keep(keep.Name, keep.Description, keep.Img);
        return _repo.Create(keep);
      }
      throw new Exception("INVALID KEEP");
    }
  // Get all of the keeps in specific vault
   [HttpGet("vault/{id}")]
        [Authorize]
        public IEnumerable<Keep> GetByVault(int id)
        {
            return _repo.GetByVault(id);
        }

        [HttpGet("{id}")]
        public Keep GetById(int id)
        {
          return _repo.GetById(id);
        }
        [HttpGet("user/{id}")]
        public IEnumerable<Keep> GetByUserId(int id)
        {
          return _repo.GetByUserId(id);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteKeep(int id)
        {

        }
        [HttpPut("{id}")]
        [Authorize]
        public Keep Update(int id,[FromBody]Keep keep)
        {
          return _repo.Update(id, keep);
        }
  }

}