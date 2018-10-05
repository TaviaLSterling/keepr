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
  public class VaultsController : Controller
  {
    VaultsRepository _repo;

    public VaultsController(VaultsRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Vault> Get()
    {
      return _repo.GetAll();
    }
    //Get a vault by the id of the vault
    [HttpGet("id")]
    public Vault GetById(int id)
    {
      return _repo.GetById(id);
    }
    [HttpPost]
    [Authorize]
    public Vault Post([FromBody] Vault vault)
    {
      if (ModelState.IsValid)
      {
        vault = new Vault(vault.Name, vault.Description);
        return _repo.Create(vault);
      }
      throw new Exception("INVALID VAULT");
    }

  }

}