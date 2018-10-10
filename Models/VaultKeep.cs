using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }

    [Required]
    public int VaultId { get; set; }

    public int KeepId { get; set; }
 
    public string UserId { get; set; }

    public VaultKeep(int vaultId, int keepId, string userid)
    {
      VaultId = vaultId;
      KeepId = keepId;
      UserId = userid;
    }
    public VaultKeep() { }
  }

}