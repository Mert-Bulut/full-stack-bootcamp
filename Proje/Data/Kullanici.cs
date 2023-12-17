using System.ComponentModel.DataAnnotations;

namespace Proje.Data
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        public string? Username { get; set; }
        public string? KullaniciAd { get; set; }
        public string? KullaniciSoyad { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        public string? Sifre { get; set; }
    }
}
