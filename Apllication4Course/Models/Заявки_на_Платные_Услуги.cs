using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Заявки_на_Платные_Услуги")]
    public class Заявки_на_Платные_Услуги
    {
        [Key]
        public int ID_Заявки { get; set; }

        [Required]
        public int ID_Услуги { get; set; }

        [ForeignKey("ID_Услуги")]
        public virtual Услуги Услуга { get; set; }

        [Required]
        [StringLength(255)]
        public string ФИО_Заказчика { get; set; }

        [Required]
        [StringLength(15)]
        public string КонтактныйТелефон { get; set; }

        [Required]
        public DateTime Дата_Подачи { get; set; }

        [Required]
        public string Статус { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}