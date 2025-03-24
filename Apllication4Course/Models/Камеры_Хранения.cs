using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Камеры_Хранения")]
    public class Камеры_Хранения
    {
        [Key]
        public int ID_Камеры { get; set; }

        [Required]
        public int Номер_Камеры { get; set; }

        [Required]
        public decimal Температура { get; set; }

        [Required]
        public int Вместимость { get; set; }
    }
}