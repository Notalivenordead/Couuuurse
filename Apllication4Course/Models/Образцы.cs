using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Образцы")]
    public class Образцы
    {
        [Key]
        public int ID_Образца { get; set; }

        [Required]
        public int ID_Умершего { get; set; }

        [ForeignKey("ID_Умершего")]
        public virtual Умершие Умерший { get; set; }

        [Required]
        public string Тип_Образца { get; set; }

        [Required]
        public DateTime Дата_Взятия { get; set; }

        [Required]
        [StringLength(255)]
        public string Условия_Хранения { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}