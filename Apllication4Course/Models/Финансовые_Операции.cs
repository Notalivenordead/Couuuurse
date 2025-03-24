using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Финансовые_Операции")]
    public class Финансовые_Операции
    {
        [Key]
        public int ID_Операции { get; set; }

        [Required]
        public int ID_Заявки { get; set; }

        [ForeignKey("ID_Заявки")]
        public virtual Заявки_на_Платные_Услуги Заявка { get; set; }

        [Required]
        public decimal Сумма { get; set; }

        [Required]
        public string Тип { get; set; }

        [Required]
        public DateTime Дата_Операции { get; set; }

        [Required]
        public int ID_Способа { get; set; }

        [ForeignKey("ID_Способа")]
        public virtual Способ_Оплаты СпособОплаты { get; set; }
    }
}