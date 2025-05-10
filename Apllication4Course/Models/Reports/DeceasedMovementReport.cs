using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models.Reports
{
    [Table("DeceasedMovementView")]
    public class DeceasedMovementReport
    {
        [Key]
        public int ID_Умершего { get; set; }

        [Display(Name = "ФИО")]
        public string ФИО { get; set; }

        [Display(Name = "Дата смерти")]
        public DateTime Дата_Смерти { get; set; }

        [Display(Name = "Место смерти")]
        public string Место_Смерти { get; set; }

        [Display(Name = "Причина смерти")]
        public string Причина_Смерти { get; set; }

        [Display(Name = "Тип перемещения")]
        public string Тип_Перемещения { get; set; }

        [Display(Name = "Дата перемещения")]
        public DateTime Дата_Перемещения { get; set; }

        [Display(Name = "Место отправления")]
        public string Место_Отправления { get; set; }

        [Display(Name = "Место назначения")]
        public string Место_Назначения { get; set; }

        [Display(Name = "ФИО ответственного")]
        public string ФИО_Ответственного { get; set; }
    }
}