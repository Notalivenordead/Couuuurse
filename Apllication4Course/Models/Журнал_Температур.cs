using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Журнал_Температур")]
    public class Журнал_Температур
    {
        [Key]
        public int ID_Записи { get; set; }

        [Required]
        public int ID_Камеры { get; set; }

        [ForeignKey("ID_Камеры")]
        public virtual Камеры_Хранения Камера { get; set; }

        [Required]
        public DateTime Дата_Измерения { get; set; }

        [Required]
        public decimal Температура { get; set; }

        [Required]
        public int ID_Ответственного { get; set; }

        [ForeignKey("ID_Ответственного")]
        public virtual Сотрудники Ответственный { get; set; }
    }
}