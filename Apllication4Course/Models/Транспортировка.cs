using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Транспортировка")]
    public class Транспортировка
    {
        [Key]
        public int ID_Транспортировки { get; set; }

        [Required]
        public int ID_Умершего { get; set; }

        [ForeignKey("ID_Умершего")]
        public virtual Умершие Умерший { get; set; }

        [Required]
        public string Тип_Перемещения { get; set; }

        [Required]
        public DateTime Дата_Время { get; set; }

        [Required]
        [StringLength(255)]
        public string Место_Отправления { get; set; }

        [Required]
        [StringLength(255)]
        public string Место_Назначения { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}