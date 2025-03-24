using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Использование_Образцов")]
    public class Использование_Образцов
    {
        [Key]
        public int ID_Использования { get; set; }

        [Required]
        public int ID_Образца { get; set; }

        [ForeignKey("ID_Образца")]
        public virtual Образцы Образец { get; set; }

        [Required]
        public int ID_Исследования { get; set; }

        [ForeignKey("ID_Исследования")]
        public virtual Исследования Исследование { get; set; }

        [Required]
        public decimal Количество_Использовано { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}