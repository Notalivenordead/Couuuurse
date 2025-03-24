using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Умершие")]
    public class Умершие
    {
        [Key]
        public int ID_Умершего { get; set; }

        [Required]
        [StringLength(255)]
        public string ФИО { get; set; }

        [Required]
        public DateTime Дата_Смерти { get; set; }

        [Required]
        [StringLength(255)]
        public string Место_Смерти { get; set; }

        [Required]
        public string Причина_Смерти { get; set; }

        [Required]
        public DateTime Дата_Поступления { get; set; }
    }
}