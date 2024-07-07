using System.ComponentModel.DataAnnotations;

namespace WebAppProject.Models
{
    public class Party
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="ใส่ชื่อปาร์ตี้ด้วยนะคะ")]
        public string Name { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string img { get; set; }
        [Required]
        public int Max {  get; set; }
        public string Host { get; set; }
        public string member { get; set; } = "";
    }
}
