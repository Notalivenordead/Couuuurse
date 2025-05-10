using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models.Reports
{
    [Table("ResearchView")]
    public class ResearchReport
    {
        [Key]
        public int ID_Исследования { get; set; }

        [Display(Name = "ФИО умершего")]
        public string ФИО_Умершего { get; set; }

        [Display(Name = "Тип исследования")]
        public string Тип_Исследования { get; set; }

        [Display(Name = "Дата проведения")]
        public DateTime Дата_Проведения { get; set; }

        [Display(Name = "Описание")]
        public string Описание { get; set; }

        [Display(Name = "Результаты")]
        public string Результаты { get; set; }

        [Display(Name = "ФИО исполнителя")]
        public string ФИО_Исполнителя { get; set; }
    }
}