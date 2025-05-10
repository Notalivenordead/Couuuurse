using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models.Reports
{
    [Table("FinancialOperationView")]
    public class FinancialOperationReport
    {
        [Key]
        public int ID_Операции { get; set; }

        [Display(Name = "Услуга")]
        public string Услуга { get; set; }

        [Display(Name = "Сумма")]
        public decimal Сумма { get; set; }

        [Display(Name = "Тип операции")]
        public string Тип_Операции { get; set; }

        [Display(Name = "Дата операции")]
        public DateTime Дата_Операции { get; set; }

        [Display(Name = "Способ оплаты")]
        public string Способ_Оплаты { get; set; }

        [Display(Name = "ФИО ответственного")]
        public string ФИО_Ответственного { get; set; }
    }
}