using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Журнал_Обращений")]
    public class Журнал_Обращений
    {
        [Key]
        public int ID_Записи { get; set; }

        [Required]
        [StringLength(255)]
        public string ФИО_Обратившегося { get; set; }

        [Required]
        [StringLength(15)]
        public string КонтактныйТелефон { get; set; }

        [Required]
        [StringLength(100)]
        public string СвязьСУмершим { get; set; }

        [Required]
        public DateTime Дата_Обращения { get; set; }

        [Required]
        public string Тип_Обращения { get; set; }

        public string Описание { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}