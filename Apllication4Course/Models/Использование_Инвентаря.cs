using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Использование_Инвентаря")]
    public class Использование_Инвентаря
    {
        [Key]
        public int ID_Использования { get; set; }

        [Required]
        public int ID_Исследования { get; set; }

        [ForeignKey("ID_Исследования")]
        public virtual Исследования Исследование { get; set; }

        [Required]
        public int ID_Инвентаря { get; set; }

        [ForeignKey("ID_Инвентаря")]
        public virtual Инвентарь Инвентарь { get; set; }

        [Required]
        public int КоличествоИспользовано { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}