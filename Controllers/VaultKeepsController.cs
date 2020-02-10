using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    private readonly KeepsService _ks;
    public VaultKeepsController(VaultKeepsService vks, KeepsService ks)
    {
      _vks = vks;
      _ks = ks;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<String> Create([FromBody] VaultKeep newData)
    {
      try
      {
        var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newData.UserId = UserId;
        _vks.Create(newData);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{Id}/Keeps")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetKeepsByVaultId(int Id)
    {
      try
      {
        var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetKeepsByVaultId(Id, UserId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{VaultId}/keeps/{KeepId}")]
    [Authorize]
    public ActionResult<String> Edit(int VaultId, int KeepId)
    {
      try
      {
        var UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(VaultId, KeepId, UserId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}