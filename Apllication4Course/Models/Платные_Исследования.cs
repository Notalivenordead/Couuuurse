using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Платные_Исследования")]
    public class Платные_Исследования
    {
        [Key]
        public int ID_Платного_Исследования { get; set; }

        [Required]
        public int ID_Заявки { get; set; }

        [ForeignKey("ID_Заявки")]
        public virtual Заявки_на_Платные_Услуги Заявка { get; set; }

        [Required]
        [StringLength(255)]
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