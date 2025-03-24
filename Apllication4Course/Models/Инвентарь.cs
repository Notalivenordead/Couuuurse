using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Инвентарь")]
    public class Инвентарь
    {
        [Key]
        public int ID_Инвентаря { get; set; }

        [Required]
        [StringLength(255)]
        public string Наименование { get; set; }

        [Required]
        public int Количество { get; set; }

        [Required]
        [StringLength(50)]
        public string Единица_Измерения { get; set; }
    }
}