using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
  public class AppUser
  {
    public int ID { get; set; }
    public required string Adi { get; set; }
    public required string Soyadi { get; set; }
    public required string KullaniciAdi { get; set; }
    public required string Sifre { get; set; }

    public int RolID { get; set; }

    [ForeignKey("RolID")]
    public required Role Role { get; set; }
  }
}