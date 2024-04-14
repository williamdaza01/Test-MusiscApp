using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_MusiscApp.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }
    }
}
