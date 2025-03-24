using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Места_В_Камерах")]
    public class Места_В_Камерах
    {
        [Key]
        public int ID_Места { get; set; }

        [Required]
        public int ID_Камеры { get; set; }

        [ForeignKey("ID_Камеры")]
        public virtual Камеры_Хранения Камера { get; set; }

        [Required]
        public int ID_Умершего { get; set; }

        [ForeignKey("ID_Умершего")]
        public virtual Умершие Умерший { get; set; }

        [Required]
        public DateTime Дата_Размещения { get; set; }

        public DateTime? Дата_Извлечения { get; set; }

    }
}