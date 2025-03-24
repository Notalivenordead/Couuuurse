using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Исследования")]
    public class Исследования
    {
        [Key]
        public int ID_Исследования { get; set; }

        [Required]
        public int ID_Умершего { get; set; }

        [ForeignKey("ID_Умершего")]
        public virtual Умершие Умерший { get; set; }

        [Required]
        public string Тип_Исследования { get; set; }

        [Required]
        public DateTime Дата_Проведения { get; set; }

        public string Описание { get; set; }

        public string Результаты { get; set; }

        [Required]
        public int ID_Исполнителя { get; set; }

        [ForeignKey("ID_Исполнителя")]
        public virtual Сотрудники Исполнитель { get; set; }
    }
}