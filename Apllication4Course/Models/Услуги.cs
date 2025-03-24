using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Услуги")]
    public class Услуги
    {
        [Key]
        public int ID_Услуги { get; set; }

        [Required]
        [StringLength(255)]
        public string Наименование { get; set; }

        public string Описание { get; set; }

        [Required]
        public decimal Стоимость { get; set; }

        [Required]
        public string Тип { get; set; }
    }
}