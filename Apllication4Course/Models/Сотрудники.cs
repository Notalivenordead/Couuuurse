using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Apllication4Course.Models
{
    [Table("Сотрудники")]
    public class Сотрудники
    {
        [Key]
        public int ID_Сотрудника { get; set; }

        [Required]
        [StringLength(50)]
        public string Логин { get; set; }

        [Required]
        [StringLength(255)]
        public string ПарольHash { get; set; }

        [Required]
        [StringLength(255)]
        public string ФИО { get; set; }

        [Required]
        [StringLength(100)]
        public string Должность { get; set; }

        [StringLength(15)]
        public string КонтактныйТелефон { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}