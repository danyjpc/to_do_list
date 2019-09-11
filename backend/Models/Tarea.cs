using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models
{
    public class Tarea
    {
        [Key]
        public int cod_tarea { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string descripcion { get; set; }
    }
}