using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apllication4Course.Models
{
    [Table("Способ_Оплаты")]
    public class Способ_Оплаты
    {
        [Key]
        public int ID_Способа { get; set; }

        [Required]
        [StringLength(50)]
        public string Наименование { get; set; }
    }
}