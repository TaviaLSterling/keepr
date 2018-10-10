using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultKeepsController : Controller
  {
    VaultKeepsRepository _repo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<VaultKeep> Get()
    {
      return _repo.GetAll();
    }

  
    [HttpPost]
    public VaultKeep Post([FromBody] VaultKeep vaultkeep)
    {
      if (ModelState.IsValid)
      {
        vaultkeep = new VaultKeep(vaultkeep.VaultId, vaultkeep.KeepId, vaultkeep.UserId);
        return _repo.Create(vaultkeep);
      }
      throw new System.Exception("Invalid");
    }

  }
}